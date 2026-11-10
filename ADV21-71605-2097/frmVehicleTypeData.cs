using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmVehicleTypeData : Form
    {
        #region Form properties
        // the id of the vehicle type selected to be edited
        private int _selectedVehicleType = -1;

        // the name of the field selected to be searched
        private string _selectedField = "Name";

        // the fields that can be searched
        private List<ComboBoxItem> _fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Vehicle Type ID", "VehicleTypeID"),
            new ComboBoxItem("Name", "Name"),
            new ComboBoxItem("Complexity", "Complexity")
        };
        #endregion

        public frmVehicleTypeData()
        {
            InitializeComponent();
        }

        #region Create
        // attempt to add a new vehicle type to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure the user is permitted to carry the action out first ("Restricted Write" access)
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // carry out basic validation before attempting to add the new vehicle type
            List<string> ValidationErrors = VehicleType.ValidateVehicleType(txtVehicleTypeName.Text, numComplexity.Value);

            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors when attempting to save the vehicle type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // create a new object with the new information
                VehicleType NewType = new VehicleType(0, txtVehicleTypeName.Text, numComplexity.Value);
                string addingMessage = VehicleType.AddVehicleType(NewType);


                // if no error was output
                if (addingMessage == null)
                {
                    MessageBox.Show("Vehicle type has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"vehicle type ({txtVehicleTypeName.Text})");
                }
                else
                {
                    MessageBox.Show("Vehicle type has not been added:\n" + addingMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add unsuccessful:\n- " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadFormDefaults();
        }
        #endregion
        #region Retrieve
        // display data in the datagridview
        private void AttemptDataDisplay()
        {
            List<VehicleType> Result = VehicleType.RetrieveVehicleTypes();
            if (Result == null)
            {
                MessageBox.Show("There was an error attempting to load vehicle type data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            else
            {
                dgvVehicleTypes.DataSource = Result;
            }

            // set column headers to be human readable
            dgvVehicleTypes.Columns["VehicleTypeID"].HeaderText = "Vehicle Type ID";
            dgvVehicleTypes.Columns["Name"].HeaderText = "Vehicle Type Name";
            dgvVehicleTypes.Columns["Complexity"].HeaderText = "Vehicle Complexity";

            dgvVehicleTypes.AutoResizeColumns();
        }

        // when loading, display data and add search fields
        private void frmVehicleTypeData_Load(object sender, EventArgs e)
        {
            AttemptDataDisplay();
            foreach (ComboBoxItem field in _fields) comboSearchField.Items.Add(field);

            comboSearchField.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;
        }

        // when the selected vehicle type has changed, populate the fields in the form with its values
        private void dgvVehicleTypes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicleTypes.RowCount > 0)
            {
                try
                {
                    VehicleType edit = VehicleType.RetrieveByVehicleTypeID(Convert.ToInt32(dgvVehicleTypes.CurrentRow.Cells[0].Value));

                    if (edit != null)
                    {
                        _selectedVehicleType = edit.VehicleTypeID;
                        txtVehicleTypeID.Text = edit.VehicleTypeID.ToString();
                        txtVehicleTypeName.Text = edit.Name;
                        numComplexity.Value = edit.Complexity;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select vehicle type:\n- " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Update
        // attempt to update the selected vehicle type with new information
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ensure the user is permitted to carry the action out first ("Restricted Write" access)
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError);
                return;
            }

            // ensure a vehicle has been selected for editing
            if (_selectedVehicleType == -1)
            {
                MessageBox.Show("Choose a vehicle type to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // carry out basic validation before attempting to save
            List<string> ValidationErrors = VehicleType.ValidateVehicleType(txtVehicleTypeName.Text, numComplexity.Value);

            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // confirm that the user wants to update the current vehicle type
            DialogResult NewDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            if (NewDialog == DialogResult.Yes)
            {
                try
                {
                    // attempt to save, outputting the error message received if unsuccessful
                    string ErrorMessage = VehicleType.SaveVehicleType(
                        new VehicleType(Convert.ToInt32(txtVehicleTypeID.Text), txtVehicleTypeName.Text, numComplexity.Value)
                    );

                    if (ErrorMessage != null) MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Successfully updated vehicle type", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logging.WriteLog(Logging.LogType.Update, $"vehicle type {txtVehicleTypeID.Text} ({txtVehicleTypeName.Text})");
                    LoadFormDefaults();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save unsuccessful:\n -" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Delete
        // attempt to delete the vehicle type from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ensure the user is permitted to carry the action out first ("Restricted Write" access)
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // ensure a vehicle has been selected to be deleted
            if (_selectedVehicleType == -1)
            {
                MessageBox.Show("Select a vehicle type to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult NewDialog = MessageBox.Show("Are you sure you wish to delete the selected record?", "Warning!", MessageBoxButtons.YesNo);
            if (NewDialog == DialogResult.Yes)
            {
                // if there was an error, output it
                string ErrorMessage = VehicleType.DeleteVehicleType(Convert.ToInt32(txtVehicleTypeID.Text));
                if (ErrorMessage != null) MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"vehicle type {txtVehicleTypeID.Text} ({txtVehicleTypeName.Text})");
                LoadFormDefaults();
            }
        }
        #endregion
        #region Search

        // update the search field
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e) => _selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;


        // update the datagridview using the search criteria
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvVehicleTypes.DataSource = VehicleType.GetVehicleTypesByField(txtSearch.Text, searchType, _selectedField);
        }
        #endregion
        #region Misc


        // reset the form to its initial state
        private void LoadFormDefaults()
        {
            AttemptDataDisplay();
            txtVehicleTypeName.Clear();
            numComplexity.Value = 0;
            _selectedVehicleType = -1;
        }

        // prevent further editing by disabling all controls related to manipulating or viewing data
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtSearch.Enabled = false;
            txtVehicleTypeID.Enabled = false;
            txtVehicleTypeName.Enabled = false;

            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;

            numComplexity.Enabled = false;

            dgvVehicleTypes.Enabled = false;
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpVehicleTypes frm = new frmHelpVehicleTypes();
            frm.Show();
        }
        #endregion






    }
}
