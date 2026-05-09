namespace Cloud_FinalProject {
    partial class SettingsForm {
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
            this.tabControl_Settings = new System.Windows.Forms.TabControl();
            this.tab_SaveDetails = new System.Windows.Forms.TabPage();
            this.btn_ExportSaveFile = new System.Windows.Forms.Button();
            this.btn_ResetPlayerData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ShowSaveDetails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_PlayerSaveDetails = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_ImportSave = new System.Windows.Forms.TabPage();
            this.btn_ImportSaveToCloud = new System.Windows.Forms.Button();
            this.btn_LoadSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_LoadedSaveDetails = new System.Windows.Forms.RichTextBox();
            this.tab_ChangePlayerDetails = new System.Windows.Forms.TabPage();
            this.btn_SaveChange = new System.Windows.Forms.Button();
            this.textBox_CurrentPassword = new System.Windows.Forms.TextBox();
            this.label_CurrentPassword = new System.Windows.Forms.Label();
            this.textBox_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_PlayerEmailVerification = new System.Windows.Forms.Label();
            this.btn_RegisterHideViewPass = new System.Windows.Forms.Button();
            this.label_EmailVerification = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_NewPassword = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label_Email = new System.Windows.Forms.Label();
            this.tabControl_Settings.SuspendLayout();
            this.tab_SaveDetails.SuspendLayout();
            this.tab_ImportSave.SuspendLayout();
            this.tab_ChangePlayerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tab_SaveDetails);
            this.tabControl_Settings.Controls.Add(this.tab_ImportSave);
            this.tabControl_Settings.Controls.Add(this.tab_ChangePlayerDetails);
            this.tabControl_Settings.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(613, 518);
            this.tabControl_Settings.TabIndex = 0;
            // 
            // tab_SaveDetails
            // 
            this.tab_SaveDetails.BackColor = System.Drawing.Color.DimGray;
            this.tab_SaveDetails.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_110430;
            this.tab_SaveDetails.Controls.Add(this.btn_ExportSaveFile);
            this.tab_SaveDetails.Controls.Add(this.btn_ResetPlayerData);
            this.tab_SaveDetails.Controls.Add(this.label3);
            this.tab_SaveDetails.Controls.Add(this.btn_ShowSaveDetails);
            this.tab_SaveDetails.Controls.Add(this.label2);
            this.tab_SaveDetails.Controls.Add(this.richTextBox_PlayerSaveDetails);
            this.tab_SaveDetails.Controls.Add(this.label1);
            this.tab_SaveDetails.Location = new System.Drawing.Point(4, 22);
            this.tab_SaveDetails.Name = "tab_SaveDetails";
            this.tab_SaveDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tab_SaveDetails.Size = new System.Drawing.Size(605, 492);
            this.tab_SaveDetails.TabIndex = 0;
            this.tab_SaveDetails.Text = "Save Details";
            // 
            // btn_ExportSaveFile
            // 
            this.btn_ExportSaveFile.AutoSize = true;
            this.btn_ExportSaveFile.BackColor = System.Drawing.Color.Transparent;
            this.btn_ExportSaveFile.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ExportSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ExportSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExportSaveFile.FlatAppearance.BorderSize = 0;
            this.btn_ExportSaveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ExportSaveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ExportSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportSaveFile.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportSaveFile.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportSaveFile.Location = new System.Drawing.Point(435, 7);
            this.btn_ExportSaveFile.Name = "btn_ExportSaveFile";
            this.btn_ExportSaveFile.Size = new System.Drawing.Size(160, 37);
            this.btn_ExportSaveFile.TabIndex = 7;
            this.btn_ExportSaveFile.Text = "Export File";
            this.btn_ExportSaveFile.UseVisualStyleBackColor = false;
            this.btn_ExportSaveFile.Click += new System.EventHandler(this.btn_ExportSaveFile_Click);
            // 
            // btn_ResetPlayerData
            // 
            this.btn_ResetPlayerData.AutoSize = true;
            this.btn_ResetPlayerData.BackColor = System.Drawing.Color.Transparent;
            this.btn_ResetPlayerData.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ResetPlayerData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ResetPlayerData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ResetPlayerData.FlatAppearance.BorderSize = 0;
            this.btn_ResetPlayerData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetPlayerData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetPlayerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetPlayerData.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetPlayerData.Location = new System.Drawing.Point(435, 450);
            this.btn_ResetPlayerData.Name = "btn_ResetPlayerData";
            this.btn_ResetPlayerData.Size = new System.Drawing.Size(153, 37);
            this.btn_ResetPlayerData.TabIndex = 6;
            this.btn_ResetPlayerData.Text = "Reset Data";
            this.btn_ResetPlayerData.UseVisualStyleBackColor = false;
            this.btn_ResetPlayerData.Click += new System.EventHandler(this.btn_ResetPlayerData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reset Player Data To Default:";
            // 
            // btn_ShowSaveDetails
            // 
            this.btn_ShowSaveDetails.AutoSize = true;
            this.btn_ShowSaveDetails.BackColor = System.Drawing.Color.Transparent;
            this.btn_ShowSaveDetails.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ShowSaveDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ShowSaveDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ShowSaveDetails.FlatAppearance.BorderSize = 0;
            this.btn_ShowSaveDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ShowSaveDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ShowSaveDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowSaveDetails.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowSaveDetails.ForeColor = System.Drawing.Color.Black;
            this.btn_ShowSaveDetails.Location = new System.Drawing.Point(435, 57);
            this.btn_ShowSaveDetails.Name = "btn_ShowSaveDetails";
            this.btn_ShowSaveDetails.Size = new System.Drawing.Size(160, 37);
            this.btn_ShowSaveDetails.TabIndex = 4;
            this.btn_ShowSaveDetails.Text = "Show Details";
            this.btn_ShowSaveDetails.UseVisualStyleBackColor = false;
            this.btn_ShowSaveDetails.Click += new System.EventHandler(this.btn_ShowSaveDetails_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your Save Details:";
            // 
            // richTextBox_PlayerSaveDetails
            // 
            this.richTextBox_PlayerSaveDetails.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_PlayerSaveDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_PlayerSaveDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBox_PlayerSaveDetails.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_PlayerSaveDetails.Location = new System.Drawing.Point(6, 102);
            this.richTextBox_PlayerSaveDetails.Name = "richTextBox_PlayerSaveDetails";
            this.richTextBox_PlayerSaveDetails.ReadOnly = true;
            this.richTextBox_PlayerSaveDetails.Size = new System.Drawing.Size(593, 342);
            this.richTextBox_PlayerSaveDetails.TabIndex = 2;
            this.richTextBox_PlayerSaveDetails.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export Save To Json File:";
            // 
            // tab_ImportSave
            // 
            this.tab_ImportSave.BackColor = System.Drawing.Color.DimGray;
            this.tab_ImportSave.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_110430;
            this.tab_ImportSave.Controls.Add(this.btn_ImportSaveToCloud);
            this.tab_ImportSave.Controls.Add(this.btn_LoadSave);
            this.tab_ImportSave.Controls.Add(this.label4);
            this.tab_ImportSave.Controls.Add(this.richTextBox_LoadedSaveDetails);
            this.tab_ImportSave.Location = new System.Drawing.Point(4, 22);
            this.tab_ImportSave.Name = "tab_ImportSave";
            this.tab_ImportSave.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ImportSave.Size = new System.Drawing.Size(605, 492);
            this.tab_ImportSave.TabIndex = 1;
            this.tab_ImportSave.Text = "Import Save";
            // 
            // btn_ImportSaveToCloud
            // 
            this.btn_ImportSaveToCloud.AutoSize = true;
            this.btn_ImportSaveToCloud.BackColor = System.Drawing.Color.Transparent;
            this.btn_ImportSaveToCloud.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ImportSaveToCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ImportSaveToCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ImportSaveToCloud.FlatAppearance.BorderSize = 0;
            this.btn_ImportSaveToCloud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ImportSaveToCloud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ImportSaveToCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportSaveToCloud.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ImportSaveToCloud.Location = new System.Drawing.Point(458, 451);
            this.btn_ImportSaveToCloud.Name = "btn_ImportSaveToCloud";
            this.btn_ImportSaveToCloud.Size = new System.Drawing.Size(140, 37);
            this.btn_ImportSaveToCloud.TabIndex = 8;
            this.btn_ImportSaveToCloud.Text = "Import Save";
            this.btn_ImportSaveToCloud.UseVisualStyleBackColor = false;
            this.btn_ImportSaveToCloud.Click += new System.EventHandler(this.btn_ImportSaveToCloud_Click);
            // 
            // btn_LoadSave
            // 
            this.btn_LoadSave.AutoSize = true;
            this.btn_LoadSave.BackColor = System.Drawing.Color.Transparent;
            this.btn_LoadSave.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_LoadSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_LoadSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LoadSave.FlatAppearance.BorderSize = 0;
            this.btn_LoadSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_LoadSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_LoadSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LoadSave.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadSave.Location = new System.Drawing.Point(467, 6);
            this.btn_LoadSave.Name = "btn_LoadSave";
            this.btn_LoadSave.Size = new System.Drawing.Size(128, 37);
            this.btn_LoadSave.TabIndex = 7;
            this.btn_LoadSave.Text = "Load Save";
            this.btn_LoadSave.UseVisualStyleBackColor = false;
            this.btn_LoadSave.Click += new System.EventHandler(this.btn_LoadSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Improt Save Details:";
            // 
            // richTextBox_LoadedSaveDetails
            // 
            this.richTextBox_LoadedSaveDetails.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LoadedSaveDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_LoadedSaveDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBox_LoadedSaveDetails.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_LoadedSaveDetails.Location = new System.Drawing.Point(6, 50);
            this.richTextBox_LoadedSaveDetails.Name = "richTextBox_LoadedSaveDetails";
            this.richTextBox_LoadedSaveDetails.ReadOnly = true;
            this.richTextBox_LoadedSaveDetails.Size = new System.Drawing.Size(593, 395);
            this.richTextBox_LoadedSaveDetails.TabIndex = 5;
            this.richTextBox_LoadedSaveDetails.Text = "";
            // 
            // tab_ChangePlayerDetails
            // 
            this.tab_ChangePlayerDetails.BackColor = System.Drawing.Color.DimGray;
            this.tab_ChangePlayerDetails.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.tab_ChangePlayerDetails.Controls.Add(this.btn_SaveChange);
            this.tab_ChangePlayerDetails.Controls.Add(this.textBox_CurrentPassword);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_CurrentPassword);
            this.tab_ChangePlayerDetails.Controls.Add(this.textBox_ConfirmPassword);
            this.tab_ChangePlayerDetails.Controls.Add(this.label5);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_PlayerEmailVerification);
            this.tab_ChangePlayerDetails.Controls.Add(this.btn_RegisterHideViewPass);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_EmailVerification);
            this.tab_ChangePlayerDetails.Controls.Add(this.textBox_UserName);
            this.tab_ChangePlayerDetails.Controls.Add(this.textBox_NewPassword);
            this.tab_ChangePlayerDetails.Controls.Add(this.textBox_Email);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_Password);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_UserName);
            this.tab_ChangePlayerDetails.Controls.Add(this.label_Email);
            this.tab_ChangePlayerDetails.Location = new System.Drawing.Point(4, 22);
            this.tab_ChangePlayerDetails.Name = "tab_ChangePlayerDetails";
            this.tab_ChangePlayerDetails.Size = new System.Drawing.Size(605, 492);
            this.tab_ChangePlayerDetails.TabIndex = 2;
            this.tab_ChangePlayerDetails.Text = "Player Details";
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
            this.btn_SaveChange.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveChange.Location = new System.Drawing.Point(493, 261);
            this.btn_SaveChange.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SaveChange.Name = "btn_SaveChange";
            this.btn_SaveChange.Size = new System.Drawing.Size(61, 34);
            this.btn_SaveChange.TabIndex = 26;
            this.btn_SaveChange.Text = "Save";
            this.btn_SaveChange.UseVisualStyleBackColor = false;
            this.btn_SaveChange.Click += new System.EventHandler(this.btn_SaveChange_Click);
            // 
            // textBox_CurrentPassword
            // 
            this.textBox_CurrentPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_CurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_CurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_CurrentPassword.Location = new System.Drawing.Point(217, 138);
            this.textBox_CurrentPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CurrentPassword.Name = "textBox_CurrentPassword";
            this.textBox_CurrentPassword.Size = new System.Drawing.Size(347, 28);
            this.textBox_CurrentPassword.TabIndex = 25;
            this.textBox_CurrentPassword.Text = "Current Password";
            this.textBox_CurrentPassword.Enter += new System.EventHandler(this.textBox_CurrentPassword_Enter);
            this.textBox_CurrentPassword.Leave += new System.EventHandler(this.textBox_CurrentPassword_Leave);
            // 
            // label_CurrentPassword
            // 
            this.label_CurrentPassword.AutoSize = true;
            this.label_CurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.label_CurrentPassword.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentPassword.Location = new System.Drawing.Point(20, 144);
            this.label_CurrentPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CurrentPassword.Name = "label_CurrentPassword";
            this.label_CurrentPassword.Size = new System.Drawing.Size(186, 15);
            this.label_CurrentPassword.TabIndex = 24;
            this.label_CurrentPassword.Text = "Current  Password:";
            // 
            // textBox_ConfirmPassword
            // 
            this.textBox_ConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_ConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_ConfirmPassword.Location = new System.Drawing.Point(217, 219);
            this.textBox_ConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ConfirmPassword.Name = "textBox_ConfirmPassword";
            this.textBox_ConfirmPassword.Size = new System.Drawing.Size(347, 28);
            this.textBox_ConfirmPassword.TabIndex = 23;
            this.textBox_ConfirmPassword.Text = "Confirm Password";
            this.textBox_ConfirmPassword.Enter += new System.EventHandler(this.textBox_ConfirmPassword_Enter);
            this.textBox_ConfirmPassword.Leave += new System.EventHandler(this.textBox_ConfirmPassword_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Confirm Password:";
            // 
            // label_PlayerEmailVerification
            // 
            this.label_PlayerEmailVerification.AutoSize = true;
            this.label_PlayerEmailVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PlayerEmailVerification.ForeColor = System.Drawing.Color.Lime;
            this.label_PlayerEmailVerification.Location = new System.Drawing.Point(568, 65);
            this.label_PlayerEmailVerification.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PlayerEmailVerification.Name = "label_PlayerEmailVerification";
            this.label_PlayerEmailVerification.Size = new System.Drawing.Size(0, 20);
            this.label_PlayerEmailVerification.TabIndex = 21;
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
            this.btn_RegisterHideViewPass.Location = new System.Drawing.Point(570, 138);
            this.btn_RegisterHideViewPass.Name = "btn_RegisterHideViewPass";
            this.btn_RegisterHideViewPass.Size = new System.Drawing.Size(27, 28);
            this.btn_RegisterHideViewPass.TabIndex = 20;
            this.btn_RegisterHideViewPass.UseVisualStyleBackColor = false;
            this.btn_RegisterHideViewPass.Click += new System.EventHandler(this.btn_RegisterHideViewPass_Click);
            // 
            // label_EmailVerification
            // 
            this.label_EmailVerification.AutoSize = true;
            this.label_EmailVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmailVerification.ForeColor = System.Drawing.Color.Lime;
            this.label_EmailVerification.Location = new System.Drawing.Point(584, 62);
            this.label_EmailVerification.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EmailVerification.Name = "label_EmailVerification";
            this.label_EmailVerification.Size = new System.Drawing.Size(0, 20);
            this.label_EmailVerification.TabIndex = 19;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserName.ForeColor = System.Drawing.Color.Black;
            this.textBox_UserName.Location = new System.Drawing.Point(217, 99);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(347, 28);
            this.textBox_UserName.TabIndex = 18;
            // 
            // textBox_NewPassword
            // 
            this.textBox_NewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_NewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBox_NewPassword.Location = new System.Drawing.Point(217, 178);
            this.textBox_NewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_NewPassword.Name = "textBox_NewPassword";
            this.textBox_NewPassword.Size = new System.Drawing.Size(347, 28);
            this.textBox_NewPassword.TabIndex = 17;
            this.textBox_NewPassword.Text = "Enter New Password";
            this.textBox_NewPassword.Enter += new System.EventHandler(this.textBox_NewPassword_Enter);
            this.textBox_NewPassword.Leave += new System.EventHandler(this.textBox_NewPassword_Leave);
            // 
            // textBox_Email
            // 
            this.textBox_Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email.ForeColor = System.Drawing.Color.Black;
            this.textBox_Email.Location = new System.Drawing.Point(217, 60);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(347, 28);
            this.textBox_Email.TabIndex = 16;
            this.textBox_Email.TextChanged += new System.EventHandler(this.textBox_Email_TextChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.Location = new System.Drawing.Point(20, 184);
            this.label_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(138, 15);
            this.label_Password.TabIndex = 15;
            this.label_Password.Text = "New Password:";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.BackColor = System.Drawing.Color.Transparent;
            this.label_UserName.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserName.Location = new System.Drawing.Point(20, 105);
            this.label_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(105, 15);
            this.label_UserName.TabIndex = 14;
            this.label_UserName.Text = "User Name:";
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.BackColor = System.Drawing.Color.Transparent;
            this.label_Email.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Email.Location = new System.Drawing.Point(20, 67);
            this.label_Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(68, 15);
            this.label_Email.TabIndex = 13;
            this.label_Email.Text = "Email:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_110430;
            this.ClientSize = new System.Drawing.Size(637, 542);
            this.Controls.Add(this.tabControl_Settings);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl_Settings.ResumeLayout(false);
            this.tab_SaveDetails.ResumeLayout(false);
            this.tab_SaveDetails.PerformLayout();
            this.tab_ImportSave.ResumeLayout(false);
            this.tab_ImportSave.PerformLayout();
            this.tab_ChangePlayerDetails.ResumeLayout(false);
            this.tab_ChangePlayerDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Settings;
        private System.Windows.Forms.TabPage tab_SaveDetails;
        private System.Windows.Forms.TabPage tab_ImportSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ResetPlayerData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ShowSaveDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_PlayerSaveDetails;
        private System.Windows.Forms.Button btn_ImportSaveToCloud;
        private System.Windows.Forms.Button btn_LoadSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_LoadedSaveDetails;
        private System.Windows.Forms.TabPage tab_ChangePlayerDetails;
        private System.Windows.Forms.Button btn_RegisterHideViewPass;
        private System.Windows.Forms.Label label_EmailVerification;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_NewPassword;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_PlayerEmailVerification;
        private System.Windows.Forms.TextBox textBox_CurrentPassword;
        private System.Windows.Forms.Label label_CurrentPassword;
        private System.Windows.Forms.TextBox textBox_ConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_SaveChange;
        private System.Windows.Forms.Button btn_ExportSaveFile;
    }
}