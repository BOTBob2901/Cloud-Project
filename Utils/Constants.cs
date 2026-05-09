using System.Configuration;

namespace Cloud_FinalProject.Utils
{
    public static class Constants
    {
        // Cosmos DB account endpoint loaded from App.config
        public static readonly string URI = ConfigurationManager.AppSettings["URI"];

        // Cosmos DB primary key loaded from App.config
        public static readonly string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];

        // Fixed document id for the general log in the cloud
        public static readonly string GeneralLogID = ConfigurationManager.AppSettings["GeneralLogID"];

        // Fixed document id for the exception log in the cloud
        public static readonly string ExceptionLogID = ConfigurationManager.AppSettings["ExceptionLogID"];

        // Godot project folder name under app_userdata
        public static readonly string GodotProjectName = ConfigurationManager.AppSettings["GodotProjectName"];

        // Save file name used by the Godot game
        public static readonly string SaveFileName = ConfigurationManager.AppSettings["SaveFileName"];

        // Folder name for logs under the app root folder
        public static readonly string LogFolderName = ConfigurationManager.AppSettings["LogFolderName"];

        // Local file name for the player log
        public static readonly string PlayerLogFileName = ConfigurationManager.AppSettings["PlayerLogFileName"];

        // Local file name for the general log
        public static readonly string GeneralLogFileName = ConfigurationManager.AppSettings["GeneralLogFileName"];

        // Local file name for the exception log
        public static readonly string ExceptionLogFileName = ConfigurationManager.AppSettings["ExceptionLogFileName"];

        // SMTP server host used for sending emails
        public static readonly string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];

        // SMTP server port used for sending emails
        public static readonly int SmtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

        // SMTP sender email address
        public static readonly string SmtpEmail = ConfigurationManager.AppSettings["SmtpEmail"];

        // SMTP app password for the sender email
        public static readonly string SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

        // Cosmos database name used by the project
        public static readonly string DataBaseName = "CloudFarm";

        // Cosmos container name for players
        public static readonly string PlayersTable = "Players";

        // Cosmos container name for admins
        public static readonly string AdminsTable = "Admins";

        // Cosmos container name for player logs
        public static readonly string PlayersLogs = "PlayersLogs";

        // Cosmos container name for system logs
        public static readonly string GeneralLogs = "GeneralLogs";
    }
}
