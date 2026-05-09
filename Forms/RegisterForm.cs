using Cloud_FinalProject.Emuns;
using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Properties;
using Cloud_FinalProject.Utils;
using Microsoft.Azure.Cosmos;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Cloud_FinalProject
{
    public partial class RegisterForm : Form
    {
        // Initialize the registration form UI
        public RegisterForm()
        {
            InitializeComponent();
        }

        // Handle register confirmation and create a new player in the cloud
        private async void btn_ConfirmRegister_Click(object sender, EventArgs e)
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

                // Validate email input and normalize to lowercase
                MailAddress mail = new MailAddress(textBox_RegisterEmail.Text);
                string Email = mail.Address.ToLower();

                // Read input fields
                string Username = textBox_RegisterUserName.Text;
                string Password = textBox_RegisterPassword.Text;
                string ConfirmPassword = textBox_RegisterConfirmPassword.Text;

                // Stop if any required field is empty
                if (string.IsNullOrWhiteSpace(Username) ||
                    string.IsNullOrWhiteSpace(Password) ||
                    string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    MessageBox.Show("TextBox fields cannot be empty.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create player in cloud with encrypted passwords
                bool created = await CloudUtils.CreatePlayerAsync(
                    Email,
                    Username,
                    ProjectUtils.Encrypt(Password),
                    ProjectUtils.Encrypt(ConfirmPassword)
                );

                if (created)
                {
                    // Create initial player log for the new account
                    PlayerLog playerLog = new PlayerLog(Email, Username);
                    playerLog.LogContent.Add($"{DateTime.Now} - {Username} : Registered to the game successfully!{Environment.NewLine}");

                    // Write registration event to general log
                    ProjectUtils.WriteToGeneralLog($"{DateTime.UtcNow} : Player {Email} - {Username} Registered to the game.{Environment.NewLine}");

                    // Upload player log document to cloud
                    await CloudUtils.CreatePlayerLogFile(playerLog);

                    // Close form and show success message
                    Close();
                    MessageBox.Show($"You have been registered successfully. Welcome: {Username}",
                        "Player Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                // Handle invalid email format
                MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CosmosException ex)
            {
                // Handle cloud database errors with status code details
                MessageBox.Show($"Failed to register player in the cloud.\nStatus: {(int)ex.StatusCode} ({ex.StatusCode})\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - RegisterForm - Failed to register player in the cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Handle unexpected registration errors
                MessageBox.Show($"Registration failed.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - RegisterForm - Registration failed.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Cancel registration and close the form
        private void btn_CancelRegister_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Toggle password visibility for both password input fields
        private void btn_RegisterHideViewPass_Click(object sender, EventArgs e)
        {
            try
            {
                // Switch between hidden and visible password modes
                if (textBox_RegisterPassword.UseSystemPasswordChar == true)
                {
                    textBox_RegisterPassword.UseSystemPasswordChar = false;
                    textBox_RegisterConfirmPassword.UseSystemPasswordChar = false;
                    btn_RegisterHideViewPass.BackgroundImage = Resources.hidden;
                }
                else
                {
                    textBox_RegisterPassword.UseSystemPasswordChar = true;
                    textBox_RegisterConfirmPassword.UseSystemPasswordChar = true;
                    btn_RegisterHideViewPass.BackgroundImage = Resources.view;
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to toggle password visibility.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - RegisterForm - Failed to toggle password visibility.\n{ex.Message} {Environment.NewLine}");
            }
        }
    }
}
