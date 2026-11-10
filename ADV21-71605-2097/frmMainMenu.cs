using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmMainMenu : Form
    {
        #region Form fields
        // a dictionary that associates the name of the form with the constructor
        // used when changing between forms to prevent separate methods for each form
        readonly Dictionary<string, Func<Form>> formConstructors = new Dictionary<string, Func<Form>> {
            {"StaffData", () => new frmStaffData()},
            {"CustomerData", () => new frmCustomerData()},
            {"VehicleData", () => new frmVehicleData()},
            {"ServiceData", () => new frmServiceData()},
            {"ServiceAppointments", () => new frmServiceAppointments()},
            {"Reports", () => new frmReports()},
            {"Roles", () => new frmRoleData()},
            {"VehicleTypes", () => new frmVehicleTypeData() },
            {"Parts", () => new frmPartData() },
            {"Main", () => new frmStartingMainMenuForm() },
            {"Logs", () => new frmLogs() },
            {"InProgress", () => new frmInProgress() }
        };

        // dictionary that associates each role to a list of buttons they are permitted to use
        Dictionary<string, List<Button>> AuthorisedButtons;

        // all buttons in the form
        List<Button> FormButtons;
        #endregion
        #region Sidebar fields
        // this is global so that each event mouse event can effectively cancel the other by setting it to cancelling value before restarting the count
        int SineTimeElapsed = 0;

        // normal width and hover width of the panel and buttons 
        const int PanelExpandedWidth = 200;
        const int PanelCollapsedWidth = 82;
        const int ButtonExpandedWidth = 190;
        const int ButtonCollapsedWidth = 65;

        // time taken for the animation
        const int TransitionTimeMilliseconds = 100;

        // flag that determines whether the panel has already been entered
        // ensures no bugs occur when moving onto a button, which the program considers separate from the panel
        bool Entered = false;
        #endregion

        public frmMainMenu()
        {
            InitializeComponent();
        }

        #region Form logic
        // remove the form currently displayed in the viewing panel
        private void ResetFormPanel()
        {
            pnlFormDisplay.Controls.Clear();
        }

        // display the appropriate form based on the name of the form provided to the method
        private void ChangeForm(string formName)
        {
            // regex makes the form name more presentable as you can separate it at capitals
            Logging.WriteLog(Logging.LogType.Access, Regex.Replace(formName, "([a-z])([A-Z])", "$1 $2"));
            ResetFormPanel();

            // validation to ensure the selected form exists
            if (!formConstructors.ContainsKey(formName))
            {
                MessageBox.Show("Form not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // display the selected form
            Form objForm = formConstructors[formName]();
            objForm.TopLevel = false;
            pnlFormDisplay.Controls.Add(objForm);
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }

        private void btnStaffData_Click(object sender, EventArgs e)
        {
            ChangeForm("StaffData");
        }

        private void btnCustomerData_Click(object sender, EventArgs e)
        {
            ChangeForm("CustomerData");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin newForm = new frmLogin();
            newForm.Show();
            this.Hide();
        }

        private void btnVehicleData_Click(object sender, EventArgs e)
        {
            ChangeForm("VehicleData");
        }

        private void btnServiceData_Click(object sender, EventArgs e)
        {
            ChangeForm("ServiceData");
        }

        private void btnServiceAppointments_Click(object sender, EventArgs e)
        {
            ChangeForm("ServiceAppointments");
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // ensure that the main menu cannot be opened without logging in first
            if (CurrentUser.CurrentLoggedInUser == null)
            {

                MessageBox.Show("Session expired. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
                return;
            }

            // attach the hover events to the buttons to ensure that hovering over a button does not cause the panel to collapse
            FormButtons = pnlButtons.Controls.OfType<Button>().ToList();
            foreach (Button button in FormButtons)
            {
                button.MouseEnter += pnlButtons_MouseEnter;
                button.MouseLeave += pnlButtons_MouseLeave;
            }

            ChangeForm("Main");

            // create a new dictionary for role -> permitted buttons, which cannot be initialised outside of the load event
            // as buttons are not initialised when the form is first instantiated
            AuthorisedButtons = new Dictionary<string, List<Button>>
                {
                 {"None", new List<Button>()},
                 {"Administrative",  new List<Button>(){ btnStaffData, btnCustomerData, btnVehicleData, btnServiceAppointments, btnServiceData, btnReports, btnRoleData, btnVehicleTypeData, btnPartData, btnMainMenu, btnLogs, btnEnquiries, btnTestDriveAppointments, btnPointOfSale} },
                 {"Customer Service", new List<Button>(){btnCustomerData, btnReports, btnEnquiries}},
                 {"Technical", new List<Button>(){btnServiceAppointments, btnServiceData, btnVehicleData, btnPartData, btnVehicleTypeData, btnTestDriveAppointments, btnPointOfSale} },
                 {"Finance", new List<Button>(){btnReports, btnPointOfSale}},
                 {"HR", new List<Button>(){ btnLogs, btnEnquiries } }
                };

            var role = Role.RetrieveByRoleID(CurrentUser.CurrentLoggedInUser.RoleID); // get the role of the currently logged-in staff member
            if (role == null || !AuthorisedButtons.ContainsKey(role.Sector)) // if no role was found or the role isn't represented in the dictionary
            {
                MessageBox.Show("Role configuration error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // enable and visually indicate each permitted button
            foreach (Button button in AuthorisedButtons[role.Sector])
            {
                button.Enabled = true;
                button.BackColor = Color.FromArgb(240, 255, 240);
            }


        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ChangeForm("Reports");
        }

        private void btnRoleData_Click(object sender, EventArgs e)
        {
            ChangeForm("Roles");
        }

        private void btnVehicleTypeData_Click(object sender, EventArgs e)
        {
            ChangeForm("VehicleTypes");
        }

        private void btnPartData_Click(object sender, EventArgs e)
        {
            ChangeForm("Parts");
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            ChangeForm("Main");
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            ChangeForm("Logs");
        }

        private void btnEnquiries_Click(object sender, EventArgs e)
        {
            ChangeForm("InProgress");
        }

        private void btnTestDriveAppointments_Click(object sender, EventArgs e)
        {
            ChangeForm("InProgress");
        }

        private void btnPointOfSale_Click(object sender, EventArgs e)
        {
            ChangeForm("InProgress");
        }
        #endregion
        #region Sidebar logic
        // when the panel is entered, trigger the animation counter for expanding
        private void pnlButtons_MouseEnter(object sender, EventArgs e)
        {
            SineTimeElapsed = 0;
            Entered = true;
            tmrTransition.Enabled = true;

        }

        // ditto for collapsing
        private void pnlButtons_MouseLeave(object sender, EventArgs e)
        {
            SineTimeElapsed = 0;
            Entered = false;
            tmrTransition.Enabled = true;

        }

       


        private void toggleButtonTexts(bool textEnabled)
        {
            if (textEnabled)
            {
                foreach (Button button in FormButtons)
                    button.ImageAlign = ContentAlignment.MiddleLeft;

                // manually set each button's text, aligning the image to ensure that the text is readable

                btnStaffData.Text = "Staff";
                btnCustomerData.Text = "Customers";
                btnVehicleData.Text = "Vehicles";
                btnServiceData.Text = "Services";
                btnServiceAppointments.Text = "Service Appointments";
                btnLogs.Text = "Logs";
                btnVehicleTypeData.Text = "Vehicle Types";
                btnEnquiries.Text = "Enquiries";
                btnTestDriveAppointments.Text = "Test Drive Appointments";
                btnReports.Text = "Reports";
                btnPartData.Text = "Parts";
                btnRoleData.Text = "Roles";
            }
            else
            {
                foreach (Button button in FormButtons)
                    button.ImageAlign = ContentAlignment.MiddleCenter;

                // clear each button's text

                btnStaffData.Text = "";            
                btnCustomerData.Text = "";
                btnVehicleData.Text = "";
                btnServiceData.Text = "";
                btnServiceAppointments.Text = "";
                btnLogs.Text = "";
                btnVehicleTypeData.Text = "";
                btnEnquiries.Text = "";
                btnReports.Text = "";
                btnTestDriveAppointments.Text = "";
                btnPartData.Text = "";
                btnRoleData.Text = "";
            }
        }
        private void tmrTransition_Tick(object sender, EventArgs e)
        {
            // increment the timer
            SineTimeElapsed++;

            if (SineTimeElapsed <= TransitionTimeMilliseconds)
            {
                // recall that sin(pi/2) == 1. therefore, when the loop reaches the desired value, the final size will be reached.

                // retrieve the width of the buttons and panels when starting collapsing/expanding
                int InitialButtonWidth = pnlButtons.Controls.OfType<Button>().ToList()[0].Width;
                int InitialPanelWidth = pnlButtons.Width;

                // indicates how far into the collapse/expand the panel is
                double SineSizeMultiplier = Math.Sin((Math.PI / (2 * TransitionTimeMilliseconds)) * SineTimeElapsed);
                

                // modify the size of the button/panel with the next segment that is to be added/removed
                foreach (Button button in FormButtons)
                {
                    button.Width =
                        Entered ?
                        InitialButtonWidth + Convert.ToInt32((ButtonExpandedWidth - InitialButtonWidth) * SineSizeMultiplier) :
                        InitialButtonWidth - Convert.ToInt32((InitialButtonWidth - ButtonCollapsedWidth) * SineSizeMultiplier);
                }
                pnlButtons.Width = Entered ?
                        InitialPanelWidth + Convert.ToInt32((PanelExpandedWidth - InitialPanelWidth) * SineSizeMultiplier) :
                        InitialPanelWidth - Convert.ToInt32((InitialPanelWidth - PanelCollapsedWidth) * SineSizeMultiplier);
            }
            else if (SineTimeElapsed > TransitionTimeMilliseconds)
            {
                // animation has stopped
                tmrTransition.Enabled = false;
                SineTimeElapsed = 0;
            }

            if (pnlButtons.Width >= PanelExpandedWidth - 10)
            {
                // once the panel is near the end of expanding, show texts
                toggleButtonTexts(true);
            }
            else
            {
                // hide when panel shrinks below that point
                toggleButtonTexts(false);
            }
        }

        #endregion
    }
}
