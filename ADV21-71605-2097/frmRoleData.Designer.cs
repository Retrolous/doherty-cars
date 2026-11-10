
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmRoleData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRoleID = new System.Windows.Forms.Label();
            this.txtRoleID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSector = new System.Windows.Forms.Label();
            this.lblAuthorisationLevel = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.comboSector = new System.Windows.Forms.ComboBox();
            this.comboAuthorisationLevel = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlDivider2 = new System.Windows.Forms.Panel();
            this.pnlDivider1 = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.comboSearchField = new System.Windows.Forms.ComboBox();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.comboSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.pnlCRUD.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AllowUserToResizeColumns = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(28)))));
            this.dgvRoles.Location = new System.Drawing.Point(12, 9);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowTemplate.Height = 25;
            this.dgvRoles.RowTemplate.ReadOnly = true;
            this.dgvRoles.Size = new System.Drawing.Size(1220, 487);
            this.dgvRoles.TabIndex = 16;
            this.dgvRoles.SelectionChanged += new System.EventHandler(this.dgvRoles_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnAdd.Location = new System.Drawing.Point(662, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(168, 43);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnDelete.Location = new System.Drawing.Point(662, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 42);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnSave.Location = new System.Drawing.Point(661, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 43);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRoleID
            // 
            this.lblRoleID.AutoSize = true;
            this.lblRoleID.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblRoleID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblRoleID.Location = new System.Drawing.Point(14, 51);
            this.lblRoleID.Name = "lblRoleID";
            this.lblRoleID.Size = new System.Drawing.Size(79, 24);
            this.lblRoleID.TabIndex = 43;
            this.lblRoleID.Text = "Role ID:";
            // 
            // txtRoleID
            // 
            this.txtRoleID.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.txtRoleID.Location = new System.Drawing.Point(96, 49);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.ReadOnly = true;
            this.txtRoleID.Size = new System.Drawing.Size(217, 32);
            this.txtRoleID.TabIndex = 42;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.txtName.Location = new System.Drawing.Point(96, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(217, 32);
            this.txtName.TabIndex = 38;
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSector.Location = new System.Drawing.Point(19, 108);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(74, 24);
            this.lblSector.TabIndex = 35;
            this.lblSector.Text = "Sector:";
            // 
            // lblAuthorisationLevel
            // 
            this.lblAuthorisationLevel.AutoSize = true;
            this.lblAuthorisationLevel.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblAuthorisationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblAuthorisationLevel.Location = new System.Drawing.Point(410, 10);
            this.lblAuthorisationLevel.Name = "lblAuthorisationLevel";
            this.lblAuthorisationLevel.Size = new System.Drawing.Size(191, 24);
            this.lblAuthorisationLevel.TabIndex = 34;
            this.lblAuthorisationLevel.Text = "Authorisation Level:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblName.Location = new System.Drawing.Point(22, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 24);
            this.lblName.TabIndex = 33;
            this.lblName.Text = "Name:";
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlCRUD.Controls.Add(this.txtName);
            this.pnlCRUD.Controls.Add(this.comboSector);
            this.pnlCRUD.Controls.Add(this.comboAuthorisationLevel);
            this.pnlCRUD.Controls.Add(this.btnReset);
            this.pnlCRUD.Controls.Add(this.pnlDivider2);
            this.pnlCRUD.Controls.Add(this.pnlDivider1);
            this.pnlCRUD.Controls.Add(this.lblSector);
            this.pnlCRUD.Controls.Add(this.txtRoleID);
            this.pnlCRUD.Controls.Add(this.lblRoleID);
            this.pnlCRUD.Controls.Add(this.btnDelete);
            this.pnlCRUD.Controls.Add(this.btnAdd);
            this.pnlCRUD.Controls.Add(this.btnSave);
            this.pnlCRUD.Controls.Add(this.lblName);
            this.pnlCRUD.Controls.Add(this.lblAuthorisationLevel);
            this.pnlCRUD.Location = new System.Drawing.Point(12, 502);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(836, 193);
            this.pnlCRUD.TabIndex = 47;
            // 
            // comboSector
            // 
            this.comboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSector.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboSector.FormattingEnabled = true;
            this.comboSector.Items.AddRange(new object[] {
            "None",
            "Administrative",
            "Customer Service",
            "Technical",
            "Finance",
            "HR"});
            this.comboSector.Location = new System.Drawing.Point(99, 105);
            this.comboSector.Name = "comboSector";
            this.comboSector.Size = new System.Drawing.Size(214, 32);
            this.comboSector.TabIndex = 62;
            // 
            // comboAuthorisationLevel
            // 
            this.comboAuthorisationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAuthorisationLevel.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboAuthorisationLevel.FormattingEnabled = true;
            this.comboAuthorisationLevel.Location = new System.Drawing.Point(414, 43);
            this.comboAuthorisationLevel.Name = "comboAuthorisationLevel";
            this.comboAuthorisationLevel.Size = new System.Drawing.Size(202, 32);
            this.comboAuthorisationLevel.TabIndex = 61;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnReset.Location = new System.Drawing.Point(414, 144);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(202, 40);
            this.btnReset.TabIndex = 60;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlDivider2
            // 
            this.pnlDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider2.Location = new System.Drawing.Point(375, 9);
            this.pnlDivider2.Name = "pnlDivider2";
            this.pnlDivider2.Size = new System.Drawing.Size(2, 175);
            this.pnlDivider2.TabIndex = 48;
            // 
            // pnlDivider1
            // 
            this.pnlDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider1.Location = new System.Drawing.Point(10, 91);
            this.pnlDivider1.Name = "pnlDivider1";
            this.pnlDivider1.Size = new System.Drawing.Size(367, 2);
            this.pnlDivider1.TabIndex = 47;
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
            this.pnlSearch.Location = new System.Drawing.Point(854, 502);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(378, 132);
            this.pnlSearch.TabIndex = 48;
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchType.Location = new System.Drawing.Point(11, 51);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(123, 24);
            this.lblSearchType.TabIndex = 23;
            this.lblSearchType.Text = "Search type:";
            // 
            // comboSearchField
            // 
            this.comboSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchField.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboSearchField.FormattingEnabled = true;
            this.comboSearchField.Location = new System.Drawing.Point(140, 87);
            this.comboSearchField.Name = "comboSearchField";
            this.comboSearchField.Size = new System.Drawing.Size(225, 32);
            this.comboSearchField.TabIndex = 18;
            this.comboSearchField.SelectedValueChanged += new System.EventHandler(this.comboSearchField_SelectedValueChanged);
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSearchField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearchField.Location = new System.Drawing.Point(11, 90);
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
            this.lblSearchText.Location = new System.Drawing.Point(11, 13);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(119, 24);
            this.lblSearchText.TabIndex = 21;
            this.lblSearchText.Text = "Search text:";
            // 
            // comboSearchType
            // 
            this.comboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchType.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboSearchType.FormattingEnabled = true;
            this.comboSearchType.Items.AddRange(new object[] {
            "Contains",
            "Exact"});
            this.comboSearchType.Location = new System.Drawing.Point(140, 49);
            this.comboSearchType.Name = "comboSearchType";
            this.comboSearchType.Size = new System.Drawing.Size(225, 32);
            this.comboSearchType.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.txtSearch.Location = new System.Drawing.Point(140, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(225, 32);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnHelp.Location = new System.Drawing.Point(854, 640);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(378, 53);
            this.btnHelp.TabIndex = 63;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmRoleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlCRUD);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRoleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role Data";
            this.Load += new System.EventHandler(this.frmRoleData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlCRUD.ResumeLayout(false);
            this.pnlCRUD.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRoleID;
        private System.Windows.Forms.TextBox txtRoleID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSector;
        private System.Windows.Forms.Label lblAuthorisationLevel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlCRUD;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.ComboBox comboSearchField;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.ComboBox comboSearchType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox comboAuthorisationLevel;
        private System.Windows.Forms.ComboBox comboSector;
        private System.Windows.Forms.Button btnHelp;
    }
}