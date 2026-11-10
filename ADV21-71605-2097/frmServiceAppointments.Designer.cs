
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmServiceAppointments
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
        private void InitializeComponent()
        {
            this.pnlViewer = new System.Windows.Forms.Panel();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.comboMechanicID = new System.Windows.Forms.ComboBox();
            this.comboVehicleID = new System.Windows.Forms.ComboBox();
            this.chkPaid = new System.Windows.Forms.CheckBox();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.chkDiscounted = new System.Windows.Forms.CheckBox();
            this.txtAppointmentID = new System.Windows.Forms.TextBox();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.chklbServices = new System.Windows.Forms.CheckedListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tvServiceParts = new System.Windows.Forms.TreeView();
            this.btnSaveScheduleOnly = new System.Windows.Forms.Button();
            this.comboParts = new System.Windows.Forms.ComboBox();
            this.dtpAppointmentEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpAppointmentStart = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentStart = new System.Windows.Forms.Label();
            this.lblAppointmentEnd = new System.Windows.Forms.Label();
            this.comboAppointmentServices = new System.Windows.Forms.ComboBox();
            this.chkInsertMode = new System.Windows.Forms.CheckBox();
            this.btnPartPlus = new System.Windows.Forms.Button();
            this.btnPartMinus = new System.Windows.Forms.Button();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.pnlDivider3 = new System.Windows.Forms.Panel();
            this.pnlDivider2 = new System.Windows.Forms.Panel();
            this.pnlDivider1 = new System.Windows.Forms.Panel();
            this.lblCostValue = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblTimeRequiredValue = new System.Windows.Forms.Label();
            this.lblTimeRequired = new System.Windows.Forms.Label();
            this.lblPart = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblMechanic = new System.Windows.Forms.Label();
            this.lblServices = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblMechanicSearch = new System.Windows.Forms.Label();
            this.comboVehicleSearch = new System.Windows.Forms.ComboBox();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.comboMechanicSearch = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlCRUD.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlViewer
            // 
            this.pnlViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlViewer.Location = new System.Drawing.Point(12, 12);
            this.pnlViewer.Name = "pnlViewer";
            this.pnlViewer.Size = new System.Drawing.Size(1217, 359);
            this.pnlViewer.TabIndex = 66;
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.CalendarFont = new System.Drawing.Font("Bahnschrift", 13F);
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.dtpAppointmentDate.Location = new System.Drawing.Point(15, 7);
            this.dtpAppointmentDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpAppointmentDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(315, 32);
            this.dtpAppointmentDate.TabIndex = 67;
            this.dtpAppointmentDate.ValueChanged += new System.EventHandler(this.dtpAppointmentDate_ValueChanged);
            // 
            // comboMechanicID
            // 
            this.comboMechanicID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMechanicID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboMechanicID.FormattingEnabled = true;
            this.comboMechanicID.Location = new System.Drawing.Point(108, 106);
            this.comboMechanicID.Name = "comboMechanicID";
            this.comboMechanicID.Size = new System.Drawing.Size(359, 29);
            this.comboMechanicID.TabIndex = 68;
            this.comboMechanicID.SelectedIndexChanged += new System.EventHandler(this.comboMechanicID_SelectedIndexChanged);
            // 
            // comboVehicleID
            // 
            this.comboVehicleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehicleID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboVehicleID.FormattingEnabled = true;
            this.comboVehicleID.Location = new System.Drawing.Point(561, 106);
            this.comboVehicleID.Name = "comboVehicleID";
            this.comboVehicleID.Size = new System.Drawing.Size(435, 29);
            this.comboVehicleID.TabIndex = 69;
            this.comboVehicleID.SelectedIndexChanged += new System.EventHandler(this.comboVehicleID_SelectedIndexChanged);
            // 
            // chkPaid
            // 
            this.chkPaid.AutoSize = true;
            this.chkPaid.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkPaid.Location = new System.Drawing.Point(269, 57);
            this.chkPaid.Name = "chkPaid";
            this.chkPaid.Size = new System.Drawing.Size(73, 26);
            this.chkPaid.TabIndex = 70;
            this.chkPaid.Text = "Paid?";
            this.chkPaid.UseVisualStyleBackColor = true;
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkCompleted.Location = new System.Drawing.Point(482, 57);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(124, 26);
            this.chkCompleted.TabIndex = 71;
            this.chkCompleted.Text = "Completed?";
            this.chkCompleted.UseVisualStyleBackColor = true;
            // 
            // chkDiscounted
            // 
            this.chkDiscounted.AutoSize = true;
            this.chkDiscounted.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkDiscounted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkDiscounted.Location = new System.Drawing.Point(348, 57);
            this.chkDiscounted.Name = "chkDiscounted";
            this.chkDiscounted.Size = new System.Drawing.Size(128, 26);
            this.chkDiscounted.TabIndex = 72;
            this.chkDiscounted.Text = "Discounted?";
            this.chkDiscounted.UseVisualStyleBackColor = true;
            this.chkDiscounted.CheckedChanged += new System.EventHandler(this.chkDiscounted_CheckedChanged);
            // 
            // txtAppointmentID
            // 
            this.txtAppointmentID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtAppointmentID.Location = new System.Drawing.Point(156, 55);
            this.txtAppointmentID.Name = "txtAppointmentID";
            this.txtAppointmentID.ReadOnly = true;
            this.txtAppointmentID.Size = new System.Drawing.Size(100, 28);
            this.txtAppointmentID.TabIndex = 73;
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblAppointmentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblAppointmentID.Location = new System.Drawing.Point(11, 57);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(139, 22);
            this.lblAppointmentID.TabIndex = 74;
            this.lblAppointmentID.Text = "Appointment ID:";
            // 
            // chklbServices
            // 
            this.chklbServices.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chklbServices.FormattingEnabled = true;
            this.chklbServices.Location = new System.Drawing.Point(15, 179);
            this.chklbServices.Name = "chklbServices";
            this.chklbServices.Size = new System.Drawing.Size(311, 96);
            this.chklbServices.TabIndex = 75;
            this.chklbServices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklbServices_ItemCheck);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.btnDelete.Location = new System.Drawing.Point(15, 286);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(241, 39);
            this.btnDelete.TabIndex = 76;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.btnSave.Location = new System.Drawing.Point(262, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(293, 39);
            this.btnSave.TabIndex = 77;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnAdd.Location = new System.Drawing.Point(262, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(293, 39);
            this.btnAdd.TabIndex = 78;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tvServiceParts
            // 
            this.tvServiceParts.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.tvServiceParts.Location = new System.Drawing.Point(351, 179);
            this.tvServiceParts.Name = "tvServiceParts";
            this.tvServiceParts.Size = new System.Drawing.Size(312, 101);
            this.tvServiceParts.TabIndex = 79;
            // 
            // btnSaveScheduleOnly
            // 
            this.btnSaveScheduleOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveScheduleOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveScheduleOnly.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.btnSaveScheduleOnly.Location = new System.Drawing.Point(561, 286);
            this.btnSaveScheduleOnly.Name = "btnSaveScheduleOnly";
            this.btnSaveScheduleOnly.Size = new System.Drawing.Size(241, 39);
            this.btnSaveScheduleOnly.TabIndex = 81;
            this.btnSaveScheduleOnly.Text = "Save New Schedule";
            this.btnSaveScheduleOnly.UseVisualStyleBackColor = false;
            this.btnSaveScheduleOnly.Click += new System.EventHandler(this.btnSaveScheduleOnly_Click);
            // 
            // comboParts
            // 
            this.comboParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParts.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboParts.FormattingEnabled = true;
            this.comboParts.Location = new System.Drawing.Point(682, 251);
            this.comboParts.Name = "comboParts";
            this.comboParts.Size = new System.Drawing.Size(322, 29);
            this.comboParts.TabIndex = 82;
            // 
            // dtpAppointmentEnd
            // 
            this.dtpAppointmentEnd.CustomFormat = "HH\':\'00";
            this.dtpAppointmentEnd.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.dtpAppointmentEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentEnd.Location = new System.Drawing.Point(537, 10);
            this.dtpAppointmentEnd.Name = "dtpAppointmentEnd";
            this.dtpAppointmentEnd.ShowUpDown = true;
            this.dtpAppointmentEnd.Size = new System.Drawing.Size(73, 28);
            this.dtpAppointmentEnd.TabIndex = 83;
            this.dtpAppointmentEnd.ValueChanged += new System.EventHandler(this.dtpAppointmentEnd_ValueChanged);
            this.dtpAppointmentEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpAppointmentEnd_KeyPress);
            // 
            // dtpAppointmentStart
            // 
            this.dtpAppointmentStart.CustomFormat = "HH\':\'00";
            this.dtpAppointmentStart.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.dtpAppointmentStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentStart.Location = new System.Drawing.Point(403, 9);
            this.dtpAppointmentStart.Name = "dtpAppointmentStart";
            this.dtpAppointmentStart.ShowUpDown = true;
            this.dtpAppointmentStart.Size = new System.Drawing.Size(73, 28);
            this.dtpAppointmentStart.TabIndex = 84;
            this.dtpAppointmentStart.ValueChanged += new System.EventHandler(this.dtpAppointmentStart_ValueChanged);
            this.dtpAppointmentStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpAppointmentStart_KeyPress);
            // 
            // lblAppointmentStart
            // 
            this.lblAppointmentStart.AutoSize = true;
            this.lblAppointmentStart.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblAppointmentStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblAppointmentStart.Location = new System.Drawing.Point(336, 10);
            this.lblAppointmentStart.Name = "lblAppointmentStart";
            this.lblAppointmentStart.Size = new System.Drawing.Size(61, 24);
            this.lblAppointmentStart.TabIndex = 85;
            this.lblAppointmentStart.Text = "Start:";
            // 
            // lblAppointmentEnd
            // 
            this.lblAppointmentEnd.AutoSize = true;
            this.lblAppointmentEnd.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblAppointmentEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblAppointmentEnd.Location = new System.Drawing.Point(482, 10);
            this.lblAppointmentEnd.Name = "lblAppointmentEnd";
            this.lblAppointmentEnd.Size = new System.Drawing.Size(49, 24);
            this.lblAppointmentEnd.TabIndex = 86;
            this.lblAppointmentEnd.Text = "End:";
            // 
            // comboAppointmentServices
            // 
            this.comboAppointmentServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAppointmentServices.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboAppointmentServices.FormattingEnabled = true;
            this.comboAppointmentServices.Location = new System.Drawing.Point(765, 179);
            this.comboAppointmentServices.Name = "comboAppointmentServices";
            this.comboAppointmentServices.Size = new System.Drawing.Size(238, 29);
            this.comboAppointmentServices.TabIndex = 87;
            // 
            // chkInsertMode
            // 
            this.chkInsertMode.AutoSize = true;
            this.chkInsertMode.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.chkInsertMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkInsertMode.Location = new System.Drawing.Point(866, 3);
            this.chkInsertMode.Name = "chkInsertMode";
            this.chkInsertMode.Size = new System.Drawing.Size(138, 28);
            this.chkInsertMode.TabIndex = 88;
            this.chkInsertMode.Text = "Insert mode";
            this.chkInsertMode.UseVisualStyleBackColor = true;
            this.chkInsertMode.CheckedChanged += new System.EventHandler(this.chkInsertMode_CheckedChanged);
            // 
            // btnPartPlus
            // 
            this.btnPartPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPartPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartPlus.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.btnPartPlus.Location = new System.Drawing.Point(957, 214);
            this.btnPartPlus.Name = "btnPartPlus";
            this.btnPartPlus.Size = new System.Drawing.Size(46, 34);
            this.btnPartPlus.TabIndex = 89;
            this.btnPartPlus.Text = "+";
            this.btnPartPlus.UseVisualStyleBackColor = false;
            this.btnPartPlus.Click += new System.EventHandler(this.btnPartPlus_Click);
            // 
            // btnPartMinus
            // 
            this.btnPartMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPartMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartMinus.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.btnPartMinus.Location = new System.Drawing.Point(908, 214);
            this.btnPartMinus.Margin = new System.Windows.Forms.Padding(0);
            this.btnPartMinus.Name = "btnPartMinus";
            this.btnPartMinus.Size = new System.Drawing.Size(46, 34);
            this.btnPartMinus.TabIndex = 90;
            this.btnPartMinus.Text = "-";
            this.btnPartMinus.UseVisualStyleBackColor = false;
            this.btnPartMinus.Click += new System.EventHandler(this.btnPartMinus_Click);
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlCRUD.Controls.Add(this.pnlDivider3);
            this.pnlCRUD.Controls.Add(this.pnlDivider2);
            this.pnlCRUD.Controls.Add(this.pnlDivider1);
            this.pnlCRUD.Controls.Add(this.lblCostValue);
            this.pnlCRUD.Controls.Add(this.lblCost);
            this.pnlCRUD.Controls.Add(this.lblTimeRequiredValue);
            this.pnlCRUD.Controls.Add(this.lblTimeRequired);
            this.pnlCRUD.Controls.Add(this.chkInsertMode);
            this.pnlCRUD.Controls.Add(this.lblPart);
            this.pnlCRUD.Controls.Add(this.txtAppointmentID);
            this.pnlCRUD.Controls.Add(this.lblService);
            this.pnlCRUD.Controls.Add(this.lblAppointmentID);
            this.pnlCRUD.Controls.Add(this.lblVehicle);
            this.pnlCRUD.Controls.Add(this.lblMechanic);
            this.pnlCRUD.Controls.Add(this.btnPartPlus);
            this.pnlCRUD.Controls.Add(this.dtpAppointmentEnd);
            this.pnlCRUD.Controls.Add(this.lblAppointmentEnd);
            this.pnlCRUD.Controls.Add(this.comboMechanicID);
            this.pnlCRUD.Controls.Add(this.chkCompleted);
            this.pnlCRUD.Controls.Add(this.chkDiscounted);
            this.pnlCRUD.Controls.Add(this.btnPartMinus);
            this.pnlCRUD.Controls.Add(this.dtpAppointmentStart);
            this.pnlCRUD.Controls.Add(this.chkPaid);
            this.pnlCRUD.Controls.Add(this.lblAppointmentStart);
            this.pnlCRUD.Controls.Add(this.lblServices);
            this.pnlCRUD.Controls.Add(this.btnSaveScheduleOnly);
            this.pnlCRUD.Controls.Add(this.btnAdd);
            this.pnlCRUD.Controls.Add(this.comboAppointmentServices);
            this.pnlCRUD.Controls.Add(this.btnSave);
            this.pnlCRUD.Controls.Add(this.btnDelete);
            this.pnlCRUD.Controls.Add(this.tvServiceParts);
            this.pnlCRUD.Controls.Add(this.comboParts);
            this.pnlCRUD.Controls.Add(this.comboVehicleID);
            this.pnlCRUD.Controls.Add(this.dtpAppointmentDate);
            this.pnlCRUD.Controls.Add(this.chklbServices);
            this.pnlCRUD.Location = new System.Drawing.Point(12, 377);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(1020, 337);
            this.pnlCRUD.TabIndex = 91;
            // 
            // pnlDivider3
            // 
            this.pnlDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider3.Location = new System.Drawing.Point(10, 147);
            this.pnlDivider3.Name = "pnlDivider3";
            this.pnlDivider3.Size = new System.Drawing.Size(1000, 2);
            this.pnlDivider3.TabIndex = 103;
            // 
            // pnlDivider2
            // 
            this.pnlDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider2.Location = new System.Drawing.Point(10, 91);
            this.pnlDivider2.Name = "pnlDivider2";
            this.pnlDivider2.Size = new System.Drawing.Size(600, 2);
            this.pnlDivider2.TabIndex = 102;
            // 
            // pnlDivider1
            // 
            this.pnlDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider1.Location = new System.Drawing.Point(10, 46);
            this.pnlDivider1.Name = "pnlDivider1";
            this.pnlDivider1.Size = new System.Drawing.Size(600, 2);
            this.pnlDivider1.TabIndex = 101;
            // 
            // lblCostValue
            // 
            this.lblCostValue.AutoSize = true;
            this.lblCostValue.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblCostValue.ForeColor = System.Drawing.Color.White;
            this.lblCostValue.Location = new System.Drawing.Point(693, 71);
            this.lblCostValue.Name = "lblCostValue";
            this.lblCostValue.Size = new System.Drawing.Size(0, 22);
            this.lblCostValue.TabIndex = 100;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblCost.Location = new System.Drawing.Point(637, 71);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(50, 22);
            this.lblCost.TabIndex = 99;
            this.lblCost.Text = "Cost:";
            // 
            // lblTimeRequiredValue
            // 
            this.lblTimeRequiredValue.AutoSize = true;
            this.lblTimeRequiredValue.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblTimeRequiredValue.ForeColor = System.Drawing.Color.White;
            this.lblTimeRequiredValue.Location = new System.Drawing.Point(772, 44);
            this.lblTimeRequiredValue.Name = "lblTimeRequiredValue";
            this.lblTimeRequiredValue.Size = new System.Drawing.Size(0, 22);
            this.lblTimeRequiredValue.TabIndex = 98;
            // 
            // lblTimeRequired
            // 
            this.lblTimeRequired.AutoSize = true;
            this.lblTimeRequired.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblTimeRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblTimeRequired.Location = new System.Drawing.Point(637, 44);
            this.lblTimeRequired.Name = "lblTimeRequired";
            this.lblTimeRequired.Size = new System.Drawing.Size(129, 22);
            this.lblTimeRequired.TabIndex = 97;
            this.lblTimeRequired.Text = "Time required:";
            // 
            // lblPart
            // 
            this.lblPart.AutoSize = true;
            this.lblPart.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblPart.Location = new System.Drawing.Point(678, 224);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(49, 22);
            this.lblPart.TabIndex = 96;
            this.lblPart.Text = "Part:";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblService.Location = new System.Drawing.Point(676, 179);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(76, 22);
            this.lblService.TabIndex = 95;
            this.lblService.Text = "Service:";
            // 
            // lblVehicle
            // 
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblVehicle.Location = new System.Drawing.Point(482, 109);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(73, 22);
            this.lblVehicle.TabIndex = 94;
            this.lblVehicle.Text = "Vehicle:";
            // 
            // lblMechanic
            // 
            this.lblMechanic.AutoSize = true;
            this.lblMechanic.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblMechanic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblMechanic.Location = new System.Drawing.Point(11, 109);
            this.lblMechanic.Name = "lblMechanic";
            this.lblMechanic.Size = new System.Drawing.Size(91, 22);
            this.lblMechanic.TabIndex = 93;
            this.lblMechanic.Text = "Mechanic:";
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblServices.Location = new System.Drawing.Point(11, 152);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(85, 22);
            this.lblServices.TabIndex = 92;
            this.lblServices.Text = "Services:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.lblMechanicSearch);
            this.pnlSearch.Controls.Add(this.comboVehicleSearch);
            this.pnlSearch.Controls.Add(this.lblSearchField);
            this.pnlSearch.Controls.Add(this.comboMechanicSearch);
            this.pnlSearch.Location = new System.Drawing.Point(1038, 377);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(191, 275);
            this.pnlSearch.TabIndex = 92;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnSearch.Location = new System.Drawing.Point(15, 190);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(156, 58);
            this.btnSearch.TabIndex = 97;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblMechanicSearch
            // 
            this.lblMechanicSearch.AutoSize = true;
            this.lblMechanicSearch.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblMechanicSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblMechanicSearch.Location = new System.Drawing.Point(11, 98);
            this.lblMechanicSearch.Name = "lblMechanicSearch";
            this.lblMechanicSearch.Size = new System.Drawing.Size(100, 24);
            this.lblMechanicSearch.TabIndex = 98;
            this.lblMechanicSearch.Text = "Mechanic:";
            // 
            // comboVehicleSearch
            // 
            this.comboVehicleSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehicleSearch.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboVehicleSearch.FormattingEnabled = true;
            this.comboVehicleSearch.Location = new System.Drawing.Point(15, 37);
            this.comboVehicleSearch.Name = "comboVehicleSearch";
            this.comboVehicleSearch.Size = new System.Drawing.Size(156, 32);
            this.comboVehicleSearch.TabIndex = 97;
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchField.Location = new System.Drawing.Point(11, 10);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(80, 24);
            this.lblSearchField.TabIndex = 22;
            this.lblSearchField.Text = "Vehicle:";
            // 
            // comboMechanicSearch
            // 
            this.comboMechanicSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMechanicSearch.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboMechanicSearch.FormattingEnabled = true;
            this.comboMechanicSearch.Location = new System.Drawing.Point(15, 125);
            this.comboMechanicSearch.Name = "comboMechanicSearch";
            this.comboMechanicSearch.Size = new System.Drawing.Size(156, 32);
            this.comboMechanicSearch.TabIndex = 17;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnHelp.Location = new System.Drawing.Point(1038, 661);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(191, 53);
            this.btnHelp.TabIndex = 93;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmServiceAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 722);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlViewer);
            this.Controls.Add(this.pnlCRUD);
            this.Name = "frmServiceAppointments";
            this.Text = "Appointment Data";
            this.Load += new System.EventHandler(this.frmServiceAppointments_Load);
            this.pnlCRUD.ResumeLayout(false);
            this.pnlCRUD.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlViewer;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.ComboBox comboMechanicID;
        private System.Windows.Forms.ComboBox comboVehicleID;
        private System.Windows.Forms.CheckBox chkPaid;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.CheckBox chkDiscounted;
        private System.Windows.Forms.TextBox txtAppointmentID;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.CheckedListBox chklbServices;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TreeView tvServiceParts;
        private System.Windows.Forms.Button btnSaveScheduleOnly;
        private System.Windows.Forms.ComboBox comboParts;
        private System.Windows.Forms.DateTimePicker dtpAppointmentEnd;
        private System.Windows.Forms.DateTimePicker dtpAppointmentStart;
        private System.Windows.Forms.Label lblAppointmentStart;
        private System.Windows.Forms.Label lblAppointmentEnd;
        private System.Windows.Forms.ComboBox comboAppointmentServices;
        private System.Windows.Forms.CheckBox chkInsertMode;
        private System.Windows.Forms.Button btnPartPlus;
        private System.Windows.Forms.Button btnPartMinus;
        private System.Windows.Forms.Panel pnlCRUD;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.Label lblMechanic;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblMechanicSearch;
        private System.Windows.Forms.ComboBox comboVehicleSearch;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.ComboBox comboMechanicSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTimeRequiredValue;
        private System.Windows.Forms.Label lblTimeRequired;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblCostValue;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Panel pnlDivider3;
        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Button btnHelp;
    }
}