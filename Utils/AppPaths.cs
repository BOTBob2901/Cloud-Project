namespace Cloud_FinalProject.Utils
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Windows.Forms;

    public static class AppPaths
    {
        // Main folder name stored under AppData for this application
        private const string AppFolderName = "Cloud Farm";

        // Root folder path for app files inside AppData
        public static string AppDataRoot =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppFolderName);

        // Full path to the Godot save file inside the Godot AppData structure
        public static string SavePath
        {
            get
            {
                // Read project and file naming from constants
                string projectName = Constants.GodotProjectName;
                string fileName = Constants.SaveFileName;

                // Build the Godot save location path
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Godot",
                    "app_userdata",
                    projectName,
                    "game_data",
                    fileName
                );
            }
        }

        // Folder path that contains all log files for this app
        public static string LogFolder =>
            Path.Combine(AppDataRoot, Constants.LogFolderName);

        // Full path to the player log file on disk
        public static string PlayerLogPath =>
            Path.Combine(LogFolder, Constants.PlayerLogFileName);

        // Full path to the general system log file on disk
        public static string GeneralLogPath =>
            Path.Combine(LogFolder, Constants.GeneralLogFileName);

        // Full path to the exception log file on disk
        public static string ExceptionLogPath =>
            Path.Combine(LogFolder, Constants.ExceptionLogFileName);

        // Create required folders for save and logs if they do not exist
        public static void EnsureFolders()
        {
            try
            {
                // Create the Godot save directory if missing
                Directory.CreateDirectory(Path.GetDirectoryName(SavePath));

                // Create log folder for player log if missing
                Directory.CreateDirectory(Path.GetDirectoryName(PlayerLogPath));

                // Create log folder for general log if missing
                Directory.CreateDirectory(Path.GetDirectoryName(GeneralLogPath));

                // Create log folder for exception log if missing
                Directory.CreateDirectory(Path.GetDirectoryName(ExceptionLogPath));
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle missing permissions for AppData folder creation
                MessageBox.Show($"No permission to create app folders in AppData.\n{ex.Message}",
                    "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AppPaths - UnauthorizedAccessException while creating app folders: {ex.Message}{Environment.NewLine}");
            }
            catch (IOException ex)
            {
                // Handle filesystem errors when creating directories
                MessageBox.Show($"File system error while creating app folders.\n{ex.Message}",
                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AppPaths - IOException while creating app folders: {ex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and log them
                MessageBox.Show($"Unexpected error while creating app folders.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProjectUtils.WriteToExceptionlLog($"{DateTime.Now} - AppPaths - Exception while creating app folders: {ex.Message}{Environment.NewLine}");
            }
        }
    }
}
