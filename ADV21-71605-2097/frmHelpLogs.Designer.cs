
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmHelpLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelpLogs));
            this.lblSearchingInfo = new System.Windows.Forms.Label();
            this.lblUpdatingInfo = new System.Windows.Forms.Label();
            this.lblSearching = new System.Windows.Forms.Label();
            this.lblUpdating = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSearchingInfo
            // 
            this.lblSearchingInfo.AutoSize = true;
            this.lblSearchingInfo.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.lblSearchingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblSearchingInfo.Location = new System.Drawing.Point(12, 168);
            this.lblSearchingInfo.MaximumSize = new System.Drawing.Size(460, 0);
            this.lblSearchingInfo.MinimumSize = new System.Drawing.Size(460, 0);
            this.lblSearchingInfo.Name = "lblSearchingInfo";
            this.lblSearchingInfo.Size = new System.Drawing.Size(460, 51);
            this.lblSearchingInfo.TabIndex = 7;
            this.lblSearchingInfo.Text = "To find logs against stricter criteria, you may choose the desired action or staf" +
    "f member to filter by, and the log list will update as required.";
            // 
            // lblUpdatingInfo
            // 
            this.lblUpdatingInfo.AutoSize = true;
            this.lblUpdatingInfo.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.lblUpdatingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblUpdatingInfo.Location = new System.Drawing.Point(13, 46);
            this.lblUpdatingInfo.MaximumSize = new System.Drawing.Size(460, 0);
            this.lblUpdatingInfo.MinimumSize = new System.Drawing.Size(460, 0);
            this.lblUpdatingInfo.Name = "lblUpdatingInfo";
            this.lblUpdatingInfo.Size = new System.Drawing.Size(460, 68);
            this.lblUpdatingInfo.TabIndex = 6;
            this.lblUpdatingInfo.Text = resources.GetString("lblUpdatingInfo.Text");
            // 
            // lblSearching
            // 
            this.lblSearching.AutoSize = true;
            this.lblSearching.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblSearching.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblSearching.Location = new System.Drawing.Point(12, 130);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(132, 22);
            this.lblSearching.TabIndex = 5;
            this.lblSearching.Text = "Searching logs";
            // 
            // lblUpdating
            // 
            this.lblUpdating.AutoSize = true;
            this.lblUpdating.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lblUpdating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblUpdating.Location = new System.Drawing.Point(12, 9);
            this.lblUpdating.Name = "lblUpdating";
            this.lblUpdating.Size = new System.Drawing.Size(114, 22);
            this.lblUpdating.TabIndex = 4;
            this.lblUpdating.Text = "Viewing logs";
            // 
            // frmHelpLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(483, 228);
            this.Controls.Add(this.lblSearchingInfo);
            this.Controls.Add(this.lblUpdatingInfo);
            this.Controls.Add(this.lblSearching);
            this.Controls.Add(this.lblUpdating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHelpLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Deactivate += new System.EventHandler(this.frmHelpLogs_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchingInfo;
        private System.Windows.Forms.Label lblUpdatingInfo;
        private System.Windows.Forms.Label lblSearching;
        private System.Windows.Forms.Label lblUpdating;
    }
}