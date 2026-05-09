namespace Cloud_FinalProject.Forms {
    partial class AdminPanel {
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
            this.tabPage_SaveDetails = new System.Windows.Forms.TabPage();
            this.btn_ExportSaveFile = new System.Windows.Forms.Button();
            this.btn_ResetPlayerData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ShowSaveDetails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_PlayerSaveDetails = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_ImportSave = new System.Windows.Forms.TabPage();
            this.btn_ImportSaveToCloud = new System.Windows.Forms.Button();
            this.btn_LoadSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_LoadedSaveDetails = new System.Windows.Forms.RichTextBox();
            this.tabPage_PlayerInfoByEmail = new System.Windows.Forms.TabPage();
            this.btn_GetAllPlayers = new System.Windows.Forms.Button();
            this.btn_SearchPlayerByEmail = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_SearchEmail = new System.Windows.Forms.TextBox();
            this.dataGridView_PlayerByEmail = new System.Windows.Forms.DataGridView();
            this.tabPage_LogDisplay = new System.Windows.Forms.TabPage();
            this.btn_DisplayExceptionLog = new System.Windows.Forms.Button();
            this.richTextBox_LogDisplay = new System.Windows.Forms.RichTextBox();
            this.btn_ClearLogBox = new System.Windows.Forms.Button();
            this.btn_DisplayGeneralLog = new System.Windows.Forms.Button();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_SaveDetails.SuspendLayout();
            this.tabPage_ImportSave.SuspendLayout();
            this.tabPage_PlayerInfoByEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlayerByEmail)).BeginInit();
            this.tabPage_LogDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tabPage_SaveDetails);
            this.tabControl_Settings.Controls.Add(this.tabPage_ImportSave);
            this.tabControl_Settings.Controls.Add(this.tabPage_PlayerInfoByEmail);
            this.tabControl_Settings.Controls.Add(this.tabPage_LogDisplay);
            this.tabControl_Settings.Location = new System.Drawing.Point(10, 11);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(742, 523);
            this.tabControl_Settings.TabIndex = 1;
            // 
            // tabPage_SaveDetails
            // 
            this.tabPage_SaveDetails.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_SaveDetails.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.tabPage_SaveDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage_SaveDetails.Controls.Add(this.btn_ExportSaveFile);
            this.tabPage_SaveDetails.Controls.Add(this.btn_ResetPlayerData);
            this.tabPage_SaveDetails.Controls.Add(this.label3);
            this.tabPage_SaveDetails.Controls.Add(this.btn_ShowSaveDetails);
            this.tabPage_SaveDetails.Controls.Add(this.label2);
            this.tabPage_SaveDetails.Controls.Add(this.richTextBox_PlayerSaveDetails);
            this.tabPage_SaveDetails.Controls.Add(this.label1);
            this.tabPage_SaveDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SaveDetails.Name = "tabPage_SaveDetails";
            this.tabPage_SaveDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SaveDetails.Size = new System.Drawing.Size(734, 497);
            this.tabPage_SaveDetails.TabIndex = 0;
            this.tabPage_SaveDetails.Text = "Save Details";
            // 
            // btn_ExportSaveFile
            // 
            this.btn_ExportSaveFile.AutoSize = true;
            this.btn_ExportSaveFile.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ExportSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ExportSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExportSaveFile.FlatAppearance.BorderSize = 0;
            this.btn_ExportSaveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ExportSaveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ExportSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportSaveFile.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportSaveFile.Location = new System.Drawing.Point(559, 7);
            this.btn_ExportSaveFile.Name = "btn_ExportSaveFile";
            this.btn_ExportSaveFile.Size = new System.Drawing.Size(160, 37);
            this.btn_ExportSaveFile.TabIndex = 7;
            this.btn_ExportSaveFile.Text = "Export File";
            this.btn_ExportSaveFile.UseVisualStyleBackColor = true;
            this.btn_ExportSaveFile.Click += new System.EventHandler(this.btn_ExportSaveFile_Click);
            // 
            // btn_ResetPlayerData
            // 
            this.btn_ResetPlayerData.AutoSize = true;
            this.btn_ResetPlayerData.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ResetPlayerData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ResetPlayerData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ResetPlayerData.FlatAppearance.BorderSize = 0;
            this.btn_ResetPlayerData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetPlayerData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetPlayerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetPlayerData.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetPlayerData.Location = new System.Drawing.Point(599, 443);
            this.btn_ResetPlayerData.Name = "btn_ResetPlayerData";
            this.btn_ResetPlayerData.Size = new System.Drawing.Size(120, 37);
            this.btn_ResetPlayerData.TabIndex = 6;
            this.btn_ResetPlayerData.Text = "Reset Data";
            this.btn_ResetPlayerData.UseVisualStyleBackColor = true;
            this.btn_ResetPlayerData.Click += new System.EventHandler(this.btn_ResetPlayerData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reset Player Data To Default:";
            // 
            // btn_ShowSaveDetails
            // 
            this.btn_ShowSaveDetails.AutoSize = true;
            this.btn_ShowSaveDetails.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ShowSaveDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ShowSaveDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ShowSaveDetails.FlatAppearance.BorderSize = 0;
            this.btn_ShowSaveDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ShowSaveDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ShowSaveDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowSaveDetails.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowSaveDetails.Location = new System.Drawing.Point(559, 57);
            this.btn_ShowSaveDetails.Name = "btn_ShowSaveDetails";
            this.btn_ShowSaveDetails.Size = new System.Drawing.Size(160, 37);
            this.btn_ShowSaveDetails.TabIndex = 4;
            this.btn_ShowSaveDetails.Text = "Show Details";
            this.btn_ShowSaveDetails.UseVisualStyleBackColor = true;
            this.btn_ShowSaveDetails.Click += new System.EventHandler(this.btn_ShowSaveDetails_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your Save Details:";
            // 
            // richTextBox_PlayerSaveDetails
            // 
            this.richTextBox_PlayerSaveDetails.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_PlayerSaveDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_PlayerSaveDetails.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_PlayerSaveDetails.Location = new System.Drawing.Point(6, 102);
            this.richTextBox_PlayerSaveDetails.Name = "richTextBox_PlayerSaveDetails";
            this.richTextBox_PlayerSaveDetails.ReadOnly = true;
            this.richTextBox_PlayerSaveDetails.Size = new System.Drawing.Size(722, 285);
            this.richTextBox_PlayerSaveDetails.TabIndex = 2;
            this.richTextBox_PlayerSaveDetails.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export Save To Json File:";
            // 
            // tabPage_ImportSave
            // 
            this.tabPage_ImportSave.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_ImportSave.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.tabPage_ImportSave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage_ImportSave.Controls.Add(this.btn_ImportSaveToCloud);
            this.tabPage_ImportSave.Controls.Add(this.btn_LoadSave);
            this.tabPage_ImportSave.Controls.Add(this.label4);
            this.tabPage_ImportSave.Controls.Add(this.richTextBox_LoadedSaveDetails);
            this.tabPage_ImportSave.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ImportSave.Name = "tabPage_ImportSave";
            this.tabPage_ImportSave.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ImportSave.Size = new System.Drawing.Size(734, 497);
            this.tabPage_ImportSave.TabIndex = 1;
            this.tabPage_ImportSave.Text = "Import Save";
            // 
            // btn_ImportSaveToCloud
            // 
            this.btn_ImportSaveToCloud.AutoSize = true;
            this.btn_ImportSaveToCloud.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ImportSaveToCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ImportSaveToCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ImportSaveToCloud.FlatAppearance.BorderSize = 0;
            this.btn_ImportSaveToCloud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ImportSaveToCloud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ImportSaveToCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportSaveToCloud.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ImportSaveToCloud.Location = new System.Drawing.Point(579, 451);
            this.btn_ImportSaveToCloud.Name = "btn_ImportSaveToCloud";
            this.btn_ImportSaveToCloud.Size = new System.Drawing.Size(138, 37);
            this.btn_ImportSaveToCloud.TabIndex = 8;
            this.btn_ImportSaveToCloud.Text = "Import Save";
            this.btn_ImportSaveToCloud.UseVisualStyleBackColor = true;
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
            this.btn_LoadSave.Location = new System.Drawing.Point(587, 6);
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
            this.label4.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Improt Save Details:";
            // 
            // richTextBox_LoadedSaveDetails
            // 
            this.richTextBox_LoadedSaveDetails.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox_LoadedSaveDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_LoadedSaveDetails.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_LoadedSaveDetails.Location = new System.Drawing.Point(6, 50);
            this.richTextBox_LoadedSaveDetails.Name = "richTextBox_LoadedSaveDetails";
            this.richTextBox_LoadedSaveDetails.ReadOnly = true;
            this.richTextBox_LoadedSaveDetails.Size = new System.Drawing.Size(722, 395);
            this.richTextBox_LoadedSaveDetails.TabIndex = 5;
            this.richTextBox_LoadedSaveDetails.Text = "";
            // 
            // tabPage_PlayerInfoByEmail
            // 
            this.tabPage_PlayerInfoByEmail.BackColor = System.Drawing.Color.DimGray;
            this.tabPage_PlayerInfoByEmail.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.tabPage_PlayerInfoByEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage_PlayerInfoByEmail.Controls.Add(this.btn_GetAllPlayers);
            this.tabPage_PlayerInfoByEmail.Controls.Add(this.btn_SearchPlayerByEmail);
            this.tabPage_PlayerInfoByEmail.Controls.Add(this.label5);
            this.tabPage_PlayerInfoByEmail.Controls.Add(this.textBox_SearchEmail);
            this.tabPage_PlayerInfoByEmail.Controls.Add(this.dataGridView_PlayerByEmail);
            this.tabPage_PlayerInfoByEmail.Location = new System.Drawing.Point(4, 22);
            this.tabPage_PlayerInfoByEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_PlayerInfoByEmail.Name = "tabPage_PlayerInfoByEmail";
            this.tabPage_PlayerInfoByEmail.Size = new System.Drawing.Size(734, 497);
            this.tabPage_PlayerInfoByEmail.TabIndex = 2;
            this.tabPage_PlayerInfoByEmail.Text = "Search Player";
            // 
            // btn_GetAllPlayers
            // 
            this.btn_GetAllPlayers.AutoSize = true;
            this.btn_GetAllPlayers.BackColor = System.Drawing.Color.Transparent;
            this.btn_GetAllPlayers.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_GetAllPlayers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_GetAllPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GetAllPlayers.FlatAppearance.BorderSize = 0;
            this.btn_GetAllPlayers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_GetAllPlayers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_GetAllPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetAllPlayers.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GetAllPlayers.Location = new System.Drawing.Point(623, 53);
            this.btn_GetAllPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GetAllPlayers.Name = "btn_GetAllPlayers";
            this.btn_GetAllPlayers.Size = new System.Drawing.Size(88, 34);
            this.btn_GetAllPlayers.TabIndex = 4;
            this.btn_GetAllPlayers.Text = "Get All";
            this.btn_GetAllPlayers.UseVisualStyleBackColor = false;
            this.btn_GetAllPlayers.Click += new System.EventHandler(this.btn_GetAllPlayers_Click);
            // 
            // btn_SearchPlayerByEmail
            // 
            this.btn_SearchPlayerByEmail.AutoSize = true;
            this.btn_SearchPlayerByEmail.BackColor = System.Drawing.Color.Transparent;
            this.btn_SearchPlayerByEmail.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_SearchPlayerByEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SearchPlayerByEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchPlayerByEmail.FlatAppearance.BorderSize = 0;
            this.btn_SearchPlayerByEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SearchPlayerByEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_SearchPlayerByEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchPlayerByEmail.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchPlayerByEmail.Location = new System.Drawing.Point(623, 13);
            this.btn_SearchPlayerByEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SearchPlayerByEmail.Name = "btn_SearchPlayerByEmail";
            this.btn_SearchPlayerByEmail.Size = new System.Drawing.Size(88, 36);
            this.btn_SearchPlayerByEmail.TabIndex = 3;
            this.btn_SearchPlayerByEmail.Text = "Search";
            this.btn_SearchPlayerByEmail.UseVisualStyleBackColor = false;
            this.btn_SearchPlayerByEmail.Click += new System.EventHandler(this.btn_SearchPlayerByEmail_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email:";
            // 
            // textBox_SearchEmail
            // 
            this.textBox_SearchEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SearchEmail.Location = new System.Drawing.Point(113, 15);
            this.textBox_SearchEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SearchEmail.Name = "textBox_SearchEmail";
            this.textBox_SearchEmail.Size = new System.Drawing.Size(412, 28);
            this.textBox_SearchEmail.TabIndex = 1;
            // 
            // dataGridView_PlayerByEmail
            // 
            this.dataGridView_PlayerByEmail.AllowUserToAddRows = false;
            this.dataGridView_PlayerByEmail.AllowUserToDeleteRows = false;
            this.dataGridView_PlayerByEmail.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView_PlayerByEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_PlayerByEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PlayerByEmail.Location = new System.Drawing.Point(13, 98);
            this.dataGridView_PlayerByEmail.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_PlayerByEmail.Name = "dataGridView_PlayerByEmail";
            this.dataGridView_PlayerByEmail.ReadOnly = true;
            this.dataGridView_PlayerByEmail.RowHeadersWidth = 51;
            this.dataGridView_PlayerByEmail.RowTemplate.Height = 24;
            this.dataGridView_PlayerByEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PlayerByEmail.Size = new System.Drawing.Size(706, 378);
            this.dataGridView_PlayerByEmail.TabIndex = 0;
            this.dataGridView_PlayerByEmail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PlayerByEmail_CellDoubleClick);
            // 
            // tabPage_LogDisplay
            // 
            this.tabPage_LogDisplay.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_LogDisplay.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.tabPage_LogDisplay.Controls.Add(this.btn_DisplayExceptionLog);
            this.tabPage_LogDisplay.Controls.Add(this.richTextBox_LogDisplay);
            this.tabPage_LogDisplay.Controls.Add(this.btn_ClearLogBox);
            this.tabPage_LogDisplay.Controls.Add(this.btn_DisplayGeneralLog);
            this.tabPage_LogDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabPage_LogDisplay.Name = "tabPage_LogDisplay";
            this.tabPage_LogDisplay.Size = new System.Drawing.Size(734, 497);
            this.tabPage_LogDisplay.TabIndex = 3;
            this.tabPage_LogDisplay.Text = "Logs Display";
            // 
            // btn_DisplayExceptionLog
            // 
            this.btn_DisplayExceptionLog.AutoSize = true;
            this.btn_DisplayExceptionLog.BackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayExceptionLog.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_DisplayExceptionLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DisplayExceptionLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DisplayExceptionLog.FlatAppearance.BorderSize = 0;
            this.btn_DisplayExceptionLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayExceptionLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayExceptionLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DisplayExceptionLog.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DisplayExceptionLog.Location = new System.Drawing.Point(22, 23);
            this.btn_DisplayExceptionLog.Name = "btn_DisplayExceptionLog";
            this.btn_DisplayExceptionLog.Size = new System.Drawing.Size(164, 37);
            this.btn_DisplayExceptionLog.TabIndex = 12;
            this.btn_DisplayExceptionLog.Text = "Exception Log";
            this.btn_DisplayExceptionLog.UseVisualStyleBackColor = false;
            this.btn_DisplayExceptionLog.Click += new System.EventHandler(this.btn_DisplayExceptionLog_Click);
            // 
            // richTextBox_LogDisplay
            // 
            this.richTextBox_LogDisplay.BackColor = System.Drawing.Color.Black;
            this.richTextBox_LogDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBox_LogDisplay.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_LogDisplay.Location = new System.Drawing.Point(3, 84);
            this.richTextBox_LogDisplay.Name = "richTextBox_LogDisplay";
            this.richTextBox_LogDisplay.ReadOnly = true;
            this.richTextBox_LogDisplay.Size = new System.Drawing.Size(728, 410);
            this.richTextBox_LogDisplay.TabIndex = 11;
            this.richTextBox_LogDisplay.Text = "";
            // 
            // btn_ClearLogBox
            // 
            this.btn_ClearLogBox.AutoSize = true;
            this.btn_ClearLogBox.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearLogBox.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_ClearLogBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ClearLogBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearLogBox.FlatAppearance.BorderSize = 0;
            this.btn_ClearLogBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ClearLogBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ClearLogBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearLogBox.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearLogBox.Location = new System.Drawing.Point(634, 23);
            this.btn_ClearLogBox.Name = "btn_ClearLogBox";
            this.btn_ClearLogBox.Size = new System.Drawing.Size(79, 37);
            this.btn_ClearLogBox.TabIndex = 10;
            this.btn_ClearLogBox.Text = "Clear";
            this.btn_ClearLogBox.UseVisualStyleBackColor = false;
            this.btn_ClearLogBox.Click += new System.EventHandler(this.btn_ClearLogBox_Click);
            // 
            // btn_DisplayGeneralLog
            // 
            this.btn_DisplayGeneralLog.AutoSize = true;
            this.btn_DisplayGeneralLog.BackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayGeneralLog.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.empty_btn;
            this.btn_DisplayGeneralLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DisplayGeneralLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DisplayGeneralLog.FlatAppearance.BorderSize = 0;
            this.btn_DisplayGeneralLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayGeneralLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_DisplayGeneralLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DisplayGeneralLog.Font = new System.Drawing.Font("pixelFont-7-8x14-sproutLands", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DisplayGeneralLog.Location = new System.Drawing.Point(191, 23);
            this.btn_DisplayGeneralLog.Name = "btn_DisplayGeneralLog";
            this.btn_DisplayGeneralLog.Size = new System.Drawing.Size(131, 37);
            this.btn_DisplayGeneralLog.TabIndex = 9;
            this.btn_DisplayGeneralLog.Text = "General Log";
            this.btn_DisplayGeneralLog.UseVisualStyleBackColor = false;
            this.btn_DisplayGeneralLog.Click += new System.EventHandler(this.btn_DisplayGeneralLog_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Cloud_FinalProject.Properties.Resources.Screenshot_2026_01_19_104630;
            this.ClientSize = new System.Drawing.Size(761, 544);
            this.Controls.Add(this.tabControl_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.tabControl_Settings.ResumeLayout(false);
            this.tabPage_SaveDetails.ResumeLayout(false);
            this.tabPage_SaveDetails.PerformLayout();
            this.tabPage_ImportSave.ResumeLayout(false);
            this.tabPage_ImportSave.PerformLayout();
            this.tabPage_PlayerInfoByEmail.ResumeLayout(false);
            this.tabPage_PlayerInfoByEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlayerByEmail)).EndInit();
            this.tabPage_LogDisplay.ResumeLayout(false);
            this.tabPage_LogDisplay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Settings;
        private System.Windows.Forms.TabPage tabPage_SaveDetails;
        private System.Windows.Forms.Button btn_ResetPlayerData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ShowSaveDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_PlayerSaveDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_ImportSave;
        private System.Windows.Forms.Button btn_ImportSaveToCloud;
        private System.Windows.Forms.Button btn_LoadSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_LoadedSaveDetails;
        private System.Windows.Forms.TabPage tabPage_PlayerInfoByEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_SearchEmail;
        private System.Windows.Forms.DataGridView dataGridView_PlayerByEmail;
        private System.Windows.Forms.Button btn_SearchPlayerByEmail;
        private System.Windows.Forms.Button btn_GetAllPlayers;
        private System.Windows.Forms.TabPage tabPage_LogDisplay;
        private System.Windows.Forms.Button btn_ClearLogBox;
        private System.Windows.Forms.Button btn_DisplayGeneralLog;
        private System.Windows.Forms.RichTextBox richTextBox_LogDisplay;
        private System.Windows.Forms.Button btn_ExportSaveFile;
        private System.Windows.Forms.Button btn_DisplayExceptionLog;
    }
}