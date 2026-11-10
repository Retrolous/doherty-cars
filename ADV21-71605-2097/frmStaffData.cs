using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmStaffData : Form
    {
        #region Form properties
        // currently selected staff member ID (-1 indicates none selected)
        private int _selectedStaff = -1;
        // currently selected field to search by (default is "Firstname")
        private string _selectedField = "Firstname";
        // fields that can be searched
        private List<ComboBoxItem> _fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Staff ID", "StaffID"),
            new ComboBoxItem("First name", "Firstname"),
            new ComboBoxItem("Surname", "Surname"),
            new ComboBoxItem("Role ID", "RoleID")
        };
        public frmStaffData()
        {
            InitializeComponent();
        }
        #endregion
        #region Create


        // attempt to add a new staff member to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure that user has at least "Unrestricted Write" access before attempting to make the change
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 2);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // carry out basic validation
            List<string> validationErrors = Staff.ValidateStaff(0, txtFirstname.Text, txtSurname.Text, txtUsername.Text, Convert.ToInt32(((ComboBoxItem)(comboRoleID.SelectedItem)).HiddenValue), txtPassword.Text);

            if (String.IsNullOrWhiteSpace(txtPassword.Text)) validationErrors.Add("Password cannot be empty.");

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors when attempting to save the staff member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // attempt to add the new staff member object
                Staff newStaff = new Staff(0, txtFirstname.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, Convert.ToInt32(((ComboBoxItem)(comboRoleID.SelectedItem)).HiddenValue));

                if (!IsUsernameUnique(txtUsername.Text, 0))
                {
                    // ensure clashing usernames cannot be saved
                    MessageBox.Show("Username already exists. Choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string addingMessage = Staff.AddStaff(newStaff);

                if (addingMessage == null)
                {
                    MessageBox.Show("Staff member has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"staff member ({txtFirstname.Text} {txtSurname.Text})");
                }
                else
                {
                    string messageboxValue = "Staff member not added:\n" + addingMessage;
                    MessageBox.Show(messageboxValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadFormDefaults();
        }
        #endregion
        #region Retrieve
        private void frmStaffData_Load(object sender, EventArgs e)
        {
            PopulateRoles();
            AttemptDataDisplay();
            // add each search field to the appropriate combobox
            foreach (ComboBoxItem field in _fields) comboSearchField.Items.Add(field);

            comboSearchType.SelectedIndex = 0;
            comboSearchField.SelectedIndex = 0;
        }



        // attempt to display staff data
        private void AttemptDataDisplay()
        {
            List<Staff> result = Staff.RetrieveStaffMembers();
            if (result == null)
            {
                MessageBox.Show("There was an error attempting to load staff data. Please amend erroneous data in the database before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            else
            {
                dgvStaff.DataSource = result;
            }

            dgvStaff.Columns["StaffID"].HeaderText = "Staff ID";
            dgvStaff.Columns["FirstName"].HeaderText = "First name";
            dgvStaff.Columns["Surname"].HeaderText = "Surname";
            dgvStaff.Columns["Username"].HeaderText = "Username";
            dgvStaff.Columns["Password"].HeaderText = "Password";
            dgvStaff.Columns["RoleID"].HeaderText = "Role ID";

            dgvStaff.AutoResizeColumns();
        }

        // if a new staff member has been selected
        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            // if there are staff members loaded
            if (dgvStaff.RowCount > 0)
            {
                try
                {
                    Staff edit = Staff.RetrieveByStaffID(Convert.ToInt32(dgvStaff.CurrentRow.Cells[0].Value));
                    // retrieve that staff member and populate fields with appropriate values
                    if (edit != null)
                    {
                        _selectedStaff = edit.StaffID;
                        txtStaffID.Text = edit.StaffID.ToString();
                        txtFirstname.Text = edit.Firstname;
                        txtSurname.Text = edit.Surname;
                        comboRoleID.SelectedItem = comboRoleID.Items
                       .Cast<ComboBoxItem>()
                       .Where(g => Convert.ToInt32(g.HiddenValue) == edit.RoleID)
                       .FirstOrDefault();
                        txtUsername.Text = edit.Username;
                        txtPassword.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select user:\n- " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void PopulateRoles()
        {
            List<Role> Roles = Role.RetrieveRoles();
            if (Roles == null || Roles.Count == 0)
            {
                MessageBox.Show("Error loading roles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            foreach (Role Role in Roles)
            {
                // add each role to the appropriate combobox
                comboRoleID.Items.Add(new ComboBoxItem($"{Role.Name} - {Role.RoleID}", Convert.ToString(Role.RoleID)));
            }

            comboRoleID.SelectedIndex = 0;
        }
        #endregion
        #region Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ensure the current user has at least "Restricted Write" access before modifying staff members
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure a staff member has been chosen
            if (_selectedStaff == -1)
            {
                MessageBox.Show("Choose a staff member to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // carry out basic validation on the staff details
            List<string> validationErrors = Staff.ValidateStaff(Convert.ToInt32(txtStaffID.Text), txtFirstname.Text, txtSurname.Text, txtUsername.Text, Convert.ToInt32(((ComboBoxItem)(comboRoleID.SelectedItem)).HiddenValue), txtPassword.Text);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors when attempting to save the staff member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if a non-unique username was entered
            if (!IsUsernameUnique(txtUsername.Text, Convert.ToInt32(txtStaffID.Text)))
            {
                // ensure clashing usernames cannot be saved
                MessageBox.Show("Username already exists. Choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                string errorMessage = null;
                try
                {
                    // attempt to save the staff member, outputting an error message if unsuccessful
                    errorMessage = Staff.SaveStaff(new Staff(Convert.ToInt32(txtStaffID.Text), txtFirstname.Text, txtSurname.Text, txtUsername.Text, (txtPassword.Text == "" ? "" : HashPassword(txtPassword.Text)), Convert.ToInt32(((ComboBoxItem)(comboRoleID.SelectedItem)).HiddenValue)));

                    if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Successfully updated staff", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logging.WriteLog(Logging.LogType.Update, $"staff member {txtStaffID.Text} ({txtFirstname.Text} {txtSurname.Text})");

                    if (CurrentUser.CurrentLoggedInUser.StaffID == int.Parse(txtStaffID.Text)) CurrentUser.CurrentLoggedInUser = Staff.RetrieveByStaffID(int.Parse(txtStaffID.Text));

                    LoadFormDefaults();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

            }
        }
        #endregion
        #region Delete
        // attempt to delete the selected staff member 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ensure that user has at least "Unrestricted Write" access before attempting to make the change
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 2);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if no user has been selected
            if (_selectedStaff == -1)
            {
                MessageBox.Show("Select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if the currently logged in user tries to delete themselves
            if (_selectedStaff == CurrentUser.CurrentLoggedInUser.StaffID)
            {
                MessageBox.Show("You cannot delete the user that is currently logged-in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult newDialog = MessageBox.Show("Are you sure you wish to delete the selected record?", "Warning!", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                // attempt to delete, outputting an error message if unsuccessful
                string errorMessage = Staff.DeleteStaff(Convert.ToInt32(txtStaffID.Text));
                if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"staff member {txtStaffID.Text} ({txtFirstname.Text} {txtSurname.Text})");
                LoadFormDefaults();
            }
        }
        #endregion
        #region Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // modify the name of the type of query to be made, then update the form with that query
            string searchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvStaff.DataSource = Staff.GetStaffByField(txtSearch.Text, searchType, _selectedField);
        }


        // update the field to be searched
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e) => _selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;
        #endregion
        #region Misc
        private string HashPassword(string plainPassword)
        {
            // create a 16-byte salt
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // use PBKDF2 to hash the password along with the salt
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 75623);
            byte[] hash = pbkdf2.GetBytes(20);

            // combine the salt and hash bytes
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // convert the combined salt and hash to a base64 string
            return Convert.ToBase64String(hashBytes);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpStaff frm = new frmHelpStaff();
            frm.Show();

        }

        // prevent further editing or querying of data by disabling appropriate controls
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtFirstname.Enabled = false;
            txtPassword.Enabled = false;
            txtSearch.Enabled = false;
            txtStaffID.Enabled = false;
            txtSurname.Enabled = false;
            txtUsername.Enabled = false;

            comboRoleID.Enabled = false;
            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;

            dgvStaff.Enabled = false;
        }

        // prevent modification or querying of data by disabling appropriate controls
        private void LoadFormDefaults()
        {
            // reset the form to its default parameters to ensure a clean slate before attempting any updates or modifications
            AttemptDataDisplay();
            txtFirstname.Clear();
            txtPassword.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            txtStaffID.Clear();
            comboRoleID.SelectedIndex = 0;
            _selectedStaff = -1;
        }


        // check if any other staff member on the system has the same username
        private bool IsUsernameUnique(string Username, int StaffID)
        {
            string query = "SELECT * FROM Staff WHERE Username = @Username AND StaffID <> @StaffID";

            try
            {
                using (var connection = DBConnect.ConnectionToDB())
                using (var dataAdapter = new SqlDataAdapter(query, connection))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Username", Username.Trim());
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@StaffID", StaffID);
                    DataTable dataResult = new DataTable();
                    dataAdapter.Fill(dataResult);

                    // if there are any records with the username and but not the staff id
                    return (dataResult.Rows.Count > 0) ? false : true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query unsuccessful. Please contact the administrator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion



       
       
    }
}
