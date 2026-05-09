namespace Cloud_FinalProject {
    partial class Launcher {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.textBox_LogInEmail = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_LogInPassword = new System.Windows.Forms.TextBox();
            this.btn_LogIn = new System.Windows.Forms.Button();
            this.btn_OpenRegisterForm = new System.Windows.Forms.Button();
            this.btn_LogInHideViewPass = new System.Windows.Forms.Button();
            this.label_Developers = new System.Windows.Forms.Label();
            this.btn_ForgetPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_LogInEmail
            // 
            this.textBox_LogInEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_LogInEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_LogInEmail.Font = new System.Drawing.Font("MS PGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LogInEmail.Location = new System.Drawing.Point(226, 248);
            this.textBox_LogInEmail.Name = "textBox_LogInEmail";
            this.textBox_LogInEmail.Size = new System.Drawing.Size(342, 28);
            this.textBox_LogInEmail.TabIndex = 0;
            this.textBox_LogInEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.BackColor = System.Drawing.Color.Transparent;
            this.label_Email.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Email.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Email.Location = new System.Drawing.Point(233, 226);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(82, 19);
            this.label_Email.TabIndex = 1;
            this.label_Email.Text = "Email:";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Password.Location = new System.Drawing.Point(233, 286);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(121, 19);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Password:";
            // 
            // textBox_LogInPassword
            // 
            this.textBox_LogInPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_LogInPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_LogInPassword.Font = new System.Drawing.Font("MS PGothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LogInPassword.Location = new System.Drawing.Point(226, 308);
            this.textBox_LogInPassword.Name = "textBox_LogInPassword";
            this.textBox_LogInPassword.Size = new System.Drawing.Size(342, 28);
            this.textBox_LogInPassword.TabIndex = 2;
            this.textBox_LogInPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LogInPassword.UseSystemPasswordChar = true;
            // 
            // btn_LogIn
            // 
            this.btn_LogIn.AutoSize = true;
            this.btn_LogIn.BackColor = System.Drawing.Color.Transparent;
            this.btn_LogIn.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_LogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LogIn.FlatAppearance.BorderSize = 0;
            this.btn_LogIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_LogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LogIn.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogIn.ForeColor = System.Drawing.Color.Black;
            this.btn_LogIn.Location = new System.Drawing.Point(445, 349);
            this.btn_LogIn.Name = "btn_LogIn";
            this.btn_LogIn.Size = new System.Drawing.Size(109, 45);
            this.btn_LogIn.TabIndex = 4;
            this.btn_LogIn.Text = "Log-In";
            this.btn_LogIn.UseVisualStyleBackColor = false;
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // btn_OpenRegisterForm
            // 
            this.btn_OpenRegisterForm.AutoSize = true;
            this.btn_OpenRegisterForm.BackColor = System.Drawing.Color.Transparent;
            this.btn_OpenRegisterForm.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_OpenRegisterForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OpenRegisterForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenRegisterForm.FlatAppearance.BorderSize = 0;
            this.btn_OpenRegisterForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OpenRegisterForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OpenRegisterForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenRegisterForm.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenRegisterForm.ForeColor = System.Drawing.Color.Black;
            this.btn_OpenRegisterForm.Location = new System.Drawing.Point(237, 349);
            this.btn_OpenRegisterForm.Name = "btn_OpenRegisterForm";
            this.btn_OpenRegisterForm.Size = new System.Drawing.Size(127, 45);
            this.btn_OpenRegisterForm.TabIndex = 5;
            this.btn_OpenRegisterForm.Text = "Register";
            this.btn_OpenRegisterForm.UseVisualStyleBackColor = false;
            this.btn_OpenRegisterForm.Click += new System.EventHandler(this.btn_OpenRegisterForm_Click);
            // 
            // btn_LogInHideViewPass
            // 
            this.btn_LogInHideViewPass.BackColor = System.Drawing.Color.Transparent;
            this.btn_LogInHideViewPass.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.view;
            this.btn_LogInHideViewPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_LogInHideViewPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LogInHideViewPass.FlatAppearance.BorderSize = 0;
            this.btn_LogInHideViewPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_LogInHideViewPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_LogInHideViewPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LogInHideViewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_LogInHideViewPass.ForeColor = System.Drawing.Color.Black;
            this.btn_LogInHideViewPass.Location = new System.Drawing.Point(574, 309);
            this.btn_LogInHideViewPass.Name = "btn_LogInHideViewPass";
            this.btn_LogInHideViewPass.Size = new System.Drawing.Size(26, 26);
            this.btn_LogInHideViewPass.TabIndex = 11;
            this.btn_LogInHideViewPass.UseVisualStyleBackColor = false;
            this.btn_LogInHideViewPass.Click += new System.EventHandler(this.btn_RegisterHideViewPass_Click);
            // 
            // label_Developers
            // 
            this.label_Developers.AutoSize = true;
            this.label_Developers.BackColor = System.Drawing.Color.Transparent;
            this.label_Developers.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Developers.ForeColor = System.Drawing.Color.Black;
            this.label_Developers.Location = new System.Drawing.Point(9, 641);
            this.label_Developers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Developers.Name = "label_Developers";
            this.label_Developers.Size = new System.Drawing.Size(77, 9);
            this.label_Developers.TabIndex = 12;
            this.label_Developers.Text = "Developed By:";
            this.label_Developers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ForgetPassword
            // 
            this.btn_ForgetPassword.AutoSize = true;
            this.btn_ForgetPassword.BackColor = System.Drawing.Color.Transparent;
            this.btn_ForgetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ForgetPassword.FlatAppearance.BorderSize = 0;
            this.btn_ForgetPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ForgetPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ForgetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ForgetPassword.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForgetPassword.ForeColor = System.Drawing.Color.Black;
            this.btn_ForgetPassword.Location = new System.Drawing.Point(302, 409);
            this.btn_ForgetPassword.Name = "btn_ForgetPassword";
            this.btn_ForgetPassword.Size = new System.Drawing.Size(204, 28);
            this.btn_ForgetPassword.TabIndex = 13;
            this.btn_ForgetPassword.Text = "Forget Password?";
            this.btn_ForgetPassword.UseVisualStyleBackColor = false;
            this.btn_ForgetPassword.Click += new System.EventHandler(this.btn_ForgetPassword_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.btn_ForgetPassword);
            this.Controls.Add(this.label_Developers);
            this.Controls.Add(this.btn_LogInHideViewPass);
            this.Controls.Add(this.btn_OpenRegisterForm);
            this.Controls.Add(this.btn_LogIn);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_LogInPassword);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.textBox_LogInEmail);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_LogInEmail;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_LogInPassword;
        private System.Windows.Forms.Button btn_LogIn;
        private System.Windows.Forms.Button btn_OpenRegisterForm;
        private System.Windows.Forms.Button btn_LogInHideViewPass;
        private System.Windows.Forms.Label label_Developers;
        private System.Windows.Forms.Button btn_ForgetPassword;
    }
}

