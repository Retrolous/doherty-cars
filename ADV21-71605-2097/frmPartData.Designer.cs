
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmPartData
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
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPartID = new System.Windows.Forms.Label();
            this.txtPartID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.pnlDivider3 = new System.Windows.Forms.Panel();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numSellPrice = new System.Windows.Forms.NumericUpDown();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.numBuyPrice = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.pnlCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.AllowUserToResizeColumns = false;
            this.dgvParts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvParts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(28)))));
            this.dgvParts.Location = new System.Drawing.Point(12, 9);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowTemplate.Height = 25;
            this.dgvParts.RowTemplate.ReadOnly = true;
            this.dgvParts.Size = new System.Drawing.Size(1220, 487);
            this.dgvParts.TabIndex = 16;
            this.dgvParts.SelectionChanged += new System.EventHandler(this.dgvParts_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnAdd.Location = new System.Drawing.Point(663, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(168, 50);
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
            this.btnDelete.Location = new System.Drawing.Point(663, 127);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 50);
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
            this.btnSave.Location = new System.Drawing.Point(663, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 49);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPartID
            // 
            this.lblPartID.AutoSize = true;
            this.lblPartID.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblPartID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblPartID.Location = new System.Drawing.Point(15, 8);
            this.lblPartID.Name = "lblPartID";
            this.lblPartID.Size = new System.Drawing.Size(77, 24);
            this.lblPartID.TabIndex = 43;
            this.lblPartID.Text = "Part ID:";
            // 
            // txtPartID
            // 
            this.txtPartID.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.txtPartID.Location = new System.Drawing.Point(93, 5);
            this.txtPartID.Name = "txtPartID";
            this.txtPartID.ReadOnly = true;
            this.txtPartID.Size = new System.Drawing.Size(141, 32);
            this.txtPartID.TabIndex = 42;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.txtName.Location = new System.Drawing.Point(93, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 32);
            this.txtName.TabIndex = 40;
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblBuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblBuyPrice.Location = new System.Drawing.Point(15, 103);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(100, 24);
            this.lblBuyPrice.TabIndex = 36;
            this.lblBuyPrice.Text = "Buy price:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblName.Location = new System.Drawing.Point(19, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 24);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Name:";
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(60)))), ((int)(((byte)(55)))));
            this.pnlCRUD.Controls.Add(this.pnlDivider3);
            this.pnlCRUD.Controls.Add(this.numQuantity);
            this.pnlCRUD.Controls.Add(this.lblQuantity);
            this.pnlCRUD.Controls.Add(this.numSellPrice);
            this.pnlCRUD.Controls.Add(this.lblSellPrice);
            this.pnlCRUD.Controls.Add(this.numBuyPrice);
            this.pnlCRUD.Controls.Add(this.btnReset);
            this.pnlCRUD.Controls.Add(this.pnlDivider2);
            this.pnlCRUD.Controls.Add(this.pnlDivider1);
            this.pnlCRUD.Controls.Add(this.lblName);
            this.pnlCRUD.Controls.Add(this.txtPartID);
            this.pnlCRUD.Controls.Add(this.lblBuyPrice);
            this.pnlCRUD.Controls.Add(this.lblPartID);
            this.pnlCRUD.Controls.Add(this.txtName);
            this.pnlCRUD.Controls.Add(this.btnDelete);
            this.pnlCRUD.Controls.Add(this.btnAdd);
            this.pnlCRUD.Controls.Add(this.btnSave);
            this.pnlCRUD.Location = new System.Drawing.Point(12, 502);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(836, 193);
            this.pnlCRUD.TabIndex = 47;
            // 
            // pnlDivider3
            // 
            this.pnlDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlDivider3.Location = new System.Drawing.Point(375, 51);
            this.pnlDivider3.Name = "pnlDivider3";
            this.pnlDivider3.Size = new System.Drawing.Size(270, 2);
            this.pnlDivider3.TabIndex = 48;
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.numQuantity.Location = new System.Drawing.Point(491, 10);
            this.numQuantity.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 32);
            this.numQuantity.TabIndex = 65;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblQuantity.Location = new System.Drawing.Point(396, 13);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(89, 24);
            this.lblQuantity.TabIndex = 64;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.UseWaitCursor = true;
            // 
            // numSellPrice
            // 
            this.numSellPrice.DecimalPlaces = 2;
            this.numSellPrice.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.numSellPrice.Location = new System.Drawing.Point(121, 145);
            this.numSellPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSellPrice.Name = "numSellPrice";
            this.numSellPrice.Size = new System.Drawing.Size(248, 32);
            this.numSellPrice.TabIndex = 63;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblSellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSellPrice.Location = new System.Drawing.Point(15, 147);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(101, 24);
            this.lblSellPrice.TabIndex = 62;
            this.lblSellPrice.Text = "Sell price:";
            // 
            // numBuyPrice
            // 
            this.numBuyPrice.DecimalPlaces = 2;
            this.numBuyPrice.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.numBuyPrice.Location = new System.Drawing.Point(121, 101);
            this.numBuyPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numBuyPrice.Name = "numBuyPrice";
            this.numBuyPrice.Size = new System.Drawing.Size(248, 32);
            this.numBuyPrice.TabIndex = 61;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnReset.Location = new System.Drawing.Point(400, 145);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(168, 35);
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
            this.pnlSearch.Size = new System.Drawing.Size(378, 133);
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
            this.btnHelp.Location = new System.Drawing.Point(854, 646);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(378, 49);
            this.btnHelp.TabIndex = 62;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPartData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlCRUD);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPartData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part Data";
            this.Load += new System.EventHandler(this.frmPartData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.pnlCRUD.ResumeLayout(false);
            this.pnlCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPartID;
        private System.Windows.Forms.TextBox txtPartID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBuyPrice;
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
        private System.Windows.Forms.NumericUpDown numBuyPrice;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numSellPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Panel pnlDivider3;
        private System.Windows.Forms.Button btnHelp;
    }
}