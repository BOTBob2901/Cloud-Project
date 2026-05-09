using Cloud_FinalProject.Emuns;
using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Properties;
using Cloud_FinalProject.Utils;
using System;
using System.Drawing;
using System.Net.Mail;
using System.Text.Json;
using System.Windows.Forms;

namespace Cloud_FinalProject.Forms
{
    public partial class PlayerEditForm : Form
    {
        // Current admin that opened this form
        private Player Admin;

        // Player object being edited
        private Player playerToEdit;

        // Original email used for replace operations
        private string email;

        public PlayerEditForm(Player player, Player currentPlayer)
        {
            InitializeComponent();

            // Save original email for future replace actions
            email = player.Email;

            // Store player and admin references
            playerToEdit = player;
            Admin = currentPlayer;
        }

        private async void PlayerEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Fill UI inputs with current player data
                textBox_Email.Text = playerToEdit.Email;
                textBox_UserName.Text = playerToEdit.UserName;

                // Load save JSON from cloud into editor box
                richTextBox_EditSaveData.Text = await CloudUtils.GetPlayerSaveDetails(playerToEdit.Email);
            }
            catch (Exception ex)
            {
                // Show error, log it, and close the form
                MessageBox.Show($"Failed to load player details.\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerEditForm - Failed to load player details.\n{ex.Message} {Environment.NewLine}");
                Close();
            }
        }

        // Remove password placeholder when user focuses the field
        private void textBox_Password_Enter(object sender, EventArgs e)
        {
            if (textBox_Password.Text == "Enter New Password")
            {
                textBox_Password.Text = "";
                textBox_Password.ForeColor = Color.Black;
                textBox_Password.UseSystemPasswordChar = true;
            }
        }

        // Restore password placeholder if user leaves the field empty
        private void textBox_Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Password.Text))
            {
                textBox_Password.Text = "Enter New Password";
                textBox_Password.ForeColor = Color.FromArgb(170, 170, 170);
                textBox_Password.UseSystemPasswordChar = false;
            }
        }

        // Clear username field when user focuses it
        private void textBox_UserName_Enter(object sender, EventArgs e)
        {
            if (textBox_UserName.Text == playerToEdit.UserName)
            {
                textBox_UserName.Text = "";
                textBox_UserName.ForeColor = Color.Black;
            }
        }

        // Restore original username if user leaves the field empty
        private void textBox_UserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_UserName.Text))
            {
                textBox_UserName.Text = playerToEdit.UserName;
                textBox_UserName.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        // Clear email field when user focuses it
        private void textBox_Email_Enter(object sender, EventArgs e)
        {
            if (textBox_Email.Text == playerToEdit.Email)
            {
                textBox_Email.Text = "";
                textBox_Email.ForeColor = Color.Black;
            }
        }

        // Restore original email if user leaves the field empty
        private void textBox_Email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Email.Text))
            {
                textBox_Email.Text = playerToEdit.Email;
                textBox_Email.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        // Validate SaveData JSON on every text change
        private void richTextBox_EditSaveData_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox_EditSaveData.Text;

            // Enable save only when JSON is valid
            if (ProjectUtils.TextToJsonVerification(text))
            {
                label_Verification.Text = Verification.Verified.ToString();
                label_Verification.ForeColor = Color.Lime;
                richTextBox_EditSaveData.ForeColor = Color.Lime;
                btn_SaveChange.Enabled = true;
            }
            else
            {
                label_Verification.Text = Verification.Not_Verified.ToString();
                label_Verification.ForeColor = Color.DarkRed;
                richTextBox_EditSaveData.ForeColor = Color.DarkRed;
                btn_SaveChange.Enabled = false;
            }
        }

        // Validate email format and check uniqueness in cloud
        private async void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Parse email to ensure valid format
                MailAddress mail = new MailAddress(textBox_Email.Text.ToLower());

                // Block save if email belongs to another existing player
                if (await CloudUtils.PlayerExistsAsync(mail.Address) && mail.Address != playerToEdit.Email)
                {
                    label_EmailVerification.ForeColor = Color.DarkRed;
                    textBox_Email.ForeColor = Color.DarkRed;
                    label_EmailVerification.Text = "❎";
                    btn_SaveChange.Enabled = false;
                }
                else
                {
                    // Mark email as valid and allow saving
                    label_EmailVerification.ForeColor = Color.Lime;
                    textBox_Email.ForeColor = Color.Black;
                    label_EmailVerification.Text = "✅️";
                    btn_SaveChange.Enabled = true;
                }
            }
            catch
            {
                // Mark email as invalid and block saving
                label_EmailVerification.ForeColor = Color.DarkRed;
                textBox_Email.ForeColor = Color.DarkRed;
                label_EmailVerification.Text = "❎";
                btn_SaveChange.Enabled = false;
            }
        }

        // Close the form without applying changes
        private void btn_CancelChange_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Toggle password visibility if a real password was entered
        private void btn_RegisterHideViewPass_Click(object sender, EventArgs e)
        {
            // Stop if placeholder is still shown
            if (textBox_Password.Text == "Enter New Password")
                return;

            // Switch between hidden and visible password modes
            if (textBox_Password.UseSystemPasswordChar == true)
            {
                textBox_Password.UseSystemPasswordChar = false;
                btn_RegisterHideViewPass.BackgroundImage = Resources.hidden;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = true;
                btn_RegisterHideViewPass.BackgroundImage = Resources.view;
            }
        }

        // Save edited fields and replace cloud documents if email changed
        private async void btn_SaveChange_Click(object sender, EventArgs e)
        {
            // Keep original email for replace operations
            string email = playerToEdit.Email;

            try
            {
                // Stop saving when JSON editor is invalid
                if (!ProjectUtils.TextToJsonVerification(richTextBox_EditSaveData.Text))
                {
                    MessageBox.Show("Save JSON is not valid. Please fix it before saving.",
                        "Invalid JSON", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Load player log so it exists before replace actions
                PlayerLog playerLog = await CloudUtils.GetPlayerLogFileAsync(playerToEdit);

                // Update player identity fields from the UI
                playerToEdit.id = textBox_Email.Text;
                playerToEdit.Email = textBox_Email.Text;
                playerToEdit.UserName = textBox_UserName.Text;

                // Deserialize save JSON back into SaveData object
                playerToEdit.Save = JsonSerializer.Deserialize<SaveData>(richTextBox_EditSaveData.Text);

                // Update password only if user typed a new one
                if (textBox_Password.Text != "Enter New Password")
                    playerToEdit.Password = ProjectUtils.Encrypt(textBox_Password.Text);

                // Replace player log only when email was changed
                if (email != playerToEdit.Email)
                    await CloudUtils.ReplacePlayerLogAsync(playerToEdit, email);

                // Replace player document and remove old document by original email
                await CloudUtils.ReplacePlayerAsync(playerToEdit, email);

                // Write admin action to general log
                ProjectUtils.WriteToGeneralLog($"{DateTime.UtcNow} - Admin {Admin.Email} edited player: {playerToEdit.Email} - {playerToEdit.UserName}{Environment.NewLine}");

                // Close form after successful save
                Close();
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing failures
                MessageBox.Show($"Save JSON is not valid.\n{ex.Message}",
                    "Invalid JSON", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Handle unexpected save failures and write to exception log
                MessageBox.Show($"Failed to save player changes.\n{ex.Message}",
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerEditForm - Failed to save player changes.\n{ex.Message} {Environment.NewLine}");
            }
        }
    }
}
