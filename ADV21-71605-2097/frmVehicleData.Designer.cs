
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmVehicleData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVehicleID = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblMake = new System.Windows.Forms.Label();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlDivider3 = new System.Windows.Forms.Panel();
            this.pnlDivider2 = new System.Windows.Forms.Panel();
            this.pnlDivider1 = new System.Windows.Forms.Panel();
            this.numSellPrice = new System.Windows.Forms.NumericUpDown();
            this.numBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStorageLocation = new System.Windows.Forms.Label();
            this.comboStorageLocation = new System.Windows.Forms.ComboBox();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.chkInspected = new System.Windows.Forms.CheckBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.comboCondition = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.chkYearUnknown = new System.Windows.Forms.CheckBox();
            this.lblVehicleTypeID = new System.Windows.Forms.Label();
            this.comboVehicleTypeID = new System.Windows.Forms.ComboBox();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.comboCustomerID = new System.Windows.Forms.ComboBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.lblVehicleID = new System.Windows.Forms.Label();
            this.lblVIN = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.comboSearchField = new System.Windows.Forms.ComboBox();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.comboSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.pnlCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeColumns = false;
            this.dgvVehicles.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvVehicles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Bahnschrift", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicles.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvVehicles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(28)))));
            this.dgvVehicles.Location = new System.Drawing.Point(12, 12);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.RowTemplate.Height = 25;
            this.dgvVehicles.RowTemplate.ReadOnly = true;
            this.dgvVehicles.Size = new System.Drawing.Size(1220, 466);
            this.dgvVehicles.TabIndex = 1;
            this.dgvVehicles.SelectionChanged += new System.EventHandler(this.dgvVehicles_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnAdd.Location = new System.Drawing.Point(825, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 35);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnDelete.Location = new System.Drawing.Point(825, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 35);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnSave.Location = new System.Drawing.Point(825, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 35);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVehicleID
            // 
            this.txtVehicleID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtVehicleID.Location = new System.Drawing.Point(106, 6);
            this.txtVehicleID.Name = "txtVehicleID";
            this.txtVehicleID.ReadOnly = true;
            this.txtVehicleID.Size = new System.Drawing.Size(91, 28);
            this.txtVehicleID.TabIndex = 33;
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtModel.Location = new System.Drawing.Point(276, 41);
            this.txtModel.MaxLength = 100;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(241, 28);
            this.txtModel.TabIndex = 30;
            // 
            // txtMake
            // 
            this.txtMake.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtMake.Location = new System.Drawing.Point(70, 40);
            this.txtMake.MaxLength = 100;
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(127, 28);
            this.txtMake.TabIndex = 29;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblYear.Location = new System.Drawing.Point(539, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(49, 22);
            this.lblYear.TabIndex = 26;
            this.lblYear.Text = "Year:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblModel.Location = new System.Drawing.Point(207, 43);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(63, 22);
            this.lblModel.TabIndex = 25;
            this.lblModel.Text = "Model:";
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblMake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblMake.Location = new System.Drawing.Point(6, 43);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(58, 22);
            this.lblMake.TabIndex = 24;
            this.lblMake.Text = "Make:";
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlCRUD.Controls.Add(this.btnReset);
            this.pnlCRUD.Controls.Add(this.pnlDivider3);
            this.pnlCRUD.Controls.Add(this.pnlDivider2);
            this.pnlCRUD.Controls.Add(this.pnlDivider1);
            this.pnlCRUD.Controls.Add(this.numSellPrice);
            this.pnlCRUD.Controls.Add(this.numBuyPrice);
            this.pnlCRUD.Controls.Add(this.lblStorageLocation);
            this.pnlCRUD.Controls.Add(this.comboStorageLocation);
            this.pnlCRUD.Controls.Add(this.lblSellPrice);
            this.pnlCRUD.Controls.Add(this.lblBuyPrice);
            this.pnlCRUD.Controls.Add(this.chkInspected);
            this.pnlCRUD.Controls.Add(this.chkAvailable);
            this.pnlCRUD.Controls.Add(this.comboCondition);
            this.pnlCRUD.Controls.Add(this.lblCondition);
            this.pnlCRUD.Controls.Add(this.chkYearUnknown);
            this.pnlCRUD.Controls.Add(this.lblVehicleTypeID);
            this.pnlCRUD.Controls.Add(this.comboVehicleTypeID);
            this.pnlCRUD.Controls.Add(this.txtLicensePlate);
            this.pnlCRUD.Controls.Add(this.txtVIN);
            this.pnlCRUD.Controls.Add(this.comboCustomerID);
            this.pnlCRUD.Controls.Add(this.numYear);
            this.pnlCRUD.Controls.Add(this.lblCustomerID);
            this.pnlCRUD.Controls.Add(this.lblLicensePlate);
            this.pnlCRUD.Controls.Add(this.txtVehicleID);
            this.pnlCRUD.Controls.Add(this.lblVehicleID);
            this.pnlCRUD.Controls.Add(this.lblVIN);
            this.pnlCRUD.Controls.Add(this.btnSave);
            this.pnlCRUD.Controls.Add(this.btnAdd);
            this.pnlCRUD.Controls.Add(this.btnDelete);
            this.pnlCRUD.Controls.Add(this.lblModel);
            this.pnlCRUD.Controls.Add(this.lblYear);
            this.pnlCRUD.Controls.Add(this.txtMake);
            this.pnlCRUD.Controls.Add(this.txtModel);
            this.pnlCRUD.Controls.Add(this.lblMake);
            this.pnlCRUD.Location = new System.Drawing.Point(12, 504);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(935, 193);
            this.pnlCRUD.TabIndex = 38;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnReset.Location = new System.Drawing.Point(825, 150);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 35);
            this.btnReset.TabIndex = 58;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlDivider3
            // 
            this.pnlDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider3.Location = new System.Drawing.Point(529, 75);
            this.pnlDivider3.Name = "pnlDivider3";
            this.pnlDivider3.Size = new System.Drawing.Size(290, 2);
            this.pnlDivider3.TabIndex = 49;
            // 
            // pnlDivider2
            // 
            this.pnlDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider2.Location = new System.Drawing.Point(526, 10);
            this.pnlDivider2.Name = "pnlDivider2";
            this.pnlDivider2.Size = new System.Drawing.Size(2, 175);
            this.pnlDivider2.TabIndex = 49;
            // 
            // pnlDivider1
            // 
            this.pnlDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider1.Location = new System.Drawing.Point(3, 114);
            this.pnlDivider1.Name = "pnlDivider1";
            this.pnlDivider1.Size = new System.Drawing.Size(525, 2);
            this.pnlDivider1.TabIndex = 48;
            // 
            // numSellPrice
            // 
            this.numSellPrice.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.numSellPrice.Location = new System.Drawing.Point(638, 122);
            this.numSellPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSellPrice.Name = "numSellPrice";
            this.numSellPrice.Size = new System.Drawing.Size(170, 28);
            this.numSellPrice.TabIndex = 57;
            // 
            // numBuyPrice
            // 
            this.numBuyPrice.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.numBuyPrice.Location = new System.Drawing.Point(637, 86);
            this.numBuyPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numBuyPrice.Name = "numBuyPrice";
            this.numBuyPrice.Size = new System.Drawing.Size(170, 28);
            this.numBuyPrice.TabIndex = 56;
            // 
            // lblStorageLocation
            // 
            this.lblStorageLocation.AutoSize = true;
            this.lblStorageLocation.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblStorageLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblStorageLocation.Location = new System.Drawing.Point(6, 158);
            this.lblStorageLocation.Name = "lblStorageLocation";
            this.lblStorageLocation.Size = new System.Drawing.Size(154, 22);
            this.lblStorageLocation.TabIndex = 55;
            this.lblStorageLocation.Text = "Storage Location:";
            // 
            // comboStorageLocation
            // 
            this.comboStorageLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStorageLocation.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboStorageLocation.FormattingEnabled = true;
            this.comboStorageLocation.Items.AddRange(new object[] {
            "Main Forecourt",
            "Service Garage",
            "Internal Storage",
            "None"});
            this.comboStorageLocation.Location = new System.Drawing.Point(166, 158);
            this.comboStorageLocation.Name = "comboStorageLocation";
            this.comboStorageLocation.Size = new System.Drawing.Size(351, 29);
            this.comboStorageLocation.TabIndex = 54;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblSellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSellPrice.Location = new System.Drawing.Point(538, 124);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(92, 22);
            this.lblSellPrice.TabIndex = 53;
            this.lblSellPrice.Text = "Sell price:";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblBuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblBuyPrice.Location = new System.Drawing.Point(538, 88);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(92, 22);
            this.lblBuyPrice.TabIndex = 52;
            this.lblBuyPrice.Text = "Buy price:";
            // 
            // chkInspected
            // 
            this.chkInspected.AutoSize = true;
            this.chkInspected.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkInspected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkInspected.Location = new System.Drawing.Point(691, 158);
            this.chkInspected.Name = "chkInspected";
            this.chkInspected.Size = new System.Drawing.Size(116, 26);
            this.chkInspected.TabIndex = 51;
            this.chkInspected.Text = "Inspected?";
            this.chkInspected.UseVisualStyleBackColor = true;
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkAvailable.Location = new System.Drawing.Point(542, 158);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(113, 26);
            this.chkAvailable.TabIndex = 50;
            this.chkAvailable.Text = "Available?";
            this.chkAvailable.UseVisualStyleBackColor = true;
            // 
            // comboCondition
            // 
            this.comboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCondition.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboCondition.FormattingEnabled = true;
            this.comboCondition.Items.AddRange(new object[] {
            "Fair",
            "Good",
            "Excellent",
            "New"});
            this.comboCondition.Location = new System.Drawing.Point(638, 38);
            this.comboCondition.Name = "comboCondition";
            this.comboCondition.Size = new System.Drawing.Size(170, 29);
            this.comboCondition.TabIndex = 49;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblCondition.Location = new System.Drawing.Point(539, 40);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(91, 22);
            this.lblCondition.TabIndex = 48;
            this.lblCondition.Text = "Condition:";
            // 
            // chkYearUnknown
            // 
            this.chkYearUnknown.AutoSize = true;
            this.chkYearUnknown.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.chkYearUnknown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.chkYearUnknown.Location = new System.Drawing.Point(703, 6);
            this.chkYearUnknown.Name = "chkYearUnknown";
            this.chkYearUnknown.Size = new System.Drawing.Size(105, 26);
            this.chkYearUnknown.TabIndex = 47;
            this.chkYearUnknown.Text = "Unknown";
            this.chkYearUnknown.UseVisualStyleBackColor = true;
            this.chkYearUnknown.CheckedChanged += new System.EventHandler(this.chkYearUnknown_CheckedChanged);
            // 
            // lblVehicleTypeID
            // 
            this.lblVehicleTypeID.AutoSize = true;
            this.lblVehicleTypeID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblVehicleTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblVehicleTypeID.Location = new System.Drawing.Point(207, 6);
            this.lblVehicleTypeID.Name = "lblVehicleTypeID";
            this.lblVehicleTypeID.Size = new System.Drawing.Size(136, 22);
            this.lblVehicleTypeID.TabIndex = 46;
            this.lblVehicleTypeID.Text = "Vehicle Type ID:";
            // 
            // comboVehicleTypeID
            // 
            this.comboVehicleTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehicleTypeID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboVehicleTypeID.FormattingEnabled = true;
            this.comboVehicleTypeID.Location = new System.Drawing.Point(349, 3);
            this.comboVehicleTypeID.Name = "comboVehicleTypeID";
            this.comboVehicleTypeID.Size = new System.Drawing.Size(168, 29);
            this.comboVehicleTypeID.TabIndex = 45;
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtLicensePlate.Location = new System.Drawing.Point(381, 78);
            this.txtLicensePlate.MaxLength = 100;
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(136, 28);
            this.txtLicensePlate.TabIndex = 44;
            // 
            // txtVIN
            // 
            this.txtVIN.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtVIN.Location = new System.Drawing.Point(55, 78);
            this.txtVIN.MaxLength = 100;
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(190, 28);
            this.txtVIN.TabIndex = 43;
            // 
            // comboCustomerID
            // 
            this.comboCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomerID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboCustomerID.FormattingEnabled = true;
            this.comboCustomerID.Location = new System.Drawing.Point(126, 124);
            this.comboCustomerID.Name = "comboCustomerID";
            this.comboCustomerID.Size = new System.Drawing.Size(391, 29);
            this.comboCustomerID.TabIndex = 42;
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.numYear.Location = new System.Drawing.Point(594, 4);
            this.numYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(100, 28);
            this.numYear.TabIndex = 41;
            this.numYear.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblCustomerID.Location = new System.Drawing.Point(6, 127);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(114, 22);
            this.lblCustomerID.TabIndex = 40;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblLicensePlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblLicensePlate.Location = new System.Drawing.Point(251, 81);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(124, 22);
            this.lblLicensePlate.TabIndex = 39;
            this.lblLicensePlate.Text = "License Plate:";
            // 
            // lblVehicleID
            // 
            this.lblVehicleID.AutoSize = true;
            this.lblVehicleID.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblVehicleID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblVehicleID.Location = new System.Drawing.Point(6, 9);
            this.lblVehicleID.Name = "lblVehicleID";
            this.lblVehicleID.Size = new System.Drawing.Size(94, 22);
            this.lblVehicleID.TabIndex = 34;
            this.lblVehicleID.Text = "Vehicle ID:";
            // 
            // lblVIN
            // 
            this.lblVIN.AutoSize = true;
            this.lblVIN.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblVIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblVIN.Location = new System.Drawing.Point(6, 81);
            this.lblVIN.Name = "lblVIN";
            this.lblVIN.Size = new System.Drawing.Size(43, 22);
            this.lblVIN.TabIndex = 38;
            this.lblVIN.Text = "VIN:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlSearch.Controls.Add(this.lblSearchType);
            this.pnlSearch.Controls.Add(this.comboSearchField);
            this.pnlSearch.Controls.Add(this.lblSearchField);
            this.pnlSearch.Controls.Add(this.lblSearchText);
            this.pnlSearch.Controls.Add(this.comboSearchType);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(953, 504);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(279, 135);
            this.pnlSearch.TabIndex = 39;
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchType.Location = new System.Drawing.Point(11, 52);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(123, 24);
            this.lblSearchType.TabIndex = 23;
            this.lblSearchType.Text = "Search type:";
            // 
            // comboSearchField
            // 
            this.comboSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchField.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboSearchField.FormattingEnabled = true;
            this.comboSearchField.Location = new System.Drawing.Point(140, 9);
            this.comboSearchField.Name = "comboSearchField";
            this.comboSearchField.Size = new System.Drawing.Size(121, 29);
            this.comboSearchField.TabIndex = 18;
            this.comboSearchField.SelectedValueChanged += new System.EventHandler(this.comboSearchField_SelectedValueChanged);
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchField.Location = new System.Drawing.Point(11, 9);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(123, 24);
            this.lblSearchField.TabIndex = 22;
            this.lblSearchField.Text = "Search field:";
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchText.Location = new System.Drawing.Point(11, 95);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(119, 24);
            this.lblSearchText.TabIndex = 21;
            this.lblSearchText.Text = "Search text:";
            // 
            // comboSearchType
            // 
            this.comboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchType.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.comboSearchType.FormattingEnabled = true;
            this.comboSearchType.Items.AddRange(new object[] {
            "Contains",
            "Exact"});
            this.comboSearchType.Location = new System.Drawing.Point(140, 52);
            this.comboSearchType.Name = "comboSearchType";
            this.comboSearchType.Size = new System.Drawing.Size(121, 29);
            this.comboSearchType.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.txtSearch.Location = new System.Drawing.Point(140, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(121, 28);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnHelp.Location = new System.Drawing.Point(953, 644);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(279, 53);
            this.btnHelp.TabIndex = 64;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmVehicleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlCRUD);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvVehicles);
            this.Name = "frmVehicleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Data";
            this.Load += new System.EventHandler(this.frmVehicleData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.pnlCRUD.ResumeLayout(false);
            this.pnlCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtVehicleID;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Panel pnlCRUD;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.ComboBox comboSearchField;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.ComboBox comboSearchType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Label lblVIN;
        private System.Windows.Forms.Label lblVehicleID;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.ComboBox comboCustomerID;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label lblVehicleTypeID;
        private System.Windows.Forms.ComboBox comboVehicleTypeID;
        private System.Windows.Forms.CheckBox chkYearUnknown;
        private System.Windows.Forms.NumericUpDown numSellPrice;
        private System.Windows.Forms.NumericUpDown numBuyPrice;
        private System.Windows.Forms.Label lblStorageLocation;
        private System.Windows.Forms.ComboBox comboStorageLocation;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.CheckBox chkInspected;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.ComboBox comboCondition;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Panel pnlDivider3;
        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHelp;
    }
}