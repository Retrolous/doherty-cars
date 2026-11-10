
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmLogs
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
            this.lvLogs = new System.Windows.Forms.ListView();
            this.columnLogs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpLogDate = new System.Windows.Forms.DateTimePicker();
            this.comboLogType = new System.Windows.Forms.ComboBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.comboStaffMember = new System.Windows.Forms.ComboBox();
            this.pnlDivider3 = new System.Windows.Forms.Panel();
            this.lblStaffMember = new System.Windows.Forms.Label();
            this.pnlDivider1 = new System.Windows.Forms.Panel();
            this.lblLogType = new System.Windows.Forms.Label();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLogs
            // 
            this.lvLogs.BackColor = System.Drawing.Color.White;
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLogs});
            this.lvLogs.Font = new System.Drawing.Font("Consolas", 8F);
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.GridLines = true;
            this.lvLogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLogs.HideSelection = false;
            this.lvLogs.Location = new System.Drawing.Point(15, 12);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(602, 679);
            this.lvLogs.TabIndex = 0;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // columnLogs
            // 
            this.columnLogs.Text = "Logs";
            this.columnLogs.Width = 584;
            // 
            // dtpLogDate
            // 
            this.dtpLogDate.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.dtpLogDate.Location = new System.Drawing.Point(142, 53);
            this.dtpLogDate.Name = "dtpLogDate";
            this.dtpLogDate.Size = new System.Drawing.Size(397, 32);
            this.dtpLogDate.TabIndex = 1;
            this.dtpLogDate.ValueChanged += new System.EventHandler(this.dtpLogDate_ValueChanged);
            // 
            // comboLogType
            // 
            this.comboLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLogType.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboLogType.FormattingEnabled = true;
            this.comboLogType.Items.AddRange(new object[] {
            "None",
            "LoginAttempt",
            "Login",
            "Access",
            "Create",
            "Update",
            "Delete"});
            this.comboLogType.Location = new System.Drawing.Point(142, 114);
            this.comboLogType.Name = "comboLogType";
            this.comboLogType.Size = new System.Drawing.Size(397, 32);
            this.comboLogType.TabIndex = 2;
            this.comboLogType.SelectedIndexChanged += new System.EventHandler(this.comboLogType_SelectedIndexChanged);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlFilter.Controls.Add(this.comboStaffMember);
            this.pnlFilter.Controls.Add(this.pnlDivider3);
            this.pnlFilter.Controls.Add(this.lblStaffMember);
            this.pnlFilter.Controls.Add(this.pnlDivider1);
            this.pnlFilter.Controls.Add(this.comboLogType);
            this.pnlFilter.Controls.Add(this.dtpLogDate);
            this.pnlFilter.Controls.Add(this.lblLogType);
            this.pnlFilter.Controls.Add(this.lblFilterBy);
            this.pnlFilter.Controls.Add(this.lblDate);
            this.pnlFilter.Location = new System.Drawing.Point(623, 12);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(606, 226);
            this.pnlFilter.TabIndex = 48;
            // 
            // comboStaffMember
            // 
            this.comboStaffMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStaffMember.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.comboStaffMember.FormattingEnabled = true;
            this.comboStaffMember.Items.AddRange(new object[] {
            "None"});
            this.comboStaffMember.Location = new System.Drawing.Point(161, 177);
            this.comboStaffMember.Name = "comboStaffMember";
            this.comboStaffMember.Size = new System.Drawing.Size(378, 32);
            this.comboStaffMember.TabIndex = 49;
            this.comboStaffMember.SelectedIndexChanged += new System.EventHandler(this.comboStaffMember_SelectedIndexChanged);
            // 
            // pnlDivider3
            // 
            this.pnlDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider3.Location = new System.Drawing.Point(8, 164);
            this.pnlDivider3.Name = "pnlDivider3";
            this.pnlDivider3.Size = new System.Drawing.Size(570, 2);
            this.pnlDivider3.TabIndex = 48;
            // 
            // lblStaffMember
            // 
            this.lblStaffMember.AutoSize = true;
            this.lblStaffMember.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblStaffMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblStaffMember.Location = new System.Drawing.Point(18, 180);
            this.lblStaffMember.Name = "lblStaffMember";
            this.lblStaffMember.Size = new System.Drawing.Size(137, 24);
            this.lblStaffMember.TabIndex = 48;
            this.lblStaffMember.Text = "Staff member:";
            // 
            // pnlDivider1
            // 
            this.pnlDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider1.Location = new System.Drawing.Point(8, 99);
            this.pnlDivider1.Name = "pnlDivider1";
            this.pnlDivider1.Size = new System.Drawing.Size(570, 2);
            this.pnlDivider1.TabIndex = 47;
            // 
            // lblLogType
            // 
            this.lblLogType.AutoSize = true;
            this.lblLogType.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblLogType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblLogType.Location = new System.Drawing.Point(44, 117);
            this.lblLogType.Name = "lblLogType";
            this.lblLogType.Size = new System.Drawing.Size(92, 24);
            this.lblLogType.TabIndex = 35;
            this.lblLogType.Text = "Log type:";
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Bahnschrift", 17F);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblFilterBy.Location = new System.Drawing.Point(3, 9);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(112, 28);
            this.lblFilterBy.TabIndex = 33;
            this.lblFilterBy.Text = "Filter by...";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblDate.Location = new System.Drawing.Point(79, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 24);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "Date:";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnHelp.Location = new System.Drawing.Point(623, 642);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(606, 49);
            this.btnHelp.TabIndex = 62;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.lvLogs);
            this.Name = "frmLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.frmLogs_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.DateTimePicker dtpLogDate;
        private System.Windows.Forms.ComboBox comboLogType;
        private System.Windows.Forms.ColumnHeader columnLogs;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Label lblLogType;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlDivider3;
        private System.Windows.Forms.Label lblStaffMember;
        private System.Windows.Forms.ComboBox comboStaffMember;
        private System.Windows.Forms.Button btnHelp;
    }
}