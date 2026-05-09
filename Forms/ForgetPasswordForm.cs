using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Utils;
using System;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Cloud_FinalProject.Forms
{
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void btn_CancelRestore_Click(object sender, EventArgs e)
        {
            // Close the restore password window
            Close();
        }

        private async void btn_ConfirmRestore_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop if cloud service is not reachable
                if (!await CloudUtils.IsCloudAliveAsync())
                {
                    MessageBox.Show("Cannot connect to cloud database. Please check your internet connection and try again.", "Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate and normalize email input
                MailAddress mail = new MailAddress(textBox_EmailForPasswordRestore.Text);

                // Check if player exists for the given email
                if (await CloudUtils.PlayerExistsAsync(mail.Address))
                {
                    // Load player object from cloud
                    Player player = await CloudUtils.GetPlayerByEmailAsync(mail.Address);

                    // Generate a random temporary password
                    string randomTempPassword = ProjectUtils.GenerateTempPassword(12);

                    // Send temporary password to user email
                    if (await ProjectUtils.SendPasswordRestoreMail(mail.Address, randomTempPassword))
                    {
                        // Save encrypted temp password to the player record
                        player.Password = ProjectUtils.Encrypt(randomTempPassword);

                        // Update player in cloud with new password
                        await CloudUtils.UpdatePlayerAsync(player);

                        // Inform user and close the form
                        MessageBox.Show("A temporary password has been sent to your email. Please check your inbox.",
                            "Password Restoration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    // Inform user when email is not registered
                    MessageBox.Show("No account found with the provided email address.",
                        "Password Restoration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                // Handle invalid email format
                MessageBox.Show("Please enter a valid email address.",
                    "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and write to exception log
                MessageBox.Show($"Failed to restore password.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - ForgetPasswordForm - Failed to restore password: {ex.Message}{Environment.NewLine}");
            }
        }
    }
}
