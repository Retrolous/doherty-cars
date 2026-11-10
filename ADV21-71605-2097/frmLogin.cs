using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Login logic
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // username is converted to lowercase for simplicity, but password is not for case sensitivty - ensure security
            string Username = txtUsername.Text.ToLower().Trim();
            string Password = txtPassword.Text.Trim();

            if (!LoginValidation(Username, Password))
                return; // stop if basic validation fails.

            // attempt to authenticate user
            Staff NewStaff = Staff.Login(Username, Password);

            // if the login method executed successfully and a user was returned, store that user's details in memory, log the login and continue to the main menu
            if (NewStaff != null)
            {
                CurrentUser.CurrentLoggedInUser = NewStaff;
                Logging.WriteLog(Logging.LogType.Login, null);
                frmMainMenu newMainMenu = new frmMainMenu();
                newMainMenu.Show();
                this.Hide();
            }
            else // else output an error message, log a failed attempt and clear fields
            {
                // check if no staff members were found because of a server error or just because of incorrect credentials
                if (Staff.RetrieveStaffMembers() != null)
                    MessageBox.Show("Incorrect username or password, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // log unsuccessful login attempt using the username, removing "[" and "]" which are used in the logs file to delineate the time and log type sections
                Logging.WriteLog(Logging.LogType.LoginAttempt, txtUsername.Text.Replace("[", "").Replace("]", ""));
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();

            }
        }

        // when the form is loaded, ensuring that any previous details in memory have been cleared to prevent session clashes
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CurrentUser.CurrentLoggedInUser = null;
        }

        // ensure the user inputs valid data in the fields
        public bool LoginValidation(string username, string password)
        {
            // if both fields are blank
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Sorry, you cannot leave username and password blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // if only one field is blank
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Sorry, you cannot leave username blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Sorry, you cannot leave password blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // if the username is not alphanumeric or with underscores
            if (!Regex.IsMatch(username, @"^[a-z0-9_.]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, underscores and full stops.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // if the username is too short/long
            if (username.Length < 3 || username.Length > 50)
            {
                MessageBox.Show("Username must be between 3 and 50 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // if the password is too short/long
            if (password.Length < 8 || password.Length > 128)
            {
                MessageBox.Show("Password must be between 8 and 128 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // listen for the enter key to ensure that pressing enter will trigger a login attempt regardless of selected field
        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnLogin_Click(sender, e);
        }
        #endregion
        #region Misc logic
        private void chkToggleHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToggleHide.Checked == true)
            {
                // make the password visible if checked
                txtPassword.PasswordChar = '\0';
                txtPassword.ForeColor = Color.Black;
            }
            else
            {
                // obfuscate the password if unchecked
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.DarkGray;
            }
        }

        // populate fields with existing user information for testing
        private void btnUser1_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "patdoh";
            txtPassword.Text = "Password1.";
        }

        private void btnUser2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "ethanh1";
            txtPassword.Text = "ethanh1.";
        }

        private void btnUser3_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "ellar";
            txtPassword.Text = "financial";
        }
        #endregion

    }
}
