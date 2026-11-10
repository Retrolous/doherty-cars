
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        /// 
        ///
       
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtaVehicleTypeProfitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetVehicleTypeProfits = new Petkunas__Lukas___Doherty_Cars.DataSetVehicleTypeProfits();
            this.dtaMissedAppointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetMissedAppointment = new Petkunas__Lukas___Doherty_Cars.DataSetMissedAppointment();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.comboAppointmentID = new System.Windows.Forms.ComboBox();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.rpvInvoices = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabAppointmentMonthlyProfitsByMechanic = new System.Windows.Forms.TabPage();
            this.rpvAppointmentMonthlyProfitsByMechanic = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabVehicleTypeProfits = new System.Windows.Forms.TabPage();
            this.rpvVehicleTypeProfits = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabVehicleStock = new System.Windows.Forms.TabPage();
            this.rpvVehicleStock = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabCustomerInterest = new System.Windows.Forms.TabPage();
            this.rpvCustomerInterest = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabMissedAppointments = new System.Windows.Forms.TabPage();
            this.rpvMissedAppointments = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtaVehicleTypeProfitsTableAdapter = new Petkunas__Lukas___Doherty_Cars.DataSetVehicleTypeProfitsTableAdapters.dtaVehicleTypeProfitsTableAdapter();
            this.dtaMissedAppointmentsTableAdapter = new Petkunas__Lukas___Doherty_Cars.DataSetMissedAppointmentTableAdapters.dtaMissedAppointmentsTableAdapter();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtaVehicleTypeProfitsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetVehicleTypeProfits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtaMissedAppointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMissedAppointment)).BeginInit();
            this.tabReports.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            this.tabAppointmentMonthlyProfitsByMechanic.SuspendLayout();
            this.tabVehicleTypeProfits.SuspendLayout();
            this.tabVehicleStock.SuspendLayout();
            this.tabCustomerInterest.SuspendLayout();
            this.tabMissedAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtaVehicleTypeProfitsBindingSource
            // 
            this.dtaVehicleTypeProfitsBindingSource.DataMember = "dtaVehicleTypeProfits";
            this.dtaVehicleTypeProfitsBindingSource.DataSource = this.DataSetVehicleTypeProfits;
            // 
            // DataSetVehicleTypeProfits
            // 
            this.DataSetVehicleTypeProfits.DataSetName = "DataSetVehicleTypeProfits";
            this.DataSetVehicleTypeProfits.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtaMissedAppointmentsBindingSource
            // 
            this.dtaMissedAppointmentsBindingSource.DataMember = "dtaMissedAppointments";
            this.dtaMissedAppointmentsBindingSource.DataSource = this.DataSetMissedAppointment;
            // 
            // DataSetMissedAppointment
            // 
            this.DataSetMissedAppointment.DataSetName = "DataSetMissedAppointment";
            this.DataSetMissedAppointment.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabInvoices);
            this.tabReports.Controls.Add(this.tabAppointmentMonthlyProfitsByMechanic);
            this.tabReports.Controls.Add(this.tabVehicleTypeProfits);
            this.tabReports.Controls.Add(this.tabVehicleStock);
            this.tabReports.Controls.Add(this.tabCustomerInterest);
            this.tabReports.Controls.Add(this.tabMissedAppointments);
            this.tabReports.Font = new System.Drawing.Font("Bahnschrift", 8.25F);
            this.tabReports.Location = new System.Drawing.Point(13, 25);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(1216, 678);
            this.tabReports.TabIndex = 1;
            // 
            // tabInvoices
            // 
            this.tabInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabInvoices.Controls.Add(this.comboAppointmentID);
            this.tabInvoices.Controls.Add(this.lblAppointmentID);
            this.tabInvoices.Controls.Add(this.rpvInvoices);
            this.tabInvoices.Location = new System.Drawing.Point(4, 22);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoices.Size = new System.Drawing.Size(1208, 652);
            this.tabInvoices.TabIndex = 1;
            this.tabInvoices.Text = "Invoices";
            // 
            // comboAppointmentID
            // 
            this.comboAppointmentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAppointmentID.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.comboAppointmentID.FormattingEnabled = true;
            this.comboAppointmentID.Location = new System.Drawing.Point(124, 3);
            this.comboAppointmentID.Name = "comboAppointmentID";
            this.comboAppointmentID.Size = new System.Drawing.Size(232, 24);
            this.comboAppointmentID.TabIndex = 2;
            this.comboAppointmentID.SelectedIndexChanged += new System.EventHandler(this.comboAppointmentID_SelectedIndexChanged);
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.lblAppointmentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblAppointmentID.Location = new System.Drawing.Point(7, 7);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(111, 17);
            this.lblAppointmentID.TabIndex = 1;
            this.lblAppointmentID.Text = "Appointment ID:";
            // 
            // rpvInvoices
            // 
            this.rpvInvoices.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptInvoices.rdlc";
            this.rpvInvoices.Location = new System.Drawing.Point(6, 33);
            this.rpvInvoices.Name = "rpvInvoices";
            this.rpvInvoices.ServerReport.BearerToken = null;
            this.rpvInvoices.Size = new System.Drawing.Size(1196, 613);
            this.rpvInvoices.TabIndex = 0;
            // 
            // tabAppointmentMonthlyProfitsByMechanic
            // 
            this.tabAppointmentMonthlyProfitsByMechanic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabAppointmentMonthlyProfitsByMechanic.Controls.Add(this.rpvAppointmentMonthlyProfitsByMechanic);
            this.tabAppointmentMonthlyProfitsByMechanic.Location = new System.Drawing.Point(4, 22);
            this.tabAppointmentMonthlyProfitsByMechanic.Name = "tabAppointmentMonthlyProfitsByMechanic";
            this.tabAppointmentMonthlyProfitsByMechanic.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointmentMonthlyProfitsByMechanic.Size = new System.Drawing.Size(1208, 652);
            this.tabAppointmentMonthlyProfitsByMechanic.TabIndex = 0;
            this.tabAppointmentMonthlyProfitsByMechanic.Text = "Mechanic Monthly Profits";
            // 
            // rpvAppointmentMonthlyProfitsByMechanic
            // 
            this.rpvAppointmentMonthlyProfitsByMechanic.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptAppointmentMonthlyProfitsByMechanic.rdlc";
            this.rpvAppointmentMonthlyProfitsByMechanic.Location = new System.Drawing.Point(6, 6);
            this.rpvAppointmentMonthlyProfitsByMechanic.Name = "rpvAppointmentMonthlyProfitsByMechanic";
            this.rpvAppointmentMonthlyProfitsByMechanic.ServerReport.BearerToken = null;
            this.rpvAppointmentMonthlyProfitsByMechanic.Size = new System.Drawing.Size(1199, 640);
            this.rpvAppointmentMonthlyProfitsByMechanic.TabIndex = 0;
            // 
            // tabVehicleTypeProfits
            // 
            this.tabVehicleTypeProfits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabVehicleTypeProfits.Controls.Add(this.rpvVehicleTypeProfits);
            this.tabVehicleTypeProfits.Location = new System.Drawing.Point(4, 22);
            this.tabVehicleTypeProfits.Name = "tabVehicleTypeProfits";
            this.tabVehicleTypeProfits.Padding = new System.Windows.Forms.Padding(3);
            this.tabVehicleTypeProfits.Size = new System.Drawing.Size(1208, 652);
            this.tabVehicleTypeProfits.TabIndex = 2;
            this.tabVehicleTypeProfits.Text = "Profits by Vehicle Types";
            // 
            // rpvVehicleTypeProfits
            // 
            reportDataSource1.Name = "DSVehicleTypeProfits";
            reportDataSource1.Value = this.dtaVehicleTypeProfitsBindingSource;
            this.rpvVehicleTypeProfits.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvVehicleTypeProfits.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptVehicleTypeProfits.rdlc";
            this.rpvVehicleTypeProfits.Location = new System.Drawing.Point(6, 6);
            this.rpvVehicleTypeProfits.Name = "rpvVehicleTypeProfits";
            this.rpvVehicleTypeProfits.ServerReport.BearerToken = null;
            this.rpvVehicleTypeProfits.Size = new System.Drawing.Size(1196, 639);
            this.rpvVehicleTypeProfits.TabIndex = 0;
            // 
            // tabVehicleStock
            // 
            this.tabVehicleStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabVehicleStock.Controls.Add(this.rpvVehicleStock);
            this.tabVehicleStock.Location = new System.Drawing.Point(4, 22);
            this.tabVehicleStock.Name = "tabVehicleStock";
            this.tabVehicleStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabVehicleStock.Size = new System.Drawing.Size(1208, 652);
            this.tabVehicleStock.TabIndex = 3;
            this.tabVehicleStock.Text = "Vehicle Stock";
            // 
            // rpvVehicleStock
            // 
            this.rpvVehicleStock.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptVehicleStock.rdlc";
            this.rpvVehicleStock.Location = new System.Drawing.Point(6, 6);
            this.rpvVehicleStock.Name = "rpvVehicleStock";
            this.rpvVehicleStock.ServerReport.BearerToken = null;
            this.rpvVehicleStock.Size = new System.Drawing.Size(1195, 645);
            this.rpvVehicleStock.TabIndex = 0;
            // 
            // tabCustomerInterest
            // 
            this.tabCustomerInterest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabCustomerInterest.Controls.Add(this.rpvCustomerInterest);
            this.tabCustomerInterest.Location = new System.Drawing.Point(4, 22);
            this.tabCustomerInterest.Name = "tabCustomerInterest";
            this.tabCustomerInterest.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomerInterest.Size = new System.Drawing.Size(1208, 652);
            this.tabCustomerInterest.TabIndex = 4;
            this.tabCustomerInterest.Text = "Customer Interest";
            // 
            // rpvCustomerInterest
            // 
            this.rpvCustomerInterest.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptCustomerInterest.rdlc";
            this.rpvCustomerInterest.Location = new System.Drawing.Point(6, 6);
            this.rpvCustomerInterest.Name = "rpvCustomerInterest";
            this.rpvCustomerInterest.ServerReport.BearerToken = null;
            this.rpvCustomerInterest.Size = new System.Drawing.Size(1196, 640);
            this.rpvCustomerInterest.TabIndex = 0;
            // 
            // tabMissedAppointments
            // 
            this.tabMissedAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.tabMissedAppointments.Controls.Add(this.rpvMissedAppointments);
            this.tabMissedAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabMissedAppointments.Name = "tabMissedAppointments";
            this.tabMissedAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissedAppointments.Size = new System.Drawing.Size(1208, 652);
            this.tabMissedAppointments.TabIndex = 5;
            this.tabMissedAppointments.Text = "Missed Appointments";
            // 
            // rpvMissedAppointments
            // 
            reportDataSource2.Name = "DSMissedAppointments";
            reportDataSource2.Value = this.dtaMissedAppointmentsBindingSource;
            this.rpvMissedAppointments.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvMissedAppointments.LocalReport.ReportEmbeddedResource = "Petkunas__Lukas___Doherty_Cars.rptMissedAppointments.rdlc";
            this.rpvMissedAppointments.Location = new System.Drawing.Point(6, 6);
            this.rpvMissedAppointments.Name = "rpvMissedAppointments";
            this.rpvMissedAppointments.ServerReport.BearerToken = null;
            this.rpvMissedAppointments.Size = new System.Drawing.Size(1196, 640);
            this.rpvMissedAppointments.TabIndex = 0;
            // 
            // dtaVehicleTypeProfitsTableAdapter
            // 
            this.dtaVehicleTypeProfitsTableAdapter.ClearBeforeFill = true;
            // 
            // dtaMissedAppointmentsTableAdapter
            // 
            this.dtaMissedAppointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnHelp.Location = new System.Drawing.Point(841, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(378, 38);
            this.btnHelp.TabIndex = 63;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabReports);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtaVehicleTypeProfitsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetVehicleTypeProfits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtaMissedAppointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMissedAppointment)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            this.tabInvoices.PerformLayout();
            this.tabAppointmentMonthlyProfitsByMechanic.ResumeLayout(false);
            this.tabVehicleTypeProfits.ResumeLayout(false);
            this.tabVehicleStock.ResumeLayout(false);
            this.tabCustomerInterest.ResumeLayout(false);
            this.tabMissedAppointments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabAppointmentMonthlyProfitsByMechanic;
        private System.Windows.Forms.TabPage tabInvoices;
        private Microsoft.Reporting.WinForms.ReportViewer rpvAppointmentMonthlyProfitsByMechanic;
        private Microsoft.Reporting.WinForms.ReportViewer rpvInvoices;
        private System.Windows.Forms.ComboBox comboAppointmentID;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabVehicleTypeProfits;
        private Microsoft.Reporting.WinForms.ReportViewer rpvVehicleTypeProfits;
        private System.Windows.Forms.BindingSource dtaVehicleTypeProfitsBindingSource;
        private DataSetVehicleTypeProfits DataSetVehicleTypeProfits;
        private DataSetVehicleTypeProfitsTableAdapters.dtaVehicleTypeProfitsTableAdapter dtaVehicleTypeProfitsTableAdapter;
        private System.Windows.Forms.TabPage tabVehicleStock;
        private Microsoft.Reporting.WinForms.ReportViewer rpvVehicleStock;
        private System.Windows.Forms.TabPage tabCustomerInterest;
        private Microsoft.Reporting.WinForms.ReportViewer rpvCustomerInterest;
        private System.Windows.Forms.TabPage tabMissedAppointments;
        private Microsoft.Reporting.WinForms.ReportViewer rpvMissedAppointments;
        private System.Windows.Forms.BindingSource dtaMissedAppointmentsBindingSource;
        private DataSetMissedAppointment DataSetMissedAppointment;
        private DataSetMissedAppointmentTableAdapters.dtaMissedAppointmentsTableAdapter dtaMissedAppointmentsTableAdapter;
        private System.Windows.Forms.Button btnHelp;
    }
}