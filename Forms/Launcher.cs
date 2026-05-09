using Cloud_FinalProject.Forms;
using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Properties;
using Cloud_FinalProject.Utils;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Windows.Forms;

namespace Cloud_FinalProject
{
    public partial class Launcher : Form
    {
        // Developer ID and name loaded from App.config
        private string DeveloperId1 = ConfigurationManager.AppSettings["ID1"];
        private string DeveloperFullName1 = ConfigurationManager.AppSettings["FullName1"];
        private string DeveloperId2 = ConfigurationManager.AppSettings["ID2"];
        private string DeveloperFullName2 = ConfigurationManager.AppSettings["FullName2"];

        // Prevent running closing logic more than once
        private bool _isClosingHandled = false;

        // Initialize launcher UI and basic app folders
        public Launcher()
        {
            InitializeComponent();

            // Create required local folders for saves and logs
            AppPaths.EnsureFolders();

            // Display developer info on the launcher screen
            label_Developers.Text += " " + DeveloperFullName1 + " ID: " + DeveloperId1 + " " + DeveloperFullName2 + " ID: " + DeveloperId2;

            // Write startup log entry
            ProjectUtils.WriteToGeneralLog($"{DateTime.Now} - Launcher initialized.{Environment.NewLine}");
        }

        // Open the registration form as a modal window
        private void btn_OpenRegisterForm_Click(object sender, EventArgs e)
        {
            try
            {
                // Show register form dialog
                RegisterForm registerForm = new RegisterForm();
                registerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to open register form.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - Launcher - Failed to open register form: {ex.Message}{Environment.NewLine}");
            }
        }

        // Handle login flow and open PlayerPanel on success
        private async void btn_LogIn_Click(object sender, EventArgs e)
        {
            // Block double clicks during async login
            DisableBtn();

            try
            {
                // Validate email input and normalize it to lowercase
                MailAddress mail = new MailAddress(textBox_LogInEmail.Text);
                string email = mail.Address.ToLower();

                // Read password input from UI
                string password = textBox_LogInPassword.Text;

                // Stop login if cloud is not reachable
                if (!await CloudUtils.IsCloudAliveAsync())
                {
                    MessageBox.Show("Cannot connect to cloud database. Please check your internet connection and try again.", "Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableBtn();
                    return;
                }

                // Stop login if password is missing
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password cannot be empty.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnableBtn();
                    return;
                }

                // Load player record from cloud by email
                Player player = await CloudUtils.GetPlayerByEmailAsync(email);

                if (player == null)
                {
                    player = await CloudUtils.GetAdminByEmailAsync(email);
                    await CloudUtils.CreatePlayerAsync(player);
                }

                // Stop login if player does not exist
                if (player == null)
                {
                    MessageBox.Show("Player with this email does not exist.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnableBtn();
                    return;
                }

                // Compare encrypted input password with stored password
                if (!ProjectUtils.Encrypt(password).Equals(player.Password))
                {
                    MessageBox.Show("Wrong password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnableBtn();
                    return;
                }

                // Check if the player also has an admin record
                Admin admin = await CloudUtils.GetAdminByEmailAsync(email);
                bool isAdmin = (admin != null);
                string roleName = admin?.RoleName;

                // Write admin login entry to general log
                if (isAdmin)
                {
                    ProjectUtils.WriteToGeneralLog($"{DateTime.Now} - Admin {admin.Email} Role : {admin.RoleName} logged in.{Environment.NewLine}");
                }

                // Load or create player log file document
                PlayerLog playerLog = await CloudUtils.GetPlayerLogFileAsync(player);

                // Write login line to local player log file
                ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {player.UserName} : Logged in successfully!{Environment.NewLine}");

                // Open PlayerPanel and hide launcher window
                PlayerPanel playerPanel = new PlayerPanel(player, this, isAdmin, roleName, playerLog, EnableBtn);
                playerPanel.Show();
                Hide();

                // Clear password field after successful login
                textBox_LogInPassword.Text = "";
            }
            catch (FormatException)
            {
                // Handle invalid email input format
                MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnableBtn();
            }
            catch (Exception ex)
            {
                // Handle unexpected login errors and write to exception log
                MessageBox.Show($"Login failed due to an unexpected error.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - Launcher - Login failed due to an unexpected error.: {ex.Message}{Environment.NewLine}");
                EnableBtn();
            }
        }

        // Disable main buttons during async operations
        public void DisableBtn()
        {
            // Prevent multiple login and register clicks
            btn_LogIn.Enabled = false;
            btn_OpenRegisterForm.Enabled = false;
        }

        // Enable main buttons after async operations finish
        public void EnableBtn()
        {
            // Restore button access
            btn_LogIn.Enabled = true;
            btn_OpenRegisterForm.Enabled = true;
        }

        // Toggle password show or hide and update the icon
        private void btn_RegisterHideViewPass_Click(object sender, EventArgs e)
        {
            try
            {
                // Show password if it is currently hidden
                if (textBox_LogInPassword.UseSystemPasswordChar == true)
                {
                    textBox_LogInPassword.UseSystemPasswordChar = false;
                    btn_LogInHideViewPass.BackgroundImage = Resources.hidden;
                }
                else
                {
                    // Hide password if it is currently visible
                    textBox_LogInPassword.UseSystemPasswordChar = true;
                    btn_LogInHideViewPass.BackgroundImage = Resources.view;
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to toggle password visibility.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - Launcher - Failed to toggle password visibility: {ex.Message}{Environment.NewLine}");
            }
        }

        private async void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop if close was already processed
            if (_isClosingHandled) return;

            // Cancel default close until logs are handled
            e.Cancel = true;

            try
            {
                // Skip cloud log upload when cloud is not reachable
                if (!await CloudUtils.IsCloudAliveAsync())
                    _isClosingHandled = true;

                // Write close entry to local general log
                ProjectUtils.WriteToGeneralLog($"{DateTime.Now} - Launcher closed.{Environment.NewLine}");

                // Upload latest general and exception logs to cloud
                await CloudUtils.SaveGeneralLogFile(new GeneralLog());
                await CloudUtils.SaveExceptionLogFile(new ExceptionLog());
            }
            catch (Exception ex)
            {
                // Show warning if log upload failed
                MessageBox.Show($"Failed to upload logs before exit.\n{ex.Message}",
                    "Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                // Mark close as handled and close the form again
                _isClosingHandled = true;
                Close();
            }
        }

        private void btn_ForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Open forgot password form as a modal window
                ForgetPasswordForm forgetPasswordForm = new ForgetPasswordForm();
                forgetPasswordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to open Forget Password form.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - Launcher - Failed to Forget Password  form: {ex.Message}{Environment.NewLine}");
            }
        }
    }
}
