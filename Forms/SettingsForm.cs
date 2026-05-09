using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Properties;
using Cloud_FinalProject.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Cloud_FinalProject
{
    public partial class SettingsForm : Form
    {
        // Logged in player for this session
        private Player currentPlayer;

        // Callback to refresh PlayerPanel after settings close
        private Action OnSettingClose;

        // Player log document for this player
        private PlayerLog currentPlayerLog;

        // Updated player returned back to PlayerPanel after changes
        public Player updatedPlayer { get; private set; }

        public SettingsForm(Player player, Form playerPanel, Action onSettingClose, PlayerLog currentPlayerLog)
        {
            InitializeComponent();

            // Store session objects and default updated player
            currentPlayer = player;
            updatedPlayer = player;
            OnSettingClose = onSettingClose;
            this.currentPlayerLog = currentPlayerLog;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Block import until a valid JSON file is loaded
            btn_ImportSaveToCloud.Enabled = false;
        }

        // Export player save from cloud into a local JSON file
        private async void btn_ExportSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Download save and write it locally
                await CloudUtils.ExportPlayerSaveToJsonAsync(currentPlayer.Email);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to export save file.\n{ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Export Save Error.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Show current cloud save JSON in the details box
        private async void btn_ShowSaveDetails_Click(object sender, EventArgs e)
        {
            try
            {
                // Load save JSON from cloud and display it
                richTextBox_PlayerSaveDetails.Text = await CloudUtils.GetPlayerSaveDetails(currentPlayer.Email);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to load save details from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Load Save Details Error.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Reset player save data after confirmation
        private async void btn_ResetPlayerData_Click(object sender, EventArgs e)
        {
            // Stop if player was deleted by an admin
            if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
            {
                MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                    "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // Ask user to confirm destructive action
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset the data?",
                "Data Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Stop if user cancels
            if (result != DialogResult.Yes)
                return;

            try
            {
                // Create a new player object without SaveData
                updatedPlayer = new Player(currentPlayer.Email, currentPlayer.UserName, currentPlayer.Password);

                // Update player document in cloud
                await CloudUtils.UpdatePlayerAsync(updatedPlayer);

                // Write reset action to local player log
                ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Reset save data!{Environment.NewLine}");

                // Notify caller that player changed
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Show error and keep original player reference
                MessageBox.Show($"Failed to reset player data.\n{ex.Message}",
                    "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Reset Player Data Error.\n{ex.Message}{Environment.NewLine}");

                updatedPlayer = currentPlayer;
            }
        }

        // Load SaveData JSON file locally and validate it
        private async void btn_LoadSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop if player was deleted by an admin
                if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                        "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Open file picker for JSON files
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Title = "Select a JSON Save file",
                    Filter = "JSON files (*.json)|*.json"
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Read file content and show it in the editor box
                    string saveDataAsString = File.ReadAllText(openFile.FileName);
                    richTextBox_LoadedSaveDetails.Text = saveDataAsString;

                    // Validate JSON and enable import only if valid
                    bool ok = ProjectUtils.TextToJsonVerification(saveDataAsString);
                    btn_ImportSaveToCloud.Enabled = ok;
                    richTextBox_LoadedSaveDetails.ForeColor = ok ? Color.Lime : Color.DarkRed;
                }
                else
                {
                    // User cancelled file selection
                    MessageBox.Show("No file was selected.",
                        "No File Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle permission errors when reading file
                MessageBox.Show($"No permission to read the selected file.\n{ex.Message}",
                    "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Load Save File Permission Error.\n{ex.Message}{Environment.NewLine}");
            }
            catch (IOException ex)
            {
                // Handle IO read errors
                MessageBox.Show($"File error while reading the save file.\n{ex.Message}",
                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Load Save File IO Error.\n{ex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"Unexpected error while loading save file.\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Load Save File Unexpected Error.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Import the loaded JSON save into the cloud for this player
        private async void btn_ImportSaveToCloud_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop if player was deleted by an admin
                if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                        "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Read JSON text from the loaded save box
                string saveDetails = richTextBox_LoadedSaveDetails.Text;

                // Import new save into cloud and get updated player
                updatedPlayer = await CloudUtils.ImportPlayerNewSaveDataAsync(currentPlayer, saveDetails);

                // Stop if import failed and keep old player
                if (updatedPlayer == null)
                {
                    MessageBox.Show("Failed to import save data. Please check the JSON content.",
                        "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    updatedPlayer = currentPlayer;
                    return;
                }

                // Inform user and write to local player log
                MessageBox.Show("Save was loaded successfully.", "Import Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Imported new save data!{Environment.NewLine}");

                // Notify caller and close form
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to import save data to cloud.\n{ex.Message}",
                    "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Import Save to Cloud Error.\n{ex.Message}{Environment.NewLine}");

                updatedPlayer = currentPlayer;
            }
        }

        // Update account details and replace player docs if email changed
        private async void btn_SaveChange_Click(object sender, EventArgs e)
        {
            // Store starting email for replace actions
            string email = currentPlayer.Email;

            try
            {
                // Stop if player was deleted by an admin
                if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                        "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Stop if password inputs are missing
                if (string.IsNullOrWhiteSpace(textBox_ConfirmPassword.Text) ||
                    string.IsNullOrWhiteSpace(textBox_CurrentPassword.Text) ||
                    string.IsNullOrWhiteSpace(textBox_NewPassword.Text))
                {
                    MessageBox.Show("Please fill in all password fields.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Stop if current password does not match the stored password
                if (ProjectUtils.Encrypt(textBox_CurrentPassword.Text) != currentPlayer.Password)
                {
                    MessageBox.Show("Current password is incorrect.", "Authentication Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Stop if new password and confirmation do not match
                if (textBox_NewPassword.Text != textBox_ConfirmPassword.Text
                    && textBox_ConfirmPassword.Text != "Confirm Password" && textBox_NewPassword.Text != "Enter New Password")
                {
                    MessageBox.Show("New password and confirmation do not match.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Keep old email for replace operations
                string oldEmail = currentPlayer.Email;

                // Apply new email if provided
                if (!string.IsNullOrWhiteSpace(textBox_Email.Text))
                {
                    currentPlayer.Email = textBox_Email.Text.ToLower();
                    currentPlayer.id = currentPlayer.Email;
                }

                // Apply new username if provided
                if (!string.IsNullOrWhiteSpace(textBox_UserName.Text))
                    currentPlayer.UserName = textBox_UserName.Text;

                // Apply new password if user typed a real one
                if (textBox_NewPassword.Text != "Enter New Password")
                    currentPlayer.Password = ProjectUtils.Encrypt(textBox_NewPassword.Text);

                // Inform user about success
                MessageBox.Show("Account details updated successfully.", "Update Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Write update action to local player log
                ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Updated account details!{Environment.NewLine}");

                // Upload current player log to cloud
                await CloudUtils.SavePlayerLogFile(currentPlayerLog);

                // Replace player and log documents when email changed
                if (email != currentPlayer.Email)
                    await CloudUtils.ReplacePlayerLogAsync(currentPlayer, oldEmail);

                await CloudUtils.ReplacePlayerAsync(currentPlayer, oldEmail);

                // Return updated player to PlayerPanel
                updatedPlayer = currentPlayer;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"An error occurred while updating account details.\n{ex.Message}",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Save Account Changes Error.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Validate email format and check uniqueness on every change
        private async void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            // Stop when field is empty to avoid blocking save
            if (string.IsNullOrWhiteSpace(textBox_Email.Text))
                return;

            try
            {
                // Parse email to validate formatting
                MailAddress mail = new MailAddress(textBox_Email.Text.ToLower());

                // Block save if email belongs to another existing player
                if (await CloudUtils.PlayerExistsAsync(mail.Address) && mail.Address != currentPlayer.Email)
                {
                    label_PlayerEmailVerification.ForeColor = Color.DarkRed;
                    label_PlayerEmailVerification.Text = "❎";
                    btn_SaveChange.Enabled = false;
                }
                else
                {
                    // Mark email as available and allow saving
                    label_PlayerEmailVerification.ForeColor = Color.Lime;
                    label_PlayerEmailVerification.Text = "✅️";
                    btn_SaveChange.Enabled = true;
                }
            }
            catch
            {
                // Ignore parse errors and keep current state
            }
        }

        // Toggle password visibility for all password fields
        private void btn_RegisterHideViewPass_Click(object sender, EventArgs e)
        {
            try
            {
                // If any field is hidden show all
                if (textBox_NewPassword.UseSystemPasswordChar ||
                    textBox_ConfirmPassword.UseSystemPasswordChar ||
                    textBox_CurrentPassword.UseSystemPasswordChar)
                {
                    textBox_NewPassword.UseSystemPasswordChar = false;
                    textBox_ConfirmPassword.UseSystemPasswordChar = false;
                    textBox_CurrentPassword.UseSystemPasswordChar = false;
                    btn_RegisterHideViewPass.BackgroundImage = Resources.hidden;
                }
                else
                {
                    // Hide only real password inputs and keep placeholders visible
                    if (textBox_NewPassword.Text != "Enter New Password")
                        textBox_NewPassword.UseSystemPasswordChar = true;

                    if (textBox_ConfirmPassword.Text != "Confirm Password")
                        textBox_ConfirmPassword.UseSystemPasswordChar = true;

                    if (textBox_CurrentPassword.Text != "Current Password")
                        textBox_CurrentPassword.UseSystemPasswordChar = true;

                    btn_RegisterHideViewPass.BackgroundImage = Resources.view;
                }
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to toggle password visibility.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - Toggle Password Visibility Error.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Clear current password placeholder on focus
        private void textBox_CurrentPassword_Enter(object sender, EventArgs e)
        {
            if (textBox_CurrentPassword.Text == "Current Password")
            {
                textBox_CurrentPassword.Text = "";
                textBox_CurrentPassword.ForeColor = Color.Black;
                textBox_CurrentPassword.UseSystemPasswordChar = true;
            }
        }

        // Restore current password placeholder when empty
        private void textBox_CurrentPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_CurrentPassword.Text))
            {
                textBox_CurrentPassword.Text = "Current Password";
                textBox_CurrentPassword.ForeColor = Color.FromArgb(170, 170, 170);
                textBox_CurrentPassword.UseSystemPasswordChar = false;
            }
        }

        // Clear new password placeholder on focus
        private void textBox_NewPassword_Enter(object sender, EventArgs e)
        {
            if (textBox_NewPassword.Text == "Enter New Password")
            {
                textBox_NewPassword.Text = "";
                textBox_NewPassword.ForeColor = Color.Black;
                textBox_NewPassword.UseSystemPasswordChar = true;
            }
        }

        // Restore new password placeholder when empty
        private void textBox_NewPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_NewPassword.Text))
            {
                textBox_NewPassword.Text = "Enter New Password";
                textBox_NewPassword.ForeColor = Color.FromArgb(170, 170, 170);
                textBox_NewPassword.UseSystemPasswordChar = false;
            }
        }

        // Clear confirm password placeholder on focus
        private void textBox_ConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (textBox_ConfirmPassword.Text == "Confirm Password")
            {
                textBox_ConfirmPassword.Text = "";
                textBox_ConfirmPassword.ForeColor = Color.Black;
                textBox_ConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        // Restore confirm password placeholder when empty
        private void textBox_ConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ConfirmPassword.Text))
            {
                textBox_ConfirmPassword.Text = "Confirm Password";
                textBox_ConfirmPassword.ForeColor = Color.FromArgb(170, 170, 170);
                textBox_ConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        // Notify PlayerPanel when settings form is closing
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Call the callback to refresh player and logs
                OnSettingClose();
            }
            catch (Exception ex)
            {
                // Show warning and log it
                MessageBox.Show($"Failed to refresh after closing settings.\n{ex.Message}",
                    "Close Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - SettingsForm - OnSettingClose Invoke Error.\n{ex.Message} {Environment.NewLine}");
            }
        }
    }
}
