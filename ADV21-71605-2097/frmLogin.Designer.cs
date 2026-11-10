
namespace Petkunas__Lukas___Doherty_Cars
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkToggleHide = new System.Windows.Forms.CheckBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnUser1 = new System.Windows.Forms.Button();
            this.btnUser2 = new System.Windows.Forms.Button();
            this.btnUser3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).BeginInit();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.btnLogin.Location = new System.Drawing.Point(25, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(343, 49);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUsername.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F);
            this.txtUsername.Location = new System.Drawing.Point(135, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 30);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPassword.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.Location = new System.Drawing.Point(135, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(233, 30);
            this.txtPassword.TabIndex = 3;
            // 
            // pictLogo
            // 
            this.pictLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictLogo.Image")));
            this.pictLogo.Location = new System.Drawing.Point(-24, -106);
            this.pictLogo.Name = "pictLogo";
            this.pictLogo.Size = new System.Drawing.Size(485, 473);
            this.pictLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictLogo.TabIndex = 4;
            this.pictLogo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblUsername.Location = new System.Drawing.Point(21, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(108, 24);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Bahnschrift", 15F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.lblPassword.Location = new System.Drawing.Point(21, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(104, 24);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // chkToggleHide
            // 
            this.chkToggleHide.AutoSize = true;
            this.chkToggleHide.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.chkToggleHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.chkToggleHide.Location = new System.Drawing.Point(224, 83);
            this.chkToggleHide.Name = "chkToggleHide";
            this.chkToggleHide.Size = new System.Drawing.Size(144, 23);
            this.chkToggleHide.TabIndex = 9;
            this.chkToggleHide.Text = "Show Password";
            this.chkToggleHide.UseVisualStyleBackColor = true;
            this.chkToggleHide.CheckedChanged += new System.EventHandler(this.chkToggleHide_CheckedChanged);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.chkToggleHide);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Location = new System.Drawing.Point(12, 267);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(392, 170);
            this.pnlLogin.TabIndex = 10;
            // 
            // btnUser1
            // 
            this.btnUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.btnUser1.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.btnUser1.Location = new System.Drawing.Point(13, 444);
            this.btnUser1.Name = "btnUser1";
            this.btnUser1.Size = new System.Drawing.Size(195, 53);
            this.btnUser1.TabIndex = 11;
            this.btnUser1.Text = "Username - patdoh\r\nPassword - Password1.\r\nRole - Administrator";
            this.btnUser1.UseVisualStyleBackColor = false;
            this.btnUser1.Click += new System.EventHandler(this.btnUser1_Click);
            // 
            // btnUser2
            // 
            this.btnUser2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.btnUser2.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.btnUser2.Location = new System.Drawing.Point(209, 444);
            this.btnUser2.Name = "btnUser2";
            this.btnUser2.Size = new System.Drawing.Size(195, 53);
            this.btnUser2.TabIndex = 12;
            this.btnUser2.Text = "Username - ethanh1\r\nPassword - ethanh1.\r\nRole - Mechanic\r\n";
            this.btnUser2.UseVisualStyleBackColor = false;
            this.btnUser2.Click += new System.EventHandler(this.btnUser2_Click);
            // 
            // btnUser3
            // 
            this.btnUser3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(48)))));
            this.btnUser3.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.btnUser3.Location = new System.Drawing.Point(12, 501);
            this.btnUser3.Name = "btnUser3";
            this.btnUser3.Size = new System.Drawing.Size(195, 53);
            this.btnUser3.TabIndex = 13;
            this.btnUser3.Text = "Username - ellar\r\nPassword - financial\r\nRole - Finance Staff\r\n";
            this.btnUser3.UseVisualStyleBackColor = false;
            this.btnUser3.Click += new System.EventHandler(this.btnUser3_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(416, 566);
            this.Controls.Add(this.btnUser3);
            this.Controls.Add(this.btnUser2);
            this.Controls.Add(this.btnUser1);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pictLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log-in";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictLogo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkToggleHide;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnUser1;
        private System.Windows.Forms.Button btnUser2;
        private System.Windows.Forms.Button btnUser3;
    }
}

