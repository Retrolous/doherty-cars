
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmInProgress
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
            this.lblHey = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHey
            // 
            this.lblHey.AutoSize = true;
            this.lblHey.Font = new System.Drawing.Font("Bahnschrift", 80F);
            this.lblHey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblHey.Location = new System.Drawing.Point(475, 231);
            this.lblHey.Name = "lblHey";
            this.lblHey.Size = new System.Drawing.Size(275, 128);
            this.lblHey.TabIndex = 0;
            this.lblHey.Text = "HEY!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 40F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.label1.Location = new System.Drawing.Point(134, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(964, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "This form is currently being developed.";
            // 
            // frmInProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1241, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHey);
            this.Name = "frmInProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHey;
        private System.Windows.Forms.Label label1;
    }
}