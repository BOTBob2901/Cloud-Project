using Cloud_FinalProject.Modal;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_FinalProject.Utils
{
    public class CloudUtils
    {
        // Shared Cosmos client instance for the whole application
        private static CosmosClient cosmosClient;

        // Block creating instances of this helper class
        private CloudUtils() { }

        // Singleton access to CosmosClient with lazy initialization
        public static CosmosClient Instance
        {
            get
            {
                // Create Cosmos client only once
                if (cosmosClient == null)
                    cosmosClient = new CosmosClient(Constants.URI, Constants.PrimaryKey, new CosmosClientOptions
                    {
                        // Limit request time to avoid long UI freezes
                        RequestTimeout = TimeSpan.FromSeconds(5)
                    });

                return cosmosClient;
            }
        }

        // Check if Cosmos account is reachable within a short timeout
        public static async Task<bool> IsCloudAliveAsync(int timeoutSeconds = 5)
        {
            try
            {
                // Start a simple account read operation as a ping
                var pingTask = Instance.ReadAccountAsync();

                // Race the ping against a timeout delay
                var completed = await Task.WhenAny(pingTask, Task.Delay(TimeSpan.FromSeconds(timeoutSeconds)));

                // Timeout happened first
                if (completed != pingTask)
                    return false;

                // Await ping result to surface any errors
                await pingTask;
                return true;
            }
            catch (CosmosException) { return false; }
            catch (HttpRequestException) { return false; }
            catch { return false; }
        }

        // Create a new player document in Cosmos after validation
        public static async Task<bool> CreatePlayerAsync(string Email, string Username, string Password, string ConfirmPassword)
        {
            try
            {
                // Block when passwords do not match
                if (!Password.Equals(ConfirmPassword))
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Block when player already exists for this email
                if (await PlayerExistsAsync(Email))
                {
                    MessageBox.Show("There is already a player attached to this email.",
                        "Player Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return false;
                }

                // Get players container reference
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

                // Build new player object with default save
                Player player = new Player(Email, Username, Password);

                // Insert player into Cosmos using email as partition key
                await container.CreateItemAsync<Player>(player, new PartitionKey(player.Email));

                return true;
            }
            catch (CosmosException ex)
            {
                // Show cloud error and write exception log
                MessageBox.Show($"Failed to create player in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to create player in cloud.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
            catch (Exception ex)
            {
                // Show unexpected error and write exception log
                MessageBox.Show($"Unexpected error while creating player.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while creating player.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
        }

        // Create player document for an admin flow when it does not exist yet
        public static async Task CreatePlayerAsync(Player player)
        {
            // Get the Players container from the Cosmos database
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

            try
            {
                // Insert the player into Cosmos using Email as the partition key
                await container.CreateItemAsync<Player>(player, new PartitionKey(player.Email));
            }
            catch (Exception ex)
            {
                // Show exception and write failure if the insert did not succeed
                MessageBox.Show($"Unexpected error while creating player.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - CloudUtils - Admin {player.Email} faild to create Player item for the admin");
            }
        }


        // Check if a player exists by reading the document by id and partition key
        public static async Task<bool> PlayerExistsAsync(string email)
        {
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

            try
            {
                // Read by id email and partition key email
                await container.ReadItemAsync<Player>(email, new PartitionKey(email));
                return true;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Not found means player does not exist
                return false;
            }
            catch (CosmosException ex)
            {
                // Cloud failure while checking existence
                MessageBox.Show($"Failed to check if player exists.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to check if player exists.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
            catch (Exception ex)
            {
                // Unexpected failure while checking existence
                MessageBox.Show($"Unexpected error while checking player existence.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while checking player existence.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
        }

        // Check if an admin exists by reading the admin document
        public static async Task<bool> AdminExistsAsync(string email)
        {
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.AdminsTable);

            try
            {
                // Read by id email and partition key email
                await container.ReadItemAsync<Admin>(email, new PartitionKey(email));
                return true;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Not found means admin does not exist
                return false;
            }
            catch (CosmosException ex)
            {
                // Cloud failure while checking existence
                MessageBox.Show($"Failed to check if admin exists.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to check if admin exists.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
            catch (Exception ex)
            {
                // Unexpected failure while checking existence
                MessageBox.Show($"Unexpected error while checking admin existence.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while checking admin existence.\n{ex.Message} {Environment.NewLine}");
                return false;
            }
        }

        // Read player document by email and return the Player object
        public static async Task<Player> GetPlayerByEmailAsync(string email)
        {
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

            try
            {
                // Read player by id and partition key
                ItemResponse<Player> player = await container.ReadItemAsync<Player>(email, new PartitionKey(email));
                return player.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Player not found
                return null;
            }
            catch (CosmosException ex)
            {
                // Cloud error while loading player
                MessageBox.Show($"Failed to load player from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load player from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
            catch (Exception ex)
            {
                // Unexpected error while loading player
                MessageBox.Show($"Unexpected error while loading player.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while loading player.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
        }

        // Read admin document by email and return the Admin object
        public static async Task<Admin> GetAdminByEmailAsync(string email)
        {
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.AdminsTable);

            try
            {
                // Read admin by id and partition key
                ItemResponse<Admin> admin = await container.ReadItemAsync<Admin>(email, new PartitionKey(email));
                return admin.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Admin not found
                return null;
            }
            catch (CosmosException ex)
            {
                // Cloud error while loading admin
                MessageBox.Show($"Failed to load admin from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load admin from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
            catch (Exception ex)
            {
                // Unexpected error while loading admin
                MessageBox.Show($"Unexpected error while loading admin.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Export player SaveData from cloud into a local json file
        public static async Task ExportPlayerSaveToJsonAsync(string email)
        {
            // Load player first to validate existence
            Player player = await GetPlayerByEmailAsync(email);

            // Stop when player does not exist
            if (player == null)
            {
                MessageBox.Show("Player does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Stop when player has no save data
            if (player.Save == null)
            {
                MessageBox.Show("Player has no save data.", "No Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Generate a filename and export SaveData to disk
            string fileName = $"{player.UserName}_save.json";
            ProjectUtils.ExportSaveToJsonFile(player.Save, fileName);
        }

        // Return player SaveData as a json string for UI display
        public static async Task<string> GetPlayerSaveDetails(string email)
        {
            // Load player first to validate existence
            Player player = await GetPlayerByEmailAsync(email);

            // Return a readable message when missing
            if (player == null)
                return "Player does not exist.";

            // Return a readable message when save is missing
            if (player.Save == null)
                return "Player has no save data.";

            // Serialize SaveData into json
            return ProjectUtils.SaveToJsonString(player.Save);
        }

        // Replace player document in Cosmos with updated content
        public static async Task UpdatePlayerAsync(Player player)
        {
            try
            {
                // Get players container reference
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

                // Replace document using id and partition key
                await container.ReplaceItemAsync(player, player.id, new PartitionKey(player.Email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while updating player
                MessageBox.Show($"Failed to update player in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to update player in cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Unexpected error while updating player
                MessageBox.Show($"Unexpected error while updating player.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while updating player.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Replace admin document in Cosmos with updated content
        public static async Task UpdateAdminAsync(Admin player)
        {
            try
            {
                // Get admins container reference
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.AdminsTable);

                // Replace document using id and partition key
                await container.ReplaceItemAsync(player, player.id, new PartitionKey(player.Email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while updating admin
                MessageBox.Show($"Failed to update admin in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to update admin in cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Unexpected error while updating admin
                MessageBox.Show($"Unexpected error while updating admin.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while updating admin.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Delete old player document and create a new one for the new identity
        public static async Task ReplacePlayerAsync(Player player, string email)
        {
            try
            {
                // Get players container reference
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

                // Delete old document using old email
                await container.DeleteItemAsync<Player>(email, new PartitionKey(email));

                // Insert new document using new email
                await container.CreateItemAsync<Player>(player, new PartitionKey(player.Email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while replacing player
                MessageBox.Show($"Failed to replace player in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Unexpected error while replacing player
                MessageBox.Show($"Unexpected error while replacing player.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Import SaveData from json string and update player document in cloud
        public static async Task<Player> ImportPlayerNewSaveDataAsync(Player player, string saveDetails)
        {
            // Stop if the provided json is empty
            if (string.IsNullOrEmpty(saveDetails))
            {
                MessageBox.Show("Save file content cannot be empty.", "Bad File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Reload player from cloud to avoid overwriting with stale data
            player = await GetPlayerByEmailAsync(player.Email);

            // Stop when player does not exist anymore
            if (player == null)
            {
                MessageBox.Show("Player was not found in the cloud.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            SaveData save;
            try
            {
                // Deserialize json into SaveData object
                save = JsonSerializer.Deserialize<SaveData>(saveDetails);

                // Ensure SaveData is not null after deserialization
                if (save == null)
                    throw new JsonException("SaveData is null");
            }
            catch (JsonException ex)
            {
                // Handle invalid json format
                MessageBox.Show($"Save JSON is not valid.\n{ex.Message}", "Bad File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Save JSON is not valid.\n{ex.Message} {Environment.NewLine}");
                return null;
            }

            // Replace current save with imported save
            player.Save = save;

            // Persist updated player document
            await UpdatePlayerAsync(player);

            // Keep admin document save in sync when player is also an admin
            if (await AdminExistsAsync(player.Email))
            {
                Admin admin = await GetAdminByEmailAsync(player.Email);
                if (admin != null)
                {
                    admin.Save = player.Save;
                    await UpdateAdminAsync(admin);
                }
            }

            // Return updated player instance for UI refresh
            return player;
        }

        // Load all player documents from the container
        public static async Task<List<Player>> GetAllPlayerListAsync()
        {
            List<Player> result = new List<Player>();

            try
            {
                // Get players container reference
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersTable);

                // Query iterator for all items
                FeedIterator<Player> itemIterator = container.GetItemQueryIterator<Player>();

                // Read pages until iterator completes
                while (itemIterator.HasMoreResults)
                {
                    foreach (Player player in await itemIterator.ReadNextAsync())
                    {
                        result.Add(player);
                    }
                }

                return result;
            }
            catch (CosmosException ex)
            {
                // Cloud error while loading players list
                MessageBox.Show($"Failed to load player list from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load player list from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
            catch (Exception ex)
            {
                // Unexpected error while loading players list
                MessageBox.Show($"Unexpected error while loading player list.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while loading player list.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
        }

        // Download cloud save and write it into the local game save file
        public static async Task GetSaveFileForGameToStartAsync(Player player)
        {
            try
            {
                // Get save json from cloud
                string save = await GetPlayerSaveDetails(player.Email);

                // Ensure local save directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.SavePath));

                // Write save json to local file for the game to load
                File.WriteAllText(AppPaths.SavePath, save);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to prepare local save file for game start.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to prepare local save file for game start.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Read local save and upload it into the cloud for the player
        public static async Task SaveGameToCloudAsync(Player player)
        {
            try
            {
                // Stop when local save file is missing
                if (!File.Exists(AppPaths.SavePath))
                {
                    MessageBox.Show("Local save file was not found.", "No Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Read local save json text
                string save = File.ReadAllText(AppPaths.SavePath);

                // Stop when local save is empty
                if (string.IsNullOrWhiteSpace(save))
                {
                    MessageBox.Show("Local save file is empty.", "Bad Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Upload save using the import logic
                await ImportPlayerNewSaveDataAsync(player, save);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to upload save to the cloud.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to upload save to the cloud.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Create or overwrite local player log file and upsert the cloud log document
        public static async Task CreatePlayerLogFile(PlayerLog playerLog)
        {
            try
            {
                // Convert log lines into a single text file
                string textToWrite = string.Join(Environment.NewLine, playerLog.LogContent);

                // Ensure log directory exists
                string dir = Path.GetDirectoryName(AppPaths.PlayerLogPath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                // Write logs to local file and add a trailing newline
                File.WriteAllText(AppPaths.PlayerLogPath, textToWrite + Environment.NewLine);

                // Keep document id synced with email
                playerLog.id = playerLog.Email;

                // Upsert log document in Cosmos
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersLogs);
                await container.UpsertItemAsync(playerLog, new PartitionKey(playerLog.Email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while saving player log
                MessageBox.Show($"Failed to save player log in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to save player log in cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Unexpected error while creating player log
                MessageBox.Show($"Unexpected error while creating player log file.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while creating player log file.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Read local player log file and replace the cloud log document
        public static async Task SavePlayerLogFile(PlayerLog playerLog)
        {
            try
            {
                // Stop when local player log file is missing
                if (!File.Exists(AppPaths.PlayerLogPath))
                {
                    MessageBox.Show("Local player log file was not found.", "No Log File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Read local log content
                string logContent = File.ReadAllText(AppPaths.PlayerLogPath);

                // Rebuild LogContent as list entries
                playerLog.LogContent = new List<string>();
                foreach (string line in logContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    playerLog.LogContent.Add(line);
                }

                // Remove last empty line created by trailing newline
                if (playerLog.LogContent.Count != 0)
                {
                    if (string.IsNullOrEmpty(playerLog.LogContent[playerLog.LogContent.Count - 1]))
                        playerLog.LogContent.RemoveAt(playerLog.LogContent.Count - 1);
                }

                // Replace cloud document using email as id and partition key
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersLogs);
                await container.ReplaceItemAsync<PlayerLog>(playerLog, playerLog.Email, new PartitionKey(playerLog.Email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while updating player log
                MessageBox.Show($"Failed to update player log in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to update player log in cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Unexpected error while saving player log
                MessageBox.Show($"Unexpected error while saving player log.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while saving player log.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Read local general log file and replace the cloud general log document
        public static async Task SaveGeneralLogFile(GeneralLog generalLog)
        {
            try
            {
                // Stop when local general log file is missing
                if (!File.Exists(AppPaths.GeneralLogPath))
                {
                    MessageBox.Show("Local general log file was not found.", "No Log File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Read local log text
                string logContent = File.ReadAllText(AppPaths.GeneralLogPath);

                // Rebuild LogContent as list entries
                generalLog.LogContent = new List<string>();
                foreach (string line in logContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    generalLog.LogContent.Add(line);
                }

                // Replace cloud document using id and partition key
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.GeneralLogs);
                await container.ReplaceItemAsync<GeneralLog>(generalLog, generalLog.Email, new PartitionKey(generalLog.Email));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                try
                {
                    // Create document if it does not exist yet
                    Container container = Instance.GetContainer(Constants.DataBaseName, Constants.GeneralLogs);

                    // Read local log text again for create path
                    string logContent = File.ReadAllText(AppPaths.GeneralLogPath);

                    // Rebuild LogContent as list entries
                    generalLog.LogContent = new List<string>();
                    foreach (string line in logContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                    {
                        generalLog.LogContent.Add(line);
                    }

                    // Create new general log document
                    await container.CreateItemAsync(generalLog, new PartitionKey(generalLog.Email));
                }
                catch (CosmosException ex2)
                {
                    // Cloud error while creating general log
                    MessageBox.Show($"Failed to save general log in cloud.\n{ex2.Message}",
                        "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to save general log in cloud.\n{ex2.Message} {Environment.NewLine}");
                }
            }
        }

        // Read local exception log file and upsert it to the cloud
        public static async Task SaveExceptionLogFile(ExceptionLog exceptionLog)
        {
            try
            {
                // Create local exception log file if missing
                if (!File.Exists(AppPaths.ExceptionLogPath))
                {
                    var dir = Path.GetDirectoryName(AppPaths.ExceptionLogPath);
                    if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.WriteAllText(AppPaths.ExceptionLogPath, string.Empty);
                }

                // Read local exception log text
                string logContent = File.ReadAllText(AppPaths.ExceptionLogPath);

                // Convert file lines into list entries
                var lines = new List<string>();
                foreach (string line in logContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                    lines.Add(line);

                // Store the list in the exception log object
                exceptionLog.LogContent = lines;

                // Upsert exception log document in Cosmos
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.GeneralLogs);
                await container.UpsertItemAsync(exceptionLog, new PartitionKey(exceptionLog.Email));
            }
            catch (CosmosException ex)
            {
                // Write cloud error to exception log
                ProjectUtils.WriteToExceptionlLog(
                    $"{DateTime.UtcNow} - CloudUtils - Failed to save exception log in cloud.\n{ex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Write unexpected error to exception log
                ProjectUtils.WriteToExceptionlLog(
                    $"{DateTime.UtcNow} - CloudUtils - Unexpected error while saving exception log.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Load player log document from cloud and write it into the local log file
        public static async Task<PlayerLog> GetPlayerLogFileAsync(Player player)
        {
            Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersLogs);

            try
            {
                // Read log document by email id and partition key
                ItemResponse<PlayerLog> result = await container.ReadItemAsync<PlayerLog>(player.Email, new PartitionKey(player.Email));
                PlayerLog playerLog = result.Resource;

                // Convert cloud log lines into a single local file text
                StringBuilder sb = new StringBuilder();
                if (playerLog?.LogContent != null)
                {
                    foreach (var line in playerLog.LogContent)
                        sb.AppendLine(line);
                }

                // Ensure local log directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.PlayerLogPath));

                // Write log content into local file
                File.WriteAllText(AppPaths.PlayerLogPath, sb.ToString());

                return playerLog;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create a default log document when missing
                PlayerLog newLog = new PlayerLog(player.Email, player.UserName);

                // Create cloud log document
                await container.CreateItemAsync(newLog, new PartitionKey(newLog.Email));

                // Ensure local log folder exists and create an empty file
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.PlayerLogPath));
                File.WriteAllText(AppPaths.PlayerLogPath, string.Empty);

                return newLog;
            }
            catch (CosmosException ex)
            {
                // Cloud error while loading player log
                MessageBox.Show($"Failed to load player log from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load player log from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
            catch (Exception ex)
            {
                // Unexpected error while loading player log
                MessageBox.Show($"Unexpected error while loading player log.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Unexpected error while loading player log.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
        }

        // Move player log document from old email to new email and delete the old document
        public static async Task ReplacePlayerLogAsync(Player player, string email)
        {
            try
            {
                // Load old player identity to access the old log
                Player oldPlayer = await GetPlayerByEmailAsync(email);
                if (oldPlayer == null)
                {
                    MessageBox.Show("Old player was not found in the cloud, cannot migrate logs.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Load old log and write it locally
                PlayerLog playerLog = await GetPlayerLogFileAsync(oldPlayer);
                if (playerLog == null)
                {
                    MessageBox.Show("Failed to load the old player's log from the cloud.",
                        "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Stop if local log file is missing
                if (!File.Exists(AppPaths.PlayerLogPath))
                    throw new FileNotFoundException("Local player log file not found.", AppPaths.PlayerLogPath);

                // Rebuild log content from local file lines
                playerLog.LogContent.Clear();
                string logContent = File.ReadAllText(AppPaths.PlayerLogPath);
                foreach (string line in logContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    playerLog.LogContent.Add(line);
                }

                // Update log identity to new player email and username
                playerLog.id = player.Email;
                playerLog.Email = player.Email;
                playerLog.UserName = player.UserName;

                // Upsert under new email and then delete old log document
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.PlayersLogs);

                if (playerLog.LogContent.Count > 0)
                {
                    // Remove last empty line created by split
                    playerLog.LogContent.RemoveAt(playerLog.LogContent.Count - 1);
                }

                await container.UpsertItemAsync(playerLog, new PartitionKey(playerLog.Email));
                await container.DeleteItemAsync<PlayerLog>(email, new PartitionKey(email));
            }
            catch (CosmosException ex)
            {
                // Cloud error while migrating log
                MessageBox.Show($"Failed to migrate player log in cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to migrate player log in cloud.\n{ex.Message} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Unexpected error while migrating log
                MessageBox.Show($"Failed to replace player log data.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to replace player log data.\n{ex.Message} {Environment.NewLine}");
            }
        }

        // Read exception log document from cloud and return log lines
        public static async Task<List<string>> GetExceptionLogAsync()
        {
            try
            {
                // Read exception log from the general logs container by fixed id
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.GeneralLogs);
                ItemResponse<ExceptionLog> result = await container.ReadItemAsync<ExceptionLog>(Constants.ExceptionLogID, new PartitionKey(Constants.ExceptionLogID));
                return result.Resource.LogContent;
            }
            catch (CosmosException ex)
            {
                // Cloud error while reading exception log
                MessageBox.Show($"Failed to load exception log from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load exception log from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
        }

        // Read general log document from cloud and return log lines
        public static async Task<List<string>> GetGeneralLogAsync()
        {
            try
            {
                // Read general log from the general logs container by fixed id
                Container container = Instance.GetContainer(Constants.DataBaseName, Constants.GeneralLogs);
                ItemResponse<GeneralLog> result = await container.ReadItemAsync<GeneralLog>(Constants.GeneralLogID, new PartitionKey(Constants.GeneralLogID));
                return result.Resource.LogContent;
            }
            catch (CosmosException ex)
            {
                // Cloud error while reading general log
                MessageBox.Show($"Failed to load general log from cloud.\n{ex.Message}",
                    "Cloud Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.UtcNow} - ClouUtils - Failed to load general log from cloud.\n{ex.Message} {Environment.NewLine}");
                return null;
            }
        }
    }
}
