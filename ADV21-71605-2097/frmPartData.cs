using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmPartData : Form
    {
        #region Form properties
        // the id of the part which is to be modified
        private int _selectedPart = -1;

        // the name of the field which is to be searched against
        private string _selectedField = "Name";

        // list of fields which can be searched
        private List<ComboBoxItem> fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Part ID", "PartID"),
            new ComboBoxItem("Part Name", "Name"),
            new ComboBoxItem("Buy Price", "BuyPrice"),
            new ComboBoxItem("Sell Price", "SellPrice"),
            new ComboBoxItem("Quantity", "Quantity")
        };
        #endregion
        public frmPartData()
        {
            InitializeComponent();
        }
        #region Create
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // check that current user has at least "Restricted Write" permission before attempting to add a new part
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null) { MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // ensure that the part passes the validation set out by the class
            List<string> ValidationErrors = Part.ValidatePart(0, txtName.Text, numBuyPrice.Value, numSellPrice.Value, (int)numQuantity.Value);
            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors adding part", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // attempt to create a part object using the data
                Part NewPart = new Part(0, txtName.Text, numBuyPrice.Value, numSellPrice.Value, (int)numQuantity.Value);
                // attempt to add that new part
                string Message = Part.AddPart(NewPart);
                if (Message == null)
                {
                    MessageBox.Show("Part added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"part ({txtName.Text})");
                }
                else MessageBox.Show("Part not added:\n" + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error adding the new part:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadFormDefaults();
        }
        #endregion
        #region Retrieve
        // display data, and populate the field combobox with the available fields
        private void frmPartData_Load(object sender, EventArgs e)
        {
            AttemptDataDisplay();
            foreach (ComboBoxItem field in fields) comboSearchField.Items.Add(field);

            comboSearchField.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;
        }


        private void AttemptDataDisplay()
        {

            List<Part> Result = Part.RetrieveParts();

            // if no parts could be retrieved due to a server error
            if (Result == null)
            {
                MessageBox.Show("Error loading parts. Please contact the administrator.");
                LockDownForm();
                return;
            }

            dgvParts.DataSource = Result;
            // make column headers human-readable
            dgvParts.Columns["PartID"].HeaderText = "Part ID";
            dgvParts.Columns["Name"].HeaderText = "Part Name";
            dgvParts.Columns["BuyPrice"].HeaderText = "Buy Price";
            dgvParts.Columns["SellPrice"].HeaderText = "Sell Price";
            dgvParts.Columns["Quantity"].HeaderText = "Quantity";

            dgvParts.AutoResizeColumns();
        }

        // if a part has been selected within the datagridview
        private void dgvParts_SelectionChanged(object sender, EventArgs e)
        {
            // if there are no parts, do not attempt to display
            if (dgvParts.RowCount <= 0) return;

            try
            {
                // retrieve the appropriate part using the selected row's id
                Part Edit = Part.RetrieveByPartID(Convert.ToInt32(dgvParts.CurrentRow.Cells["PartID"].Value));

                // if the part has not been deleted
                if (Edit != null)
                {
                    _selectedPart = Edit.PartID;
                    txtPartID.Text = Edit.PartID.ToString();
                    txtName.Text = Edit.Name;
                    numBuyPrice.Value = Edit.BuyPrice;
                    numSellPrice.Value = Edit.SellPrice;
                    numQuantity.Value = Edit.Quantity;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting part: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            // check that current user has at least "Restricted Write" permission before attempting to save changes to a part
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null) { MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // if no part has been selected
            if (_selectedPart == -1) { MessageBox.Show("Select a part to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // ensure that the part passes the validation set out by the class
            List<string> ValidationErrors = Part.ValidatePart(int.Parse(txtPartID.Text), txtName.Text, numBuyPrice.Value, numSellPrice.Value, (int)numQuantity.Value);
            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors saving part", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verify that the user wants to update the part
            DialogResult Confirm = MessageBox.Show("Are you sure that you want to overwrite changes?", "Confirm", MessageBoxButtons.YesNo);
            if (Confirm == DialogResult.Yes)
            {
                // attempt to save the part
                string ErrorMessage = Part.SavePart(new Part(Convert.ToInt32(txtPartID.Text), txtName.Text, numBuyPrice.Value, numSellPrice.Value, (int)numQuantity.Value));
                if (ErrorMessage == null) MessageBox.Show("Successfully updated part.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // log changes
                Logging.WriteLog(Logging.LogType.Update, $"part {txtPartID.Text} ({txtName.Text})");
                LoadFormDefaults();
            }
        }
        #endregion
        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // check that current user has at least "Restricted Write" permission before attempting to delete a part
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null) { MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // if no part has been selected
            if (_selectedPart == -1) { MessageBox.Show("Select a part to delete."); return; }

            // verify that the user wants to delete the part
            DialogResult Confirm = MessageBox.Show("Are you sure you want to delete this part?", "Warning!", MessageBoxButtons.YesNo);
            if (Confirm == DialogResult.Yes)
            {
                // attempt to delete and output any errors
                string Message = Part.DeletePart(Convert.ToInt32(txtPartID.Text));
                if (Message != null) MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"part {txtPartID.Text} ({txtName.Text})");
                LoadFormDefaults();
            }
        }
        #endregion
        #region Search
        // update the datagridview with appropriate search results when typing in a substring
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvParts.DataSource = Part.GetPartsByField(txtSearch.Text, SearchType, _selectedField);
        }

        // if the field to be searched has been modified
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboSearchField.SelectedItem != null)
                _selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;
        }
        #endregion
        #region Misc
        // prevent further editing by disabling all controls associated with modifying or searching the database
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtName.Enabled = false;
            txtPartID.Enabled = false;
            txtSearch.Enabled = false;

            numBuyPrice.Enabled = false;
            numSellPrice.Enabled = false;
            numQuantity.Enabled = false;


            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;
        }


        // reset the form's controls to their default values
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }
        // load the default form control values
        private void LoadFormDefaults()
        {
            AttemptDataDisplay();
            txtPartID.Clear();
            txtName.Clear();
            numBuyPrice.Value = 0;
            numSellPrice.Value = 0;
            numQuantity.Value = 0;
            _selectedPart = -1;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpParts frm = new frmHelpParts();
            frm.Show();

        }
        #endregion


    }
}
