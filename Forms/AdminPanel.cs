using Cloud_FinalProject.Emuns;
using Cloud_FinalProject.Modal;
using Cloud_FinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_FinalProject.Forms
{
    public partial class AdminPanel : Form
    {
        // Currently logged in player for this session
        private Player currentPlayer;

        // Updated player returned back to PlayerPanel after changes
        public Player updatedPlayer { get; private set; }

        // Admin role name used for permission checks
        private string roleName;

        public AdminPanel(Player currentPlayer, string roleName)
        {
            InitializeComponent();

            // Save session data passed from caller
            this.currentPlayer = currentPlayer;
            this.roleName = roleName;

            // Default updated player is the current player
            updatedPlayer = currentPlayer;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // Prevent import until a valid JSON file is loaded
            btn_ImportSaveToCloud.Enabled = false;
        }

        // Export player save data from cloud to a local JSON file
        private async void btn_ExportSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Download and save the player save file locally
                await CloudUtils.ExportPlayerSaveToJsonAsync(currentPlayer.Email);
            }
            catch (Exception ex)
            {
                // Show user friendly error and write to exception log
                MessageBox.Show($"Failed to export save file.\n{ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Export Save File Error: {ex.Message}{Environment.NewLine}");
            }
        }

        // Show the player save JSON content inside the RichTextBox
        private async void btn_ShowSaveDetails_Click(object sender, EventArgs e)
        {
            try
            {
                // Load save details text from the cloud
                richTextBox_PlayerSaveDetails.Text = await CloudUtils.GetPlayerSaveDetails(currentPlayer.Email);
            }
            catch (Exception ex)
            {
                // Show cloud error and write to exception log
                MessageBox.Show($"Failed to load save details from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Show Save Details Error: {ex.Message}{Environment.NewLine}");
            }
        }

        // Reset player data after confirmation and update the cloud record
        private async void btn_ResetPlayerData_Click(object sender, EventArgs e)
        {
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
                // Create a new player object without save data
                updatedPlayer = new Player(currentPlayer.Email, currentPlayer.UserName, currentPlayer.Password);

                // Push the new player data to the cloud
                await CloudUtils.UpdatePlayerAsync(updatedPlayer);

                // Notify caller that changes were made
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Show error, log it, and keep original player
                MessageBox.Show($"Failed to reset player data.\n{ex.Message}",
                    "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Reset Player Data Error: {ex.Message}{Environment.NewLine}");
                updatedPlayer = currentPlayer;
            }
        }

        // Load a local SaveData JSON file and preview it in the UI
        private void btn_LoadSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Configure file picker to JSON only
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Title = "Select a JSON Save file",
                    Filter = "JSON files (*.json)|*.json"
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Read selected file text and show it
                    string saveDataAsString = File.ReadAllText(openFile.FileName);
                    richTextBox_LoadedSaveDetails.Text = saveDataAsString;

                    // Validate JSON and enable import only if valid
                    bool ok = ProjectUtils.TextToJsonVerification(saveDataAsString);
                    btn_ImportSaveToCloud.Enabled = ok;

                    // Use color to indicate validation result
                    richTextBox_LoadedSaveDetails.ForeColor = ok ? Color.Lime : Color.Red;
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
                // File exists but no permission to read it
                MessageBox.Show($"No permission to read the selected file.\n{ex.Message}",
                    "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Load Save File Permission Error: {ex.Message} {Environment.NewLine}");
            }
            catch (IOException ex)
            {
                // File read or IO failure
                MessageBox.Show($"File error while reading the save file.\n{ex.Message}",
                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Load Save File IO Error: {ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Any other unexpected issue
                MessageBox.Show($"Unexpected error while loading save file.\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Load Save File Error: {ex.Message} {Environment.NewLine}");
            }
        }

        // Import the loaded SaveData JSON into the cloud as the player new save
        private async void btn_ImportSaveToCloud_Click(object sender, EventArgs e)
        {
            try
            {
                // Get JSON text from the loaded save textbox
                string saveDetails = richTextBox_LoadedSaveDetails.Text;

                // Send save JSON to cloud and receive updated player
                updatedPlayer = await CloudUtils.ImportPlayerNewSaveDataAsync(currentPlayer, saveDetails);

                // Stop if import failed and keep the old player
                if (updatedPlayer == null)
                {
                    MessageBox.Show("Failed to import save data. Please check the JSON file content.",
                        "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    updatedPlayer = currentPlayer;
                    return;
                }

                // Notify success
                MessageBox.Show("Save was loaded successfully.", "Import Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify caller and close this form
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Show error, log it, and keep original player
                MessageBox.Show($"Unexpected error while importing save to cloud.\n{ex.Message}",
                    "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Import Save to Cloud Error: {ex.Message} {Environment.NewLine}");

                updatedPlayer = currentPlayer;
            }
        }

        // Button handler that searches a player by the email textbox value
        private async void btn_SearchPlayerByEmail_Click(object sender, EventArgs e)
        {
            // Run async search and update the grid
            await SearchPlayerByEmailAsync();
        }

        // Button handler that loads all players into the grid
        private async void btn_GetAllPlayers_Click(object sender, EventArgs e)
        {
            // Fetch and display all players
            await LoadPlayersAsync();
        }

        // Open player editor on row double click if permissions allow it
        private async void dataGridView_PlayerByEmail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Stop if there is no selected row
                if (dataGridView_PlayerByEmail.CurrentRow == null)
                    return;

                // Read email value from the selected row
                string email = dataGridView_PlayerByEmail.CurrentRow
                    .Cells[PlayerGridCol.Email.ToString()].Value?.ToString();

                // Stop if email cell is empty or invalid
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Selected row does not contain a valid email.",
                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get full player record from cloud by email
                Player player = await CloudUtils.GetPlayerByEmailAsync(email);

                // Stop if player does not exist in cloud
                if (player == null)
                {
                    MessageBox.Show("Player was not found in the cloud.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Allow editing only for Developer role
                if (roleName != RoleName.Developer.ToString())
                {
                    MessageBox.Show("Your admin level is too low to edit a player.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Open edit form for the selected player
                using (PlayerEditForm editForm = new PlayerEditForm(player, currentPlayer))
                {
                    editForm.ShowDialog();
                }

                // Refresh grid after editing depending on current search state
                if (string.IsNullOrEmpty(textBox_SearchEmail.Text))
                {
                    await LoadPlayersAsync();
                }
                else
                {
                    // Clear current search and results
                    textBox_SearchEmail.Text = "";
                    dataGridView_PlayerByEmail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to open player editor.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Open Player Edit Form Error: {ex.Message} {Environment.NewLine}");
            }
        }

        // Load all players from cloud and bind them to the grid
        private async Task LoadPlayersAsync()
        {
            try
            {
                // Fetch full players list from cloud
                List<Player> list = await CloudUtils.GetAllPlayerListAsync();

                // Stop if request failed
                if (list == null)
                {
                    MessageBox.Show("Failed to load players list from cloud.",
                        "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Map players to a grid friendly model
                List<PlayerGridBox> gridList = new List<PlayerGridBox>();
                foreach (Player player in list)
                {
                    gridList.Add(new PlayerGridBox(
                        player.Email,
                        player.UserName,
                        player.Password
                    ));
                }

                // Bind data to the grid
                dataGridView_PlayerByEmail.DataSource = gridList;
                dataGridView_PlayerByEmail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Apply readonly styling for all columns
                foreach (DataGridViewColumn col in dataGridView_PlayerByEmail.Columns)
                {
                    col.DefaultCellStyle.Font = new Font("Ariel", 10);
                    col.DefaultCellStyle.ForeColor = Color.Lime;
                    col.DefaultCellStyle.BackColor = Color.Black;
                    col.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to load players list.\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Load Players Error: {ex.Message}{Environment.NewLine}");
            }
        }

        // Search for a single player by email and display the result in the grid
        private async Task SearchPlayerByEmailAsync()
        {
            try
            {
                // Require input before searching
                if (string.IsNullOrEmpty(textBox_SearchEmail.Text))
                {
                    MessageBox.Show("Please enter an email address to search.",
                        "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format before calling the cloud
                MailAddress mail = new MailAddress(textBox_SearchEmail.Text);

                // Fetch player record from cloud using normalized email
                Player player = await CloudUtils.GetPlayerByEmailAsync(mail.Address.ToLower());

                // Handle player not found
                if (player == null)
                {
                    MessageBox.Show("Player with this email does not exist.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView_PlayerByEmail.DataSource = null;
                    return;
                }

                // Bind the found player as a single row result
                dataGridView_PlayerByEmail.DataSource = new List<PlayerGridBox>()
                {
                    new PlayerGridBox(player.Email, player.UserName, player.Password)
                };

                dataGridView_PlayerByEmail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Apply readonly styling for all columns
                foreach (DataGridViewColumn col in dataGridView_PlayerByEmail.Columns)
                {
                    col.DefaultCellStyle.Font = new Font("Ariel", 10);
                    col.DefaultCellStyle.ForeColor = Color.Lime;
                    col.DefaultCellStyle.BackColor = Color.Black;
                    col.ReadOnly = true;
                }
            }
            catch (FormatException)
            {
                // MailAddress constructor throws when format is invalid
                MessageBox.Show("Please enter a valid email address.",
                    "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Show error and write to exception log
                MessageBox.Show($"Failed to search player by email.\n{ex.Message}",
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AdminPanel - Search Player by Email Error: {ex.Message} {Environment.NewLine}");
            }
        }

        // Display exception log content inside the log RichTextBox
        private async void btn_DisplayExceptionLog_Click(object sender, EventArgs e)
        {
            // Fetch log lines from cloud and render as one text block
            List<String> logContent = await CloudUtils.GetExceptionLogAsync();
            string logText = string.Join(Environment.NewLine, logContent);
            richTextBox_LogDisplay.Text = logText;
        }

        // Display general log content inside the log RichTextBox
        private async void btn_DisplayGeneralLog_Click(object sender, EventArgs e)
        {
            // Fetch log lines from cloud and render as one text block
            List<String> logContent = await CloudUtils.GetGeneralLogAsync();
            string logText = string.Join(Environment.NewLine, logContent);
            richTextBox_LogDisplay.Text = logText;
        }

        // Clear the log RichTextBox
        private void btn_ClearLogBox_Click(object sender, EventArgs e)
        {
            // Reset log display text
            richTextBox_LogDisplay.Text = "";
        }
    }
}
