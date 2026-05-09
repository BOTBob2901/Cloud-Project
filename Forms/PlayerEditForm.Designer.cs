namespace Cloud_FinalProject.Forms {
    partial class PlayerEditForm {
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
            this.label_Email = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.richTextBox_EditSaveData = new System.Windows.Forms.RichTextBox();
            this.label_SaveDetails = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.btn_SaveChange = new System.Windows.Forms.Button();
            this.btn_CancelChange = new System.Windows.Forms.Button();
            this.label_Verification = new System.Windows.Forms.Label();
            this.label_EmailVerification = new System.Windows.Forms.Label();
            this.btn_RegisterHideViewPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.BackColor = System.Drawing.Color.Transparent;
            this.label_Email.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Email.Location = new System.Drawing.Point(11, 10);
            this.label_Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(68, 15);
            this.label_Email.TabIndex = 0;
            this.label_Email.Text = "Email:";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.BackColor = System.Drawing.Color.Transparent;
            this.label_UserName.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserName.Location = new System.Drawing.Point(11, 48);
            this.label_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(105, 15);
            this.label_UserName.TabIndex = 1;
            this.label_UserName.Text = "User Name:";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.Location = new System.Drawing.Point(10, 85);
            this.label_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(138, 15);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "New Password:";
            // 
            // richTextBox_EditSaveData
            // 
            this.richTextBox_EditSaveData.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox_EditSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_EditSaveData.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_EditSaveData.Location = new System.Drawing.Point(9, 162);
            this.richTextBox_EditSaveData.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_EditSaveData.Name = "richTextBox_EditSaveData";
            this.richTextBox_EditSaveData.Size = new System.Drawing.Size(605, 396);
            this.richTextBox_EditSaveData.TabIndex = 3;
            this.richTextBox_EditSaveData.Text = "";
            this.richTextBox_EditSaveData.TextChanged += new System.EventHandler(this.richTextBox_EditSaveData_TextChanged);
            // 
            // label_SaveDetails
            // 
            this.label_SaveDetails.AutoSize = true;
            this.label_SaveDetails.BackColor = System.Drawing.Color.Transparent;
            this.label_SaveDetails.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SaveDetails.Location = new System.Drawing.Point(10, 129);
            this.label_SaveDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SaveDetails.Name = "label_SaveDetails";
            this.label_SaveDetails.Size = new System.Drawing.Size(266, 15);
            this.label_SaveDetails.TabIndex = 4;
            this.label_SaveDetails.Text = "Player Save Details (Json):";
            // 
            // textBox_Email
            // 
            this.textBox_Email.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_Email.Location = new System.Drawing.Point(206, 3);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(376, 28);
            this.textBox_Email.TabIndex = 5;
            this.textBox_Email.TextChanged += new System.EventHandler(this.textBox_Email_TextChanged);
            this.textBox_Email.Enter += new System.EventHandler(this.textBox_Email_Enter);
            this.textBox_Email.Leave += new System.EventHandler(this.textBox_Email_Leave);
            // 
            // textBox_Password
            // 
            this.textBox_Password.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_Password.Location = new System.Drawing.Point(206, 81);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(376, 28);
            this.textBox_Password.TabIndex = 6;
            this.textBox_Password.Text = "Enter New Password";
            this.textBox_Password.Enter += new System.EventHandler(this.textBox_Password_Enter);
            this.textBox_Password.Leave += new System.EventHandler(this.textBox_Password_Leave);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_UserName.Location = new System.Drawing.Point(206, 42);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(376, 28);
            this.textBox_UserName.TabIndex = 7;
            this.textBox_UserName.Enter += new System.EventHandler(this.textBox_UserName_Enter);
            this.textBox_UserName.Leave += new System.EventHandler(this.textBox_UserName_Leave);
            // 
            // btn_SaveChange
            // 
            this.btn_SaveChange.AutoSize = true;
            this.btn_SaveChange.BackColor = System.Drawing.Color.Transparent;
            this.btn_SaveChange.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_SaveChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SaveChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveChange.FlatAppearance.BorderSize = 0;
            this.btn_SaveChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SaveChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_SaveChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveChange.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveChange.Location = new System.Drawing.Point(463, 123);
            this.btn_SaveChange.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SaveChange.Name = "btn_SaveChange";
            this.btn_SaveChange.Size = new System.Drawing.Size(57, 32);
            this.btn_SaveChange.TabIndex = 8;
            this.btn_SaveChange.Text = "Save";
            this.btn_SaveChange.UseVisualStyleBackColor = false;
            this.btn_SaveChange.Click += new System.EventHandler(this.btn_SaveChange_Click);
            // 
            // btn_CancelChange
            // 
            this.btn_CancelChange.AutoSize = true;
            this.btn_CancelChange.BackColor = System.Drawing.Color.Transparent;
            this.btn_CancelChange.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_CancelChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CancelChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelChange.FlatAppearance.BorderSize = 0;
            this.btn_CancelChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelChange.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelChange.Location = new System.Drawing.Point(537, 123);
            this.btn_CancelChange.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CancelChange.Name = "btn_CancelChange";
            this.btn_CancelChange.Size = new System.Drawing.Size(71, 32);
            this.btn_CancelChange.TabIndex = 9;
            this.btn_CancelChange.Text = "Cancel";
            this.btn_CancelChange.UseVisualStyleBackColor = false;
            this.btn_CancelChange.Click += new System.EventHandler(this.btn_CancelChange_Click);
            // 
            // label_Verification
            // 
            this.label_Verification.AutoSize = true;
            this.label_Verification.BackColor = System.Drawing.Color.Black;
            this.label_Verification.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Verification.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Verification.Location = new System.Drawing.Point(483, 171);
            this.label_Verification.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Verification.Name = "label_Verification";
            this.label_Verification.Size = new System.Drawing.Size(99, 12);
            this.label_Verification.TabIndex = 10;
            this.label_Verification.Text = "Not_Verified";
            // 
            // label_EmailVerification
            // 
            this.label_EmailVerification.AutoSize = true;
            this.label_EmailVerification.BackColor = System.Drawing.Color.Transparent;
            this.label_EmailVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmailVerification.ForeColor = System.Drawing.Color.Lime;
            this.label_EmailVerification.Location = new System.Drawing.Point(586, 5);
            this.label_EmailVerification.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EmailVerification.Name = "label_EmailVerification";
            this.label_EmailVerification.Size = new System.Drawing.Size(0, 20);
            this.label_EmailVerification.TabIndex = 11;
            // 
            // btn_RegisterHideViewPass
            // 
            this.btn_RegisterHideViewPass.BackColor = System.Drawing.Color.Transparent;
            this.btn_RegisterHideViewPass.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.view;
            this.btn_RegisterHideViewPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_RegisterHideViewPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RegisterHideViewPass.FlatAppearance.BorderSize = 0;
            this.btn_RegisterHideViewPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_RegisterHideViewPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_RegisterHideViewPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RegisterHideViewPass.ForeColor = System.Drawing.Color.Black;
            this.btn_RegisterHideViewPass.Location = new System.Drawing.Point(585, 81);
            this.btn_RegisterHideViewPass.Name = "btn_RegisterHideViewPass";
            this.btn_RegisterHideViewPass.Size = new System.Drawing.Size(27, 28);
            this.btn_RegisterHideViewPass.TabIndex = 12;
            this.btn_RegisterHideViewPass.UseVisualStyleBackColor = false;
            this.btn_RegisterHideViewPass.Click += new System.EventHandler(this.btn_RegisterHideViewPass_Click);
            // 
            // PlayerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.ClientSize = new System.Drawing.Size(622, 567);
            this.Controls.Add(this.btn_RegisterHideViewPass);
            this.Controls.Add(this.label_EmailVerification);
            this.Controls.Add(this.label_Verification);
            this.Controls.Add(this.btn_CancelChange);
            this.Controls.Add(this.btn_SaveChange);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label_SaveDetails);
            this.Controls.Add(this.richTextBox_EditSaveData);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.label_Email);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlayerEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerEditForm";
            this.Load += new System.EventHandler(this.PlayerEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.RichTextBox richTextBox_EditSaveData;
        private System.Windows.Forms.Label label_SaveDetails;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Button btn_SaveChange;
        private System.Windows.Forms.Button btn_CancelChange;
        private System.Windows.Forms.Label label_Verification;
        private System.Windows.Forms.Label label_EmailVerification;
        private System.Windows.Forms.Button btn_RegisterHideViewPass;
    }
}