using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmStartingMainMenuForm : Form
    {
        public frmStartingMainMenuForm()
        {
            InitializeComponent();
        }

        private void frmStartingMainMenuForm_Load(object sender, EventArgs e)
        {
           

            // display the current time
            lblDate.Text = "It is " + DateTime.Now.ToLongDateString();

            // attempt to display the current user's name
            if (CurrentUser.CurrentLoggedInUser != null) lblWelcomeMessage.Text = "Welcome, " + CurrentUser.CurrentLoggedInUser.Firstname;
            else
            {
                MessageBox.Show("Your name could not be retrieved. Please ensure you have logged in correctly.");
                return;
            }

            // attempt to display the user's role
            var role = Role.RetrieveByRoleID(CurrentUser.CurrentLoggedInUser.RoleID);

            if(role == null)
            {
                MessageBox.Show("Your role could not be retrieved.");
                return;
            }

            lblRole.Text = "You are logged in as a(n) " + role.Name;
        }
    }
}
