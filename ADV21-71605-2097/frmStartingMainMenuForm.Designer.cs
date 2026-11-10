
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmStartingMainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartingMainMenuForm));
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictLogo = new System.Windows.Forms.PictureBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).BeginInit();
            this.pnlImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Bahnschrift", 30F);
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblWelcomeMessage.Location = new System.Drawing.Point(26, 27);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(201, 48);
            this.lblWelcomeMessage.TabIndex = 0;
            this.lblWelcomeMessage.Text = "Welcome, ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Bahnschrift", 30F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblDate.Location = new System.Drawing.Point(26, 88);
            this.lblDate.MaximumSize = new System.Drawing.Size(473, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(97, 48);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "It is ";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Bahnschrift", 30F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblRole.Location = new System.Drawing.Point(26, 519);
            this.lblRole.MaximumSize = new System.Drawing.Size(473, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(473, 48);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "You are logged in as a(n) ";
            // 
            // pictLogo
            // 
            this.pictLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictLogo.Image")));
            this.pictLogo.Location = new System.Drawing.Point(17, 18);
            this.pictLogo.Name = "pictLogo";
            this.pictLogo.Size = new System.Drawing.Size(693, 696);
            this.pictLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictLogo.TabIndex = 5;
            this.pictLogo.TabStop = false;
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(31)))));
            this.pnlImage.Controls.Add(this.pictLogo);
            this.pnlImage.Location = new System.Drawing.Point(576, -6);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(862, 833);
            this.pnlImage.TabIndex = 6;
            // 
            // frmStartingMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblWelcomeMessage);
            this.Controls.Add(this.pnlImage);
            this.Name = "frmStartingMainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting Form";
            this.Load += new System.EventHandler(this.frmStartingMainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).EndInit();
            this.pnlImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictLogo;
        private System.Windows.Forms.Panel pnlImage;
    }
}