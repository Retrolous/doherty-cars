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
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }


        private void frmLogs_Load(object sender, EventArgs e)
        {
            // retrieve all logs for the current day
            List<ListViewItem> Logs = Logging.RetrieveLogsAsListViewItems(DateTime.Now, null, null);

            // display them
            foreach (ListViewItem log in Logs)
            {
                lvLogs.Items.Add(log); 
            }

            comboLogType.SelectedIndex = 0;
            comboStaffMember.SelectedIndex = 0;

            // retrieve all staff members from the database
            List<Staff> AllStaffMembers = Staff.RetrieveStaffMembers();

            // if none could be loaded due to a system error, prevent further processing
            if (AllStaffMembers == null)
            {             
                MessageBox.Show("No staff members could be loaded");
                return;
            }

            // add each staff member as a filtering option
            foreach (Staff staff in AllStaffMembers)
            {
                comboStaffMember.Items.Add(new ComboBoxItem($"{staff.StaffID} - {staff.Firstname} {staff.Surname}", Convert.ToString(staff.Username)));
            }

            
        }

        // display new logs when the date is changed
        private void dtpLogDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateLogs();
        }

        // get the log type selected for filtering from the respective combobox
        private Logging.LogType? GetLogType()
        {
            try
            {
                switch (comboLogType.SelectedItem)
                {
                    case "None": return null;
                    case "LoginAttempt": return Logging.LogType.LoginAttempt;
                    case "Login": return Logging.LogType.Login;
                    case "Access": return Logging.LogType.Access;
                    case "Create": return Logging.LogType.Create;
                    case "Update": return Logging.LogType.Update;
                    case "Delete": return Logging.LogType.Delete;
                    default: return null;
                }
            }
            catch
            {
                return null;
            }
        }

        // get the username of the staff member selected for filtering
        private string GetUsername()
        {
            if (comboStaffMember.SelectedIndex < 0 || comboStaffMember.Text == "None") return null;
            else return ((ComboBoxItem)comboStaffMember.SelectedItem).HiddenValue;

        }

        // display the logs for that current day, filtered by action and user
        private void UpdateLogs()
        {
            List<ListViewItem> logs = Logging.RetrieveLogsAsListViewItems(dtpLogDate.Value, GetLogType(), GetUsername());

            // clear all logs currently displayed
            lvLogs.Items.Clear();

            // display the new fetched logs
            foreach (ListViewItem log in logs)
            {
                lvLogs.Items.Add(log);
            }
        }

        // if the filtering action has been modified
        private void comboLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogs();
        }

        // if the filtering staff member has been modified
        private void comboStaffMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogs();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpLogs frm = new frmHelpLogs();
            frm.Show();

        }
    }
}
