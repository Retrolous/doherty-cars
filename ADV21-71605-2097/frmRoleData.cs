using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmRoleData : Form
    {
        #region Form properties
        // currently selected role ID
        private int selectedRole = -1;
        // the field to be searched
        private string selectedField = "Name";
        // the fields that can be searched
        private List<ComboBoxItem> fields = new List<ComboBoxItem>
        {
            new ComboBoxItem("Role ID", "RoleID"),
            new ComboBoxItem("Role Name", "Name"),
            new ComboBoxItem("Sector", "Sector"),
            new ComboBoxItem("Authorisation Level", "AuthorisationLevel")
        };
        #endregion
        public frmRoleData()
        {
            InitializeComponent();
        }

        #region Create

        // attempt to add the role to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ensure at least "Restricted Write" access before attempting to add
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // carry out basic validation on the role
            List<string> validationErrors = Role.ValidateRole(
                txtName.Text,
                int.Parse(((comboAuthorisationLevel.SelectedItem as ComboBoxItem).HiddenValue)),
                comboSector.Text);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // attempt to add the new role object to the database
                Role newRole = new Role(
                0,
                txtName.Text,
                int.Parse(((comboAuthorisationLevel.SelectedItem as ComboBoxItem).HiddenValue)),
                comboSector.Text);

                string addResult = Role.AddRole(newRole);
                if (addResult == null)
                {
                    MessageBox.Show("Role added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"role ({txtName.Text})");
                }
                else
                    MessageBox.Show("Role could not be added:\n" + addResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmRoleData_Load(object sender, EventArgs e)
        {
            // add the search fields
            foreach (ComboBoxItem field in fields) comboSearchField.Items.Add(field);
            InitialiseAuthorisation();
            AttemptDataDisplay();

            comboSearchField.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;
            comboAuthorisationLevel.SelectedIndex = 0;
            comboSector.SelectedIndex = 0;


        }

        private void AttemptDataDisplay()
        {
            List<Role> result = Role.RetrieveRoles();
            if (result == null)
            {
                MessageBox.Show("There was an error attempting to load roles. Please amend erroneous data in the database before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }
            else
            {
                dgvRoles.DataSource = result;
            }

            dgvRoles.Columns["AuthorisationLevel"].HeaderText = "Authorisation Level";
            dgvRoles.AutoResizeColumns();
        }

        // if a new role has been selected
        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.RowCount > 0)
            {

                try
                {
                    // retrieve that role's details and populate the form
                    Role selected = Role.RetrieveByRoleID(Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value));
                    if (selected != null)
                    {
                        selectedRole = selected.RoleID;
                        txtRoleID.Text = selected.RoleID.ToString();
                        txtName.Text = selected.Name;
                        comboSector.SelectedItem = comboSector.Items.Cast<string>().Where((ex) => ex.ToString() == selected.Sector).FirstOrDefault();
                        comboAuthorisationLevel.SelectedIndex = selected.AuthorisationLevel;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to select role: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        #endregion
        #region Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ensure at least "Restricted Write" access before attempting to update a role
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if no role has been selected
            if (selectedRole == -1)
            {
                MessageBox.Show("Select a role to edit.");
                return;
            }


            // carry out basic validation on the role details
            List<string> validationErrors = Role.ValidateRole(
                txtName.Text,
                int.Parse((comboAuthorisationLevel.SelectedItem as ComboBoxItem).HiddenValue),
                comboSector.Text);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                string errorMessage = null;
                try
                {
                    // attempt to save the new role object
                    errorMessage = Role.SaveRole(new Role(
                Convert.ToInt32(txtRoleID.Text),
                txtName.Text,
                int.Parse(((comboAuthorisationLevel.SelectedItem as ComboBoxItem).HiddenValue)),
                comboSector.Text));
                    if (errorMessage != null) MessageBox.Show(errorMessage);
                    else MessageBox.Show("Successfully updated role", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logging.WriteLog(Logging.LogType.Update, $"role {txtRoleID.Text} ({txtName.Text})");
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

        // attempt to delete the role from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ensure at least "Restricted Write" access
            string permissionError = Role.CheckAuthorised(CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel(), 1);
            if (permissionError != null)
            {
                MessageBox.Show(permissionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ensure a role has been selected
            if (selectedRole == -1)
            {
                MessageBox.Show("Select a role to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;


            // display a message if unsuccessful
            string errorMessage = Role.DeleteRole(selectedRole);
            if (errorMessage != null) MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Logging.WriteLog(Logging.LogType.Delete, $"role {txtRoleID.Text} ({txtName.Text})");
            LoadFormDefaults();
        }

        #endregion
        #region Search
        // if the field to be searched has changed
        private void comboSearchField_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedField = ((ComboBoxItem)comboSearchField.SelectedItem).HiddenValue;
        }

        // update the datagridview with the results from the query involving the most up-to-date query substring
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchType = (comboSearchType.SelectedItem?.ToString() == "Exact") ? "Exact" : "Contains";
            dgvRoles.DataSource = Role.GetRolesByField(txtSearch.Text, searchType, selectedField);
        }
        #endregion
        #region Misc
        // prevent further modification or querying by disabling appropriate controls
        private void LockDownForm()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;

            txtName.Enabled = false;
            txtRoleID.Enabled = false;
            txtSearch.Enabled = false;

            comboAuthorisationLevel.Enabled = false;
            comboSearchField.Enabled = false;
            comboSearchType.Enabled = false;
            comboSector.Enabled = false;

            dgvRoles.Enabled = false;
        }

        // add authorisation levels to the combobox
        private void InitialiseAuthorisation()
        {
            comboAuthorisationLevel.Items.Clear();
            comboAuthorisationLevel.Items.Add(new ComboBoxItem("0 - Read-only", "0"));
            comboAuthorisationLevel.Items.Add(new ComboBoxItem("1 - Restricted write", "1"));
            comboAuthorisationLevel.Items.Add(new ComboBoxItem("2 - Unrestricted write", "2"));
            comboAuthorisationLevel.SelectedIndex = 0;
        }

        // reset the form to its initial state
        private void LoadFormDefaults()
        {
            AttemptDataDisplay();

            txtRoleID.Clear();
            txtName.Clear();
            comboSector.SelectedIndex = 0;
            comboAuthorisationLevel.SelectedIndex = 0;
            selectedRole = -1;


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFormDefaults();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpRoles frm = new frmHelpRoles();
            frm.Show();

        }
        #endregion



    }
}
