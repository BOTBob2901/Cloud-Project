using Cloud_FinalProject.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_FinalProject.Utils
{
    public class ProjectUtils
    {
        // Create an MD5 hash from a string and return it as Base64 text
        public static string Encrypt(string value)
        {
            try
            {
                // Return empty when input is missing
                if (string.IsNullOrEmpty(value))
                    return string.Empty;

                // Hash UTF8 bytes using MD5
                using (MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider())
                {
                    byte[] data = crypto.ComputeHash(Encoding.UTF8.GetBytes(value));
                    return Convert.ToBase64String(data);
                }
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to encrypt value.\n{ex.Message}", "Encryption Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Failed to encrypt value.\n{ex.Message}{Environment.NewLine}");
                return string.Empty;
            }
        }

        // Export SaveData to a json file using a save dialog
        public static void ExportSaveToJsonFile(SaveData save, string fileName = "save.json")
        {
            // Stop when save data is null
            if (save == null)
            {
                MessageBox.Show("Save data is empty (null).", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Serialize SaveData to json string
                string json = SaveToJsonString(save);

                // Ask user where to save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    FileName = fileName
                };

                // Stop if user cancelled the dialog
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                // Write json text into the selected file path
                File.WriteAllText(saveFileDialog.FileName, json, Encoding.UTF8);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle missing permission to write
                MessageBox.Show($"No permission to write the file.\n{ex.Message}", "Permission Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - No permission to write the file.\n{ex.Message}{Environment.NewLine}");
            }
            catch (IOException ex)
            {
                // Handle filesystem write errors
                MessageBox.Show($"File system error while exporting save.\n{ex.Message}", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - File system error while exporting save.\n{ex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Handle unexpected export errors
                MessageBox.Show($"Unexpected error while exporting save.\n{ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Unexpected error while exporting save.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Serialize SaveData into an indented json string for readability
        public static string SaveToJsonString(SaveData save)
        {
            // Configure pretty printed json
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Serialize SaveData with options
            return JsonSerializer.Serialize(save, options);
        }

        // Verify that text is valid SaveData json and includes valid inventory
        public static bool TextToJsonVerification(string jsonTxt)
        {
            // Stop when input is empty
            if (string.IsNullOrEmpty(jsonTxt))
                return false;

            var options = new JsonSerializerOptions
            {
                // Keep strict property name matching
                PropertyNameCaseInsensitive = false,
                AllowTrailingCommas = false,
                ReadCommentHandling = JsonCommentHandling.Disallow,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            };

            try
            {
                // Try to parse SaveData from json
                SaveData save = JsonSerializer.Deserialize<SaveData>(jsonTxt, options);

                // Valid only if deserialization worked and inventory rules pass
                return save != null && ValidateInventory(save.inventory);
            }
            catch (JsonException)
            {
                // Invalid json or wrong structure
                return false;
            }
            catch
            {
                // Any other unexpected failure
                return false;
            }
        }

        // List of allowed inventory keys to prevent missing or extra resources
        private static readonly HashSet<string> AllowedInventoryKeys = new HashSet<string>(StringComparer.Ordinal)
        {
            "corn","egg","log","milk","stone","tomato"
        };

        // Validate inventory keys and values before accepting SaveData
        private static bool ValidateInventory(Dictionary<string, int> inventory)
        {
            // Inventory must exist
            if (inventory == null) return false;

            // Require exact match of allowed keys with no extras and no missing keys
            if (!AllowedInventoryKeys.SetEquals(inventory.Keys))
                return false;

            // Disallow negative amounts
            foreach (var vlaue in inventory.Values)
                if (vlaue < 0) return false;

            return true;
        }

        // Append a line to the local player log file
        public static void WriteToPlayerLog(string msg)
        {
            try
            {
                // Ensure log directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.PlayerLogPath));

                // Append message text to file
                File.AppendAllText(AppPaths.PlayerLogPath, msg);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to write to player log.\n{ex.Message}", "Log Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Failed to write to player log.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Append a line to the local general log file
        public static void WriteToGeneralLog(string msg)
        {
            try
            {
                // Ensure log directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.GeneralLogPath));

                // Append message text to file
                File.AppendAllText(AppPaths.GeneralLogPath, msg);
            }
            catch (Exception ex)
            {
                // Show error and log it
                MessageBox.Show($"Failed to write to general log.\n{ex.Message}", "Log Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Failed to write to general log.\n{ex.Message}{Environment.NewLine}");
            }
        }

        // Append a line to the local exception log file
        public static void WriteToExceptionlLog(string msg)
        {
            try
            {
                // Ensure log directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(AppPaths.ExceptionLogPath));

                // Append message text to file
                File.AppendAllText(AppPaths.ExceptionLogPath, msg);
            }
            catch (Exception ex)
            {
                // Show error when exception log write fails
                MessageBox.Show($"Failed to write to exception log.\n{ex.Message}", "Log Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Compare local save file json with the current in memory SaveData json
        public static bool IsGameSaved(Player player)
        {
            try
            {
                // Stop when player is null
                if (player == null)
                {
                    MessageBox.Show("Player is null.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Stop when SaveData is missing
                if (player.Save == null)
                {
                    MessageBox.Show("Player has no save data in memory.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Stop when local save file does not exist
                if (!File.Exists(AppPaths.SavePath))
                {
                    MessageBox.Show("Local save file was not found.", "No Save File",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Serialize json without formatting for stable comparison
                var options = new JsonSerializerOptions
                {
                    WriteIndented = false
                };

                // Normalize file json by parsing and re serializing
                string fileText = File.ReadAllText(AppPaths.SavePath);
                object fileObj = JsonSerializer.Deserialize<object>(fileText);

                // Stop if file json is invalid
                if (fileObj == null)
                {
                    MessageBox.Show("Local save file content is not valid JSON.", "Bad Save File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Normalized file json
                string fileJson = JsonSerializer.Serialize(fileObj, options);

                // Normalized memory json
                string memoryJson = JsonSerializer.Serialize(player.Save, options);

                // True means there are changes that should be uploaded
                return fileJson != memoryJson;
            }
            catch (JsonException ex)
            {
                // Handle invalid json in the local save file
                MessageBox.Show($"Save JSON is not valid.\n{ex.Message}", "Bad Save File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Save JSON is not valid.\n{ex.Message}{Environment.NewLine}");
                return false;
            }
            catch (IOException ex)
            {
                // Handle file access errors while reading
                MessageBox.Show($"File system error while checking save.\n{ex.Message}", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - File system error while checking save.\n{ex.Message}{Environment.NewLine}");
                return false;
            }
            catch (Exception ex)
            {
                // Handle unexpected comparison errors
                MessageBox.Show($"Unexpected error while checking if game is saved.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Unexpected error while checking if game is saved.\n{ex.Message}{Environment.NewLine}");
                return false;
            }
        }

        // Generate a temporary password using cryptographically strong random bytes
        public static string GenerateTempPassword(int bytes = 12)
        {
            // Allocate buffer for random bytes
            byte[] data = new byte[bytes];

            // Fill buffer with secure random bytes
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);

            // Convert bytes to Base64 string for easy copy and paste
            return Convert.ToBase64String(data);
        }

        // Send a temporary password email using SMTP and return success state
        public static async Task<bool> SendPasswordRestoreMail(string toEmail, string randomTempPassword)
        {
            try
            {
                // Email subject shown in the inbox
                string subject = "Cloud Farm - Temporary Password";

                // Build plain text message body
                string body = $"Your temporary password is: {randomTempPassword}\r\n" +
                              "Please log in and change it immediately.\r\n " +
                              "Don't share the password with anyone.\r\n " +
                              "Do not reply!";

                // Build the mail message object
                var message = new MailMessage(Constants.SmtpEmail, toEmail, subject, body);
                message.SubjectEncoding = Encoding.UTF8;
                message.BodyEncoding = Encoding.UTF8;

                // Disable html and send plain text only
                message.IsBodyHtml = false;

                // Configure SMTP client connection and credentials
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Constants.SmtpEmail, Constants.SmtpPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                // Send mail without blocking UI thread
                await smtp.SendMailAsync(message);

                return true;
            }
            catch (Exception ex)
            {
                // Show send error and log it
                MessageBox.Show($"Failed to send password restore email.\n{ex.Message}",
                    "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                WriteToExceptionlLog($"{DateTime.Now} - ProjectUtils - Failed to send password restore email.\n{ex.Message}{Environment.NewLine}");

                return false;
            }
        }
    }
}
