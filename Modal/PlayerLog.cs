using System.Collections.Generic;

namespace Cloud_FinalProject.Modal
{
    public class PlayerLog
    {
        // Unique document id usually equals player email
        public string id { get; set; }

        // Player email used as identifier and partition key
        public string Email { get; set; }

        // Player username saved for display and log context
        public string UserName { get; set; }

        // List of log lines for this player session history
        public List<string> LogContent { get; set; }

        // Empty constructor required for deserialization
        public PlayerLog() { }

        public PlayerLog(string email, string userName)
        {
            // Keep id and email in sync
            id = email;
            Email = email;

            // Store the username snapshot for this log document
            UserName = userName;

            LogContent = new List<string>();
        }
    }
}
