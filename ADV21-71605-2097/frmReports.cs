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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // for each report, get its adapter, populate a table with that adapter, clear the reports datasrouces, and bind the appropriate dataset and table

            var profitsAdapter = new DataSetAppointmentMonthlyProfitsByMechanicTableAdapters.dtaAppointmentMonthlyProfitsByMechanic();
            DataTable profitsTable = profitsAdapter.GetData();

            rpvAppointmentMonthlyProfitsByMechanic.LocalReport.DataSources.Clear();

            rpvAppointmentMonthlyProfitsByMechanic.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSAppointmentMonthlyProfitsByMechanic",
                    profitsTable
                    )
                );

            var vehicleTypeProfitsAdapter = new DataSetVehicleTypeProfitsTableAdapters.dtaVehicleTypeProfitsTableAdapter();
            DataTable vehicleTypeProfitsTable = vehicleTypeProfitsAdapter.GetData();

            rpvVehicleTypeProfits.LocalReport.DataSources.Clear();

            rpvVehicleTypeProfits.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSVehicleTypeProfits",
                    vehicleTypeProfitsTable
                    )
                );

            var vehicleStockAdapter = new DataSetVehicleStockTableAdapters.dtaVehicleStockTableAdapter();
            DataTable vehicleStockTable = vehicleStockAdapter.GetData();
            rpvVehicleStock.LocalReport.DataSources.Clear();

            rpvVehicleStock.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSVehicleStock",
                    vehicleStockTable
                    )
                );

            var missedAppointmentsAdapter = new DataSetMissedAppointmentTableAdapters.dtaMissedAppointmentsTableAdapter();
            DataTable missedAppointmentsTable = missedAppointmentsAdapter.GetData();
            rpvMissedAppointments.LocalReport.DataSources.Clear();

            rpvMissedAppointments.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSMissedAppointments",
                    missedAppointmentsTable
                    )
                );


            var customerInterestAdapter = new DataSetCustomerInterestTableAdapters.dtaCustomerInterestTableAdapter();
            DataTable customerInterestTable = customerInterestAdapter.GetData();
            rpvCustomerInterest.LocalReport.DataSources.Clear();

            rpvCustomerInterest.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSCustomerInterest",
                    customerInterestTable
                    )
                );


            // populate the list of appointment details
            List<ServiceAppointment> ServiceAppointments = ServiceAppointment.RetrieveAppointments();

            if (ServiceAppointments != null)
            {
                foreach (var sa in ServiceAppointments)
                {
                    Vehicle vec = Vehicle.RetrieveByVehicleID(sa.VehicleID);
                    Staff mec = Staff.RetrieveByStaffID(sa.StaffID);
                    comboAppointmentID.Items.Add(new ComboBoxItem($"{sa.AppointmentID} - {vec.Make} {vec.Model} - {mec.Firstname} {mec.Surname}", sa.AppointmentID.ToString()));
                }
            }
            else MessageBox.Show("Appointments could not be loaded from the databse. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            // refresh the reports to display the data
            this.rpvAppointmentMonthlyProfitsByMechanic.RefreshReport();
            this.rpvVehicleTypeProfits.RefreshReport();
            this.rpvVehicleStock.RefreshReport();
            this.rpvCustomerInterest.RefreshReport();
            this.rpvMissedAppointments.RefreshReport();
        }

        // when a new appointment has been chosen
        private void comboAppointmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the appointment id from the combobox item, ensuring that an appointment has been selected
            int AppointmentID = comboAppointmentID.SelectedItem == null ? 0 : int.Parse(((ComboBoxItem)(comboAppointmentID.SelectedItem)).HiddenValue);

            // get the appointment, service and item data using that appointment id, and bind to the report
            var InvoiceAdapter = new DataSetInvoicesTableAdapters.dtInvoiceDataTableAdapter();
            DataTable InvoiceTable = InvoiceAdapter.GetData(AppointmentID);
            var ItemsAdapter = new DataSetInvoicesTableAdapters.dtItemsTableAdapter();
            DataTable ItemsTable = ItemsAdapter.GetData(AppointmentID);

            rpvInvoices.LocalReport.DataSources.Clear();


            rpvInvoices.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSInvoiceData",
                    InvoiceTable
                    )
                );

            rpvInvoices.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DSItems",
                    ItemsTable
                    )
                );

            this.rpvInvoices.RefreshReport();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpReports frm = new frmHelpReports();
            frm.Show();

        }
    }
}
