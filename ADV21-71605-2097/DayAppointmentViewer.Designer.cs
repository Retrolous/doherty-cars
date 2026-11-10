
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class DayAppointmentViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDay = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlDay
            // 
            this.pnlDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.pnlDay.Location = new System.Drawing.Point(3, 3);
            this.pnlDay.Name = "pnlDay";
            this.pnlDay.Size = new System.Drawing.Size(1194, 348);
            this.pnlDay.TabIndex = 0;
            this.pnlDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDay_MouseDown);
            this.pnlDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDay_MouseMove);
            this.pnlDay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDay_MouseUp);
            // 
            // DayAppointmentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.Controls.Add(this.pnlDay);
            this.Name = "DayAppointmentViewer";
            this.Size = new System.Drawing.Size(1200, 355);
            this.Load += new System.EventHandler(this.DayAppointments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDay;
    }
}
