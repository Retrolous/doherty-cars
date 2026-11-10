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
    public partial class frmVehicleData : Form
    {
        #region Form properties
        // the vehicle selected to be edited
        private int _selectedVehicle = -1;
        // the field to be searched
        private string _selectedField = "Make";
        // the fields that can be searched
        private List<ComboBoxItem> _fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Vehicle ID", "VehicleID"),
            new ComboBoxItem("Vehicle Type ID", "VehicleTypeID"),
            new ComboBoxItem("Customer ID", "CustomerID"),
            new ComboBoxItem("Make", "Make"),
            new ComboBoxItem("Year", "Year"),
            new ComboBoxItem("VIN", "VIN"),
            new ComboBoxItem("License Plate", "LicensePlate"),
            new ComboBoxItem("Condition", "Condition"),
            new ComboBoxItem("Available", "Available"),
            new ComboBoxItem("Inspected", "Inspected"),
            new ComboBoxItem("Buy Price", "BuyPrice"),
            new ComboBoxItem("Sell Price", "SellPrice"),
            new ComboBoxItem("Storage Location", "StorageLocation"),
        };
        #endregion
        public frmVehicleData()
        {
            InitializeComponent();
        }
        #region Create
        // attempt to add the new vehicle to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure the user has at least "Restricted Write" access before attempting to add
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate the vehicle details
            List<string> validationErrors = Vehicle.ValidateVehicleFields(
                0,
                Convert.ToInt32(((ComboBoxItem)comboVehicleTypeID.SelectedItem).HiddenValue),
                comboCustomerID.SelectedIndex == 0
                    ? (int?)null
                    : Convert.ToInt32(((ComboBoxItem)comboCustomerID.SelectedItem).HiddenValue),
                txtMake.Text,
                txtModel.Text,
                chkYearUnknown.Checked ? (int?)null : (int)numYear.Value,
                txtVIN.Text,
                string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text,
                comboCondition.SelectedItem.ToString(),
                chkAvailable.Checked,
                chkInspected.Checked,
                (double)numBuyPrice.Value,
                (double)numSellPrice.Value,
                comboStorageLocation.SelectedItem.ToString()
            );


            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors when attempting to save the vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // attempt to add the new vehicle to the database
                Vehicle newVehicle = new Vehicle(
                0,
                 Convert.ToInt32(((ComboBoxItem)comboVehicleTypeID.SelectedItem).HiddenValue),
                 comboCustomerID.SelectedIndex == 0 ? (int?)null : Convert.ToInt32(((ComboBoxItem)comboCustomerID.SelectedItem).HiddenValue),
                 txtMake.Text,
                 txtModel.Text,
                 chkYearUnknown.Checked ? (int?)null : (int)numYear.Value,
                 txtVIN.Text,
                 string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text,
                 comboCondition.SelectedItem.ToString(),
                 chkAvailable.Checked,
                 chkInspected.Checked,
                 (double)numBuyPrice.Value,
                 (double)numSellPrice.Value,
                 (comboStorageLocation.SelectedItem.ToString() == "None") ? null : comboStorageLocation.SelectedItem.ToString()
                 );
                string addingMessage = Vehicle.AddVehicle(newVehicle);
                if (addingMessage == null)
                {
                    MessageBox.Show("Vehicle has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"vehicle ({txtMake.Text} {txtModel.Text})");
                }
                else
                {
                    string messageboxText = "Vehicle has not been added:\n" + addingMessage;
                    MessageBox.Show(messageboxText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when attempting to create the vehicle in memory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadFormDefaults();  // reset form fields and refresh the data grid view
        }
        #endregion
        #region Retrieve
        private void AttemptDataDisplay()
        {
            List<Vehicle> result = Vehicle.RetrieveVehicles();
            // populate the data grid view with the latest version of the vehicles database stored when the form is loaded
            if (result == null)
            {
                MessageBox.Show("There was an error when attempting to load vehicle data. Please amend erroneous data in the database before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            else
            {
                dgvVehicles.DataSource = result;
            }

            // set custom column headers
            dgvVehicles.Columns["VehicleID"].HeaderText = "Vehicle ID";
            dgvVehicles.Columns["VehicleTypeID"].HeaderText = "Vehicle Type";
            dgvVehicles.Columns["CustomerID"].HeaderText = "Customer ID";
            dgvVehicles.Columns["Make"].HeaderText = "Make";
            dgvVehicles.Columns["Model"].HeaderText = "Model";
            dgvVehicles.Columns["Year"].HeaderText = "Year";
            dgvVehicles.Columns["VIN"].HeaderText = "VIN";
            dgvVehicles.Columns["LicensePlate"].HeaderText = "License Plate";
            dgvVehicles.Columns["Condition"].HeaderText = "Condition";
            dgvVehicles.Columns["Available"].HeaderText = "Available";
            dgvVehicles.Columns["Inspected"].HeaderText = "Inspected";
            dgvVehicles.Columns["BuyPrice"].HeaderText = "Buy Price";
            dgvVehicles.Columns["SellPrice"].HeaderText = "Sell Price";
            dgvVehicles.Columns["StorageLocation"].HeaderText = "Storage Location";

            dgvVehicles.AutoResizeColumns();


        }

        private void frmVehicleData_Load(object sender, EventArgs e)
        {
            PopulateCustomers();
            PopulateVehicleTypeIDs();
            AttemptDataDisplay();
            foreach (ComboBoxItem field in _fields) comboSearchField.Items.Add(field);

            comboSearchType.SelectedIndex = 0;
            comboSearchField.SelectedIndex = 0;
        }

        private void PopulateCustomers()
        {
            List<Customer> Customers = Customer.RetrieveCustomers();
            if (Customers == null)
            {
                MessageBox.Show("No customers could be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            comboCustomerID.Items.Add(new ComboBoxItem("No customer", null));


            // add each customer to the combobox, with their full name and id
            foreach (Customer Customer in Customers)
            {
                comboCustomerID.Items.Add(new ComboBoxItem($"{Customer.FirstName} {Customer.Surname} - {Customer.CustomerID}", Convert.ToString(Customer.CustomerID)));
            }

            comboCustomerID.SelectedIndex = 0;
        }

        private void PopulateVehicleTypeIDs()
        {
            List<VehicleType> VehicleTypes = VehicleType.RetrieveVehicleTypes();
            if (VehicleTypes == null || VehicleTypes.Count == 0)
            {
                MessageBox.Show("No vehicle types could be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }

            // add each vehicletype to the combobox, with its name and id
            foreach (VehicleType VehicleType in VehicleTypes)
            {
                comboVehicleTypeID.Items.Add(new ComboBoxItem($"{VehicleType.Name} - {VehicleType.VehicleTypeID}", Convert.ToString(VehicleType.VehicleTypeID)));
            }

            comboVehicleTypeID.SelectedIndex = 0;
        }

        // when a new vehicle has been chosen in the datagridview
        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.RowCount > 0)
            {
                try
                {

                    // get the vehicle in question
                    Vehicle edit = Vehicle.RetrieveByVehicleID(Convert.ToInt32(dgvVehicles.CurrentRow.Cells[0].Value));


                    if (edit != null)
                    {
                        txtVehicleID.Text = edit.VehicleID.ToString();

                        // if there is no customer associated with that vehicle, set the index to 0 ("No customer")
                        if (edit.CustomerID == null)
                        {
                            comboCustomerID.SelectedIndex = 0;
                        }
                        else
                        {
                            // find the customer using their id
                            comboCustomerID.SelectedItem = comboCustomerID.Items
                            .Cast<ComboBoxItem>()
                            .Where(g => Convert.ToInt32(g.HiddenValue) == edit.CustomerID)
                            .FirstOrDefault();
                        }

                        // if no year has been provided
                        if (edit.Year == null)
                        {
                            chkYearUnknown.Checked = true;
                            numYear.Enabled = false;
                        }
                        else
                        {
                            numYear.Value = (int)edit.Year;
                            numYear.Enabled = true;
                            chkYearUnknown.Checked = false;
                        }

                        // find the vehicle's vehicle type
                        comboVehicleTypeID.SelectedItem = comboVehicleTypeID.Items
                            .Cast<ComboBoxItem>()
                            .Where(g => Convert.ToInt32(g.HiddenValue) == edit.VehicleTypeID)
                            .FirstOrDefault();

                        // display the vehicle's license plate or - if that's null - an empty string
                        txtLicensePlate.Text = edit.LicensePlate ?? "";


                        txtMake.Text = edit.Make;
                        txtModel.Text = edit.Model;
                        txtVIN.Text = edit.VIN;

                        // find the condition and selected it
                        comboCondition.SelectedItem = comboCondition.Items
                        .Cast<String>()
                        .Where(g => g == edit.Condition)
                        .FirstOrDefault();

                        chkAvailable.Checked = edit.Available;
                        chkInspected.Checked = edit.Inspected;

                        // find the storage location and select it
                        if (edit.StorageLocation == null)
                        {
                            comboStorageLocation.SelectedItem = comboStorageLocation.Items
                        .Cast<String>()
                        .Where(g => g == "None")
                        .FirstOrDefault();
                        }
                        else
                        {
                            comboStorageLocation.SelectedItem = comboStorageLocation.Items
                        .Cast<String>()
                        .Where(g => g == edit.StorageLocation)
                        .FirstOrDefault();
                        }

                        numBuyPrice.Value = (decimal)edit.BuyPrice;
                        numSellPrice.Value = (decimal)edit.SellPrice;

                        _selectedVehicle = edit.VehicleID;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select vehicle:\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Update
        // attempts to save the updated vehicle into the vehicles table
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ensure the user is permitted to carry the action out first ("Restricted Write" access)
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if no vehicle has been selected
            if (_selectedVehicle == -1)
            {
                MessageBox.Show("Choose a vehicle to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate the input details to ensure that the vehicle would form a valid object
            List<string> ValidationErrors = Vehicle.ValidateVehicleFields(
                Convert.ToInt32(txtVehicleID.Text),
                Convert.ToInt32(((ComboBoxItem)comboVehicleTypeID.SelectedItem).HiddenValue),
                comboCustomerID.SelectedIndex == 0 ? (int?)null : Convert.ToInt32(((ComboBoxItem)comboCustomerID.SelectedItem).HiddenValue),
                txtMake.Text,
                txtModel.Text,
                chkYearUnknown.Checked ? (int?)null : (int)numYear.Value,
                txtVIN.Text,
                string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text,
                comboCondition.SelectedItem.ToString(),
                chkAvailable.Checked,
                chkInspected.Checked,
                (double)numBuyPrice.Value,
                (double)numSellPrice.Value,
                comboStorageLocation.SelectedItem.ToString()
                );

            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors when attempting to save the vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // verify the user wishes to update the selected vehicle
            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            string errorMessage = null;
            if (newDialog == DialogResult.Yes)
            {
                try
                {
                    // try to save the vehicle using the new vehicle information
                    errorMessage = Vehicle.SaveVehicle(new Vehicle(
                    Convert.ToInt32(txtVehicleID.Text),
                    Convert.ToInt32(((ComboBoxItem)comboVehicleTypeID.SelectedItem).HiddenValue),
                    comboCustomerID.SelectedIndex == 0 ? (int?)null : Convert.ToInt32(((ComboBoxItem)comboCustomerID.SelectedItem).HiddenValue),
                    txtMake.Text,
                    txtModel.Text,
                    chkYearUnknown.Checked ? (int?)null : (int)numYear.Value,
                    txtVIN.Text,
                    string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text,
                    comboCondition.SelectedItem.ToString(),
                    chkAvailable.Checked,
                    chkInspected.Checked,
                    (double)numBuyPrice.Value,
                    (double)numSellPrice.Value,
                    (comboStorageLocation.SelectedItem.ToString() == "None") ? null : comboStorageLocation.SelectedItem.ToString()
                    ));
                    if (errorMessage != null) MessageBox.Show(errorMessage);
                    else MessageBox.Show("Successfully updated vehicle", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logging.WriteLog(Logging.LogType.Update, $"vehicle {txtVehicleID.Text} ({txtMake.Text} {txtModel.Text})");
                    LoadFormDefaults();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error attempting to update the vehicle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Delete

        // attempt to delete the vehicle from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if no vehicle has been selected
            if (_selectedVehicle == -1)
            {
                MessageBox.Show("Select a vehicle to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult newDialog = MessageBox.Show("Are you sure you wish to delete the selected record?", "Warning!", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                string errorMessage = Vehicle.DeleteVehicle(Convert.ToInt32(txtVehicleID.Text));
                if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"vehicle {txtVehicleID.Text} ({txtMake.Text} {txtModel.Text})");
                LoadFormDefaults();
            }
        }
        #endregion
        #region Search
        // when the search field is modified
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e) => _selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;



        // update the datagridview as the search subtring is modified
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvVehicles.DataSource = Vehicle.GetVehiclesByField(txtSearch.Text, searchType, _selectedField);
        }
        #endregion
        #region Misc
        // toggle the numericupdown control based on whether the year is known
        private void chkYearUnknown_CheckedChanged(object sender, EventArgs e)
        {
            numYear.Enabled = !(chkYearUnknown.Checked);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpVehicles frm = new frmHelpVehicles();
            frm.Show();
        }
        // prevent further editing/viewing by disabling appropriate controls
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            chkAvailable.Enabled = false;
            chkInspected.Enabled = false;
            chkYearUnknown.Enabled = false;

            numBuyPrice.Enabled = false;
            numSellPrice.Enabled = false;
            numYear.Visible = false;
            numYear.Enabled = false;

            txtLicensePlate.Enabled = false;
            txtMake.Enabled = false;
            txtModel.Enabled = false;
            txtSearch.Enabled = false;
            txtVehicleID.Enabled = false;
            txtVIN.Enabled = false;

            comboCondition.Enabled = false;
            comboCustomerID.Enabled = false;
            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;
            comboStorageLocation.Enabled = false;
            comboVehicleTypeID.Enabled = false;

            dgvVehicles.Enabled = false;
        }
        private void LoadFormDefaults()
        {
            // resets form fields and refreshes the data grid view
            AttemptDataDisplay();
            txtVehicleID.Clear();
            comboVehicleTypeID.SelectedIndex = 0;
            txtLicensePlate.Clear();
            txtMake.Clear();
            txtModel.Clear();
            numYear.Value = 1800;
            numYear.Enabled = true;
            chkYearUnknown.Checked = false;
            txtVIN.Clear();
            comboCondition.SelectedIndex = 0;
            chkAvailable.Checked = false;
            chkInspected.Checked = false;
            comboStorageLocation.SelectedIndex = 0;
            comboCustomerID.SelectedIndex = 0;
            numBuyPrice.Value = 0;
            numSellPrice.Value = 0;

            _selectedVehicle = -1;
        }
        #endregion



    }
}
