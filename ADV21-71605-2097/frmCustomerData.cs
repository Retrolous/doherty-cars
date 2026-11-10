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
    public partial class frmCustomerData : Form
    {
        #region Private fields
        // currently selected customer ID (-1 indicates none selected)
        private int _selectedCustomer = -1;
        // currently selected field to search by (default is "Firstname")
        private string _selectedField = "Firstname";
        // list of fields to be displayed within the search field ComboBox
        private List<ComboBoxItem> _fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Customer ID", "CustomerID"),
            new ComboBoxItem("First name", "Firstname"),
            new ComboBoxItem("Surname", "Surname"),
            new ComboBoxItem("Email", "Email"),
            new ComboBoxItem("Phone number", "PhoneNumber")
        };
        #endregion
        public frmCustomerData()
        {
            InitializeComponent();
        }

        #region Create
        // add a new customer with the provided details
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure that the currently selected user has at least "Restricted Write" permission 
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure that the customer details adhere to the validation set out by the customer class
            List<string> ValidationErrors = Customer.ValidateCustomer(
                0,
                txtFirstname.Text,
                txtSurname.Text,
                txtEmail.Text,
                txtPhoneNumber.Text);

            // if there are any errors, output them and cancel
            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors when attempting to save the customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // attempt to create a new customer object with the provided details
                Customer NewCustomer = new Customer(0, txtFirstname.Text, txtSurname.Text, txtEmail.Text, txtPhoneNumber.Text);

                // if that works, attempt to add the customer to the database
                string AddingMessage = Customer.AddCustomer(NewCustomer);

                // no error message has been output
                if (AddingMessage == null)
                {
                    MessageBox.Show("Customer has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ensure adding is only logged when successful - prevents logs regarding non-existent records
                    Logging.WriteLog(Logging.LogType.Create, $"customer ({txtFirstname.Text} {txtSurname.Text})");
                }
                else
                {
                    string MessageboxText = "Customer has not been added:\n" + AddingMessage;
                    MessageBox.Show(MessageboxText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adding was unsuccessful with the following error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadFormDefaults();  // reset form fields and refresh the data grid view
        }
        #endregion
        #region Retrieve
        private void AttemptDataDisplay()
        {
            // populate the data grid view with the latest version of the customers database stored when the form is loaded
            List<Customer> Result = Customer.RetrieveCustomers();


            // if no customers could be loaded due to a system error (i.e., null was returned instead of an empty list)
            if (Result == null)
            {
                // prevent further modification
                MessageBox.Show("There was an error when attempting to load customer data. Please amend erroneous data in the database before proceeding.");
                LockDownForm();
                return;
            }
            else
            {
                // display the data
                dgvCustomers.DataSource = Result;
            }


            // modify column headers to be more human readable
            dgvCustomers.Columns["CustomerID"].HeaderText = "Customer ID";
            dgvCustomers.Columns["FirstName"].HeaderText = "First Name";
            dgvCustomers.Columns["Surname"].HeaderText = "Last Name";
            dgvCustomers.Columns["Email"].HeaderText = "Email Address";
            dgvCustomers.Columns["PhoneNumber"].HeaderText = "Phone Number";

            // resize the columns to match the data length
            dgvCustomers.AutoResizeColumns();
        }

        // when loading the form, load data from the database and add search fields to the search field combobox
        private void frmCustomerData_Load(object sender, EventArgs e)
        {
            AttemptDataDisplay();
            foreach (ComboBoxItem field in _fields) comboSearchField.Items.Add(field);

            comboSearchField.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;
        }

        // when a new customer is selected
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // if there are customers
            if (dgvCustomers.RowCount > 0)
            {
                try
                {
                    // retrieve the selected user using their id (the first column)
                    Customer Edit = Customer.RetrieveByCustomerID(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value));

                    // if there is a customer with that id, load their data
                    if (Edit != null)
                    {
                        _selectedCustomer = Edit.CustomerID;
                        txtCustomerID.Text = Edit.CustomerID.ToString();
                        txtFirstname.Text = Edit.FirstName;
                        txtSurname.Text = Edit.Surname;
                        txtEmail.Text = Edit.Email;
                        txtPhoneNumber.Text = Edit.PhoneNumber;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select user:\n" + ex);
                }
            }
        }
        #endregion
        #region Update
        // save the selected customer with the new input details
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            // ensure that the currently selected user has at least "Restricted Write" permission 
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);

            // if not, display permission needed and permission currently possessed and cancel
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError);
                return;
            }

            // ensure that a customer has been selected to edit before attempting to push changes
            if (_selectedCustomer == -1)
            {
                MessageBox.Show("Choose a customer to edit");
                return;
            }

            // ensure that the customer details adhere to the validation set out by the customer class
            List<string> ValidationErrors = Customer.ValidateCustomer(
                Convert.ToInt32(txtCustomerID.Text),
                txtFirstname.Text,
                txtSurname.Text,
                txtEmail.Text,
                txtPhoneNumber.Text
                );

            // if there are any errors, output them and cancel
            if (ValidationErrors.Any())
            {   // "- " + error1 + new line + "- " + error2 + new line +...
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure that the user wishes to follow through
            DialogResult NewDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            if (NewDialog == DialogResult.Yes)
            {
                try
                {
                    // as well as the validation previous carried out, a customer object is created to ensure that a valid representation can be created on the system with the provided details
                    string ErrorMessage = Customer.SaveCustomer(new Customer(Convert.ToInt32(txtCustomerID.Text), txtFirstname.Text, txtSurname.Text, txtEmail.Text, txtPhoneNumber.Text));

                    if (ErrorMessage != null)
                        MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Successfully updated customer");

                    // log the update, whether successful or not, with the old and new details stored
                    Logging.WriteLog(Logging.LogType.Update, "customer " + $"{txtCustomerID.Text} ({txtFirstname.Text} {txtSurname.Text})");

                    // refresh the data in the table with the updated record
                    LoadFormDefaults();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save was unsuccessful with the following error message:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ensure that the currently selected user has at least "Unrestricted Write" permission 
            string PermissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 2);
            if (PermissionError != null)
            {
                MessageBox.Show(PermissionError);
                return;
            }

            // ensure that a customer has been selected to be deleted
            if (_selectedCustomer == -1)
            {
                MessageBox.Show("Select a customer to delete.");
                return;
            }

            DialogResult NewDialog = MessageBox.Show("Are you sure you wish to delete the selected record? This action will cascade through other tables.", "Warning!", MessageBoxButtons.YesNo);
            if (NewDialog == DialogResult.Yes)
            {
                string ErrorMessage = Customer.DeleteCustomer(Convert.ToInt32(txtCustomerID.Text));
                // if unsuccessful
                if (ErrorMessage != null) MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"customer {txtCustomerID.Text} ({txtFirstname.Text} {txtSurname.Text})"); // if successful
                LoadFormDefaults();
            }
        }
        #endregion
        #region Search
        // update the field to search
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e) => _selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;

        // update the table to have search the database against the latest search substring provided
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // modify the name of the type of query to be made, then update the form with that query
            string SearchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvCustomers.DataSource = Customer.RetrieveCustomersByField(txtSearch.Text, SearchType, _selectedField);
        }
        #endregion
        #region Misc
        private void LoadFormDefaults()
        {
            // resets form fields and refreshes the data grid view
            AttemptDataDisplay();
            txtFirstname.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            _selectedCustomer = -1;
        }

        // prevents further modification of data by disabling all controls which allow for it
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtFirstname.Enabled = false;
            txtSurname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhoneNumber.Enabled = false;

            txtCustomerID.Enabled = false;

            txtSearch.Enabled = false;
            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;

            dgvCustomers.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset the fields by setting everything to its default state
            LoadFormDefaults();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // display the help form
            frmHelpCustomers frm = new frmHelpCustomers();
            frm.Show();
        }
        #endregion







    }
}
