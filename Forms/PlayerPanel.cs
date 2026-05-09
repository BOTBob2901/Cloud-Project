using Cloud_FinalProject.Emuns;
using Cloud_FinalProject.Forms;
using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_FinalProject
{
    public partial class PlayerPanel : Form
    {
        // Logged in player for this session
        private Player currentPlayer;

        // Player log document that is also written locally
        private PlayerLog currentPlayerLog;

        // Launcher form reference to show again when this panel closes
        private Form launcher;

        // Admin role name when user is an admin
        private string roleName;

        // Callback that re enables launcher buttons after logout
        private Action EnableBtn;

        public PlayerPanel(Player player, Form launcher, bool isAdmin, string roleName, PlayerLog playerLog, Action EnableBtn)
        {
            InitializeComponent();

            // Store session objects and callbacks
            currentPlayer = player;
            currentPlayerLog = playerLog;
            this.launcher = launcher;
            this.roleName = roleName;
            this.EnableBtn = EnableBtn;

            // Configure UI based on user permissions
            label_AdminRole.Text = roleName;
            btn_AdminPanel.Visible = isAdmin;
            btn_Settings.Visible = !isAdmin;

            // Load stats into UI when panel opens
            RefreshStats();
        }

        // Start the game process and upload save after exit if it changed
        private async void btn_StartGame_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop if user was deleted by an admin
                if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                        "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Download latest cloud save into the local game save path
                await CloudUtils.GetSaveFileForGameToStartAsync(currentPlayer);

                // Build the expected game exe path inside output folder
                string gamePathInFolder = Path.Combine(AppContext.BaseDirectory, "farming-game", "Cloud Farm.exe");

                // Use game path only if the file exists
                string gamePath = File.Exists(gamePathInFolder) ? gamePathInFolder : null;

                // Stop if game exe is missing
                if (gamePath == null)
                {
                    MessageBox.Show(
                        "Game executable was not found near the program files (bin).\n" +
                        "Make sure you copied the 'farming-game' folder to the output directory.",
                        "Game Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Prepare process start settings
                var startInfo = new ProcessStartInfo
                {
                    FileName = gamePath,
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetDirectoryName(gamePath)
                };

                // Start the game process
                var process = Process.Start(startInfo);

                // Stop if process failed to start
                if (process == null)
                {
                    MessageBox.Show("Failed to start the game process.", "Start Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Write game start action to player log
                    ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Started the game!{Environment.NewLine}");

                    // Wait until the game process exits
                    process.WaitForExit();

                    // Upload save only if the game created a new save
                    if (ProjectUtils.IsGameSaved(currentPlayer))
                    {
                        ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Exited game with save!{Environment.NewLine}");

                        // Upload updated save data to the cloud
                        await CloudUtils.SaveGameToCloudAsync(currentPlayer);

                        // Reload player so UI matches latest cloud data
                        currentPlayer = await CloudUtils.GetPlayerByEmailAsync(currentPlayer.Email);
                        RefreshStats();
                    }
                    else
                    {
                        // Log exit without save changes
                        ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Exited game without save!{Environment.NewLine}");
                    }

                    // Bring focus back to this form after game closes
                    Focus();
                }
                finally
                {
                    // Free process resources
                    process.Dispose();
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to start or handle the game process.\n{ex.Message}",
                    "Game Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to start or handle the game process.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Open settings form and refresh stats if player was updated
        private async void btn_Settings_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop if user was deleted by an admin
                if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                        "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Open settings as a modal dialog
                using (SettingsForm settings = new SettingsForm(currentPlayer, this, OnSettingsClose, currentPlayerLog))
                {
                    if (settings.ShowDialog() == DialogResult.OK)
                    {
                        // Update player reference and refresh UI
                        currentPlayer = settings.updatedPlayer;
                        RefreshStats();
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to open settings.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to open settings.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Open admin panel and refresh stats if admin updated player
        private void btn_AdminPanel_Click(object sender, EventArgs e)
        {
            try
            {
                // Open admin panel as a modal dialog
                using (AdminPanel adminPanel = new AdminPanel(currentPlayer, roleName))
                {
                    if (adminPanel.ShowDialog() == DialogResult.OK)
                    {
                        // Update player reference and refresh UI
                        currentPlayer = adminPanel.updatedPlayer;
                        RefreshStats();
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to open admin panel.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to open admin panel.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Refresh UI labels from current player save data
        private async void RefreshStats()
        {
            // Close panel if player was deleted
            if (!await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
            {
                MessageBox.Show("Your account has been deleted by an admin. The panel will now close.",
                    "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }

            // Always show username even if save is missing
            label_UserName.Text = currentPlayer?.UserName ?? "Unknown";

            // Stop if player has no save data yet
            if (currentPlayer?.Save == null)
                return;

            try
            {
                // Read day number from saved time object
                int day = currentPlayer.Save.time.day;

                // Convert saved minutes to hour and minute values
                int hours = currentPlayer.Save.time.minute / 60;
                int minutes = currentPlayer.Save.time.minute % 60;

                // Format time as two digits
                string hourText = hours < 10 ? "0" + hours : "" + hours;
                string minuteText = minutes < 10 ? "0" + minutes : "" + minutes;

                // Update UI for day and time
                label_GameTimeDay.Text = $"Day: {day}";
                label_GameTimeMin.Text = hourText + ":" + minuteText;

                // Update resource labels from inventory dictionary
                label_logs.Text = $"{currentPlayer.Save.inventory[ResourceType.log.ToString()]}";
                label_stones.Text = $"{currentPlayer.Save.inventory[ResourceType.stone.ToString()]}";
                label_corns.Text = $"{currentPlayer.Save.inventory[ResourceType.corn.ToString()]}";
                label_tomatos.Text = $"{currentPlayer.Save.inventory[ResourceType.tomato.ToString()]}";
                label_eggs.Text = $"{currentPlayer.Save.inventory[ResourceType.egg.ToString()]}";
                label_milk.Text = $"{currentPlayer.Save.inventory[ResourceType.milk.ToString()]}";
            }
            catch (Exception ex)
            {
                // Handle missing keys or invalid save format
                MessageBox.Show($"Failed to refresh player stats from save data.\n{ex.Message}",
                    "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to refresh player stats from save data.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Logout by closing the panel form
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            // Closing triggers cleanup in FormClosed
            Close();
        }

        // Handle cleanup after panel closes and return to launcher
        private async void PlayerPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Show launcher again and enable its buttons
                launcher.Show();
                EnableBtn?.Invoke();

                // Upload logs and player update only if player still exists
                if (currentPlayer != null && currentPlayerLog != null && await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    // Write logout action to player log
                    ProjectUtils.WriteToPlayerLog($"{DateTime.Now} - {currentPlayer.UserName} : Logged out!{Environment.NewLine}");

                    // Persist latest player doc and log doc in cloud
                    await CloudUtils.UpdatePlayerAsync(currentPlayer);
                    await CloudUtils.SavePlayerLogFile(currentPlayerLog);

                    // Clear session references
                    currentPlayer = null;
                    currentPlayerLog = null;
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to complete logout cleanup.\n{ex.Message}",
                    "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to complete logout cleanup.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Callback called by SettingsForm after it closes
        public async void OnSettingsClose()
        {
            try
            {
                // Refresh player and log only if player still exists
                if (await CloudUtils.PlayerExistsAsync(currentPlayer.Email))
                {
                    // Reload player and player log from cloud
                    currentPlayer = await CloudUtils.GetPlayerByEmailAsync(currentPlayer.Email);
                    currentPlayerLog = await CloudUtils.GetPlayerLogFileAsync(currentPlayer);

                    // Upload log changes to cloud
                    await CloudUtils.SavePlayerLogFile(currentPlayerLog);

                    // Refresh UI after reload
                    RefreshStats();
                }
                else 
                    // Close panel after settings action is complete
                    Close();
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to refresh player data after settings change.\n{ex.Message}",
                    "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - PlayerPanel - Failed to refresh player data after settings change.\n{ex.Message} {Environment.NewLine}");
            }
        }
    }
}
