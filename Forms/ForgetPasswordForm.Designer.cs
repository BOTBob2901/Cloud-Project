namespace Cloud_FinalProject.Forms
{
    partial class ForgetPasswordForm
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
            this.btn_CancelRestore = new System.Windows.Forms.Button();
            this.btn_ConfirmRestore = new System.Windows.Forms.Button();
            this.textBox_EmailForPasswordRestore = new System.Windows.Forms.TextBox();
            this.label_RegisterConfirmPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_CancelRestore
            // 
            this.btn_CancelRestore.AutoSize = true;
            this.btn_CancelRestore.BackColor = System.Drawing.Color.Transparent;
            this.btn_CancelRestore.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_CancelRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CancelRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelRestore.FlatAppearance.BorderSize = 0;
            this.btn_CancelRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelRestore.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelRestore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_CancelRestore.Location = new System.Drawing.Point(63, 120);
            this.btn_CancelRestore.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CancelRestore.Name = "btn_CancelRestore";
            this.btn_CancelRestore.Size = new System.Drawing.Size(89, 36);
            this.btn_CancelRestore.TabIndex = 13;
            this.btn_CancelRestore.Text = "Cancel";
            this.btn_CancelRestore.UseVisualStyleBackColor = false;
            this.btn_CancelRestore.Click += new System.EventHandler(this.btn_CancelRestore_Click);
            // 
            // btn_ConfirmRestore
            // 
            this.btn_ConfirmRestore.AutoSize = true;
            this.btn_ConfirmRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(212)))), ((int)(((byte)(112)))));
            this.btn_ConfirmRestore.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ConfirmRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ConfirmRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConfirmRestore.FlatAppearance.BorderSize = 0;
            this.btn_ConfirmRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ConfirmRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ConfirmRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConfirmRestore.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConfirmRestore.Location = new System.Drawing.Point(226, 120);
            this.btn_ConfirmRestore.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ConfirmRestore.Name = "btn_ConfirmRestore";
            this.btn_ConfirmRestore.Size = new System.Drawing.Size(101, 36);
            this.btn_ConfirmRestore.TabIndex = 12;
            this.btn_ConfirmRestore.Text = "Restore";
            this.btn_ConfirmRestore.UseVisualStyleBackColor = false;
            this.btn_ConfirmRestore.Click += new System.EventHandler(this.btn_ConfirmRestore_Click);
            // 
            // textBox_EmailForPasswordRestore
            // 
            this.textBox_EmailForPasswordRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_EmailForPasswordRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_EmailForPasswordRestore.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_EmailForPasswordRestore.Location = new System.Drawing.Point(54, 72);
            this.textBox_EmailForPasswordRestore.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_EmailForPasswordRestore.Name = "textBox_EmailForPasswordRestore";
            this.textBox_EmailForPasswordRestore.Size = new System.Drawing.Size(284, 26);
            this.textBox_EmailForPasswordRestore.TabIndex = 11;
            this.textBox_EmailForPasswordRestore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_RegisterConfirmPassword
            // 
            this.label_RegisterConfirmPassword.AutoSize = true;
            this.label_RegisterConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.label_RegisterConfirmPassword.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RegisterConfirmPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_RegisterConfirmPassword.Location = new System.Drawing.Point(59, 29);
            this.label_RegisterConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_RegisterConfirmPassword.Name = "label_RegisterConfirmPassword";
            this.label_RegisterConfirmPassword.Size = new System.Drawing.Size(82, 19);
            this.label_RegisterConfirmPassword.TabIndex = 10;
            this.label_RegisterConfirmPassword.Text = "Email:";
            // 
            // ForgetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.ClientSize = new System.Drawing.Size(388, 202);
            this.Controls.Add(this.btn_CancelRestore);
            this.Controls.Add(this.btn_ConfirmRestore);
            this.Controls.Add(this.textBox_EmailForPasswordRestore);
            this.Controls.Add(this.label_RegisterConfirmPassword);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForgetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forget Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CancelRestore;
        private System.Windows.Forms.Button btn_ConfirmRestore;
        private System.Windows.Forms.TextBox textBox_EmailForPasswordRestore;
        private System.Windows.Forms.Label label_RegisterConfirmPassword;
    }
}