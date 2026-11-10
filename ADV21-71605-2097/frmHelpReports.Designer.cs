
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmHelpReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelpReports));
            this.lblUpdatingInfo = new System.Windows.Forms.Label();
            this.lblUpdating = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUpdatingInfo
            // 
            this.lblUpdatingInfo.AutoSize = true;
            this.lblUpdatingInfo.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.lblUpdatingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblUpdatingInfo.Location = new System.Drawing.Point(13, 40);
            this.lblUpdatingInfo.MaximumSize = new System.Drawing.Size(460, 0);
            this.lblUpdatingInfo.MinimumSize = new System.Drawing.Size(460, 0);
            this.lblUpdatingInfo.Name = "lblUpdatingInfo";
            this.lblUpdatingInfo.Size = new System.Drawing.Size(460, 187);
            this.lblUpdatingInfo.TabIndex = 10;
            this.lblUpdatingInfo.Text = resources.GetString("lblUpdatingInfo.Text");
            // 
            // lblUpdating
            // 
            this.lblUpdating.AutoSize = true;
            this.lblUpdating.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblUpdating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblUpdating.Location = new System.Drawing.Point(12, 9);
            this.lblUpdating.Name = "lblUpdating";
            this.lblUpdating.Size = new System.Drawing.Size(141, 22);
            this.lblUpdating.TabIndex = 8;
            this.lblUpdating.Text = "Viewing reports";
            // 
            // frmHelpReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(485, 224);
            this.Controls.Add(this.lblUpdatingInfo);
            this.Controls.Add(this.lblUpdating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHelpReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Deactivate += new System.EventHandler(this.frmHelpReports_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdatingInfo;
        private System.Windows.Forms.Label lblUpdating;
    }
}