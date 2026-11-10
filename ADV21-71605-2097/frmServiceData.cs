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
    public partial class frmServiceData : Form
    {
        #region Form properties
        // currently selected staff member ID (-1 indicates none selected)
        private int selectedService = -1;
        // currently selected field to search by (default is "Firstname")
        private string selectedField = "Name";

        // fields that can be searched
        private List<ComboBoxItem> fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Service ID", "ServiceID"),
            new ComboBoxItem("Name", "Name"),
            new ComboBoxItem("Description", "Description"),
            new ComboBoxItem("Duration Hours", "DurationHours"),
            new ComboBoxItem("Price", "Price"),
        };
        #endregion
        public frmServiceData()
        {
            InitializeComponent();
        }

        #region Create
        // attempt to add a new service to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure the user has at least "Restricted Write" access
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // perform basic validation on the service details
            List<string> validationErrors = Service.ValidateService(0, txtName.Text, txtDescription.Text, Convert.ToInt32(numDuration.Value), numPrice.Value);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                // create a new service object and attempt to save it, outputting any error messages
                Service newService = new Service(0, txtName.Text, txtDescription.Text, (int)numDuration.Value, numPrice.Value);

                string addingMessage = Service.AddService(newService);

                if (addingMessage == null)
                {
                    MessageBox.Show("Service has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"service ({txtName.Text})");
                }
                else
                {
                    string messageboxValue = "Service was not added:\n" + addingMessage;
                    MessageBox.Show(messageboxValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding new service:\n- " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadFormDefaults();
        }
        #endregion
        #region Retrieve
        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.RowCount > 0)
            {

                try
                {
                    // retrieve the service from the database and populate the fields with its values
                    Service edit = Service.RetrieveByServiceID(Convert.ToInt32(dgvServices.CurrentRow.Cells[0].Value));
                    // prevents errors if the last record is deleted
                    if (edit != null)
                    {
                        selectedService = edit.ServiceID;
                        txtServiceID.Text = edit.ServiceID.ToString();
                        txtName.Text = edit.Name;
                        numPrice.Value = (decimal)edit.Price;
                        numDuration.Value = (decimal)edit.DurationHours;
                        txtDescription.Text = edit.Description;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select service: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void frmServiceData_Load(object sender, EventArgs e)
        {
            AttemptDataDisplay();
            // add each field to the combobox
            foreach (ComboBoxItem field in fields) comboSearchField.Items.Add(field);

            comboSearchField.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;
        }


        private void AttemptDataDisplay()
        {
            List<Service> result = Service.RetrieveServices();
            if (result == null)
            {
                MessageBox.Show("There was an error attempting to load service data. Please amend erroneous data in the database before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            else
            {
                dgvServices.DataSource = result;
            }

            dgvServices.Columns["DurationHours"].HeaderText = "Duration in Hours";

            dgvServices.AutoResizeColumns();
        }
        #endregion
        #region Update
        // attempt to save service to the database
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ensure the current user has at least "Restricted Write" access 
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure that a service has been chosen to edit
            if (selectedService == -1)
            {
                MessageBox.Show("Choose a service to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // perform basic validation on the details to be inserted
            List<string> validationErrors = Service.ValidateService(Convert.ToInt32(txtServiceID.Text), txtName.Text, txtDescription.Text, Convert.ToInt32(numDuration.Value), numPrice.Value);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors when attempting to save the service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            string errorMessage = null;
            if (newDialog == DialogResult.Yes)
            {

                try
                {
                    // attempt to save the service, outputting any error messages that arise
                    errorMessage = Service.SaveService(new Service(Convert.ToInt32(txtServiceID.Text), txtName.Text, txtDescription.Text, (int)numDuration.Value, numPrice.Value));
                    if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Successfully updated service", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logging.WriteLog(Logging.LogType.Update, $"service {txtServiceID.Text} ({txtName.Text})");
                    LoadFormDefaults();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error attempting to update the service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Delete

        // attempt to delete the selected service from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ensure at least "Restricted Write" access
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure a service has been selected
            if (selectedService == -1)
            {
                MessageBox.Show("Select a service to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult newDialog = MessageBox.Show("Are you sure you wish to delete the selected record?", "Warning!", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                // attempt to delete, outputting any error messages
                string errorMessage = Service.DeleteService(Convert.ToInt32(txtServiceID.Text));
                if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"service {txtServiceID.Text} ({txtName.Text})");
                LoadFormDefaults();
            }
        }

        #endregion
        #region Search
        // update the datagridview with query using the latest search substring
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvServices.DataSource = Service.GetServicesByField(txtSearch.Text, searchType, selectedField);
        }



        // if the field to search has changed
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e) => selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;
        #endregion
        #region Misc
        // update the character counter
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblRemainingCharacters.Text = $"Remaining characters: {500 - txtDescription.Text.Length}";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpServices frm = new frmHelpServices();
            frm.Show();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }

        private void LoadFormDefaults()
        {
            // reset the form to its default parameters to ensure a clean slate before attempting any updates or modifications
            AttemptDataDisplay();
            txtName.Clear();
            txtDescription.Clear();
            numDuration.Value = 1;
            numPrice.Value = 0;
            txtServiceID.Clear();
            selectedService = -1;
        }

        // prevent further editing and querying of data by disabling appropriate controls
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtDescription.Enabled = false;
            txtName.Enabled = false;
            txtSearch.Enabled = false;
            txtServiceID.Enabled = false;

            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;

            numDuration.Enabled = false;
            numPrice.Enabled = false;

            dgvServices.Enabled = false;
        }
        #endregion







      

        

        
    }
}
