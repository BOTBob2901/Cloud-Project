using Cloud_FinalProject.Utils;
using System.Collections.Generic;

namespace Cloud_FinalProject.Modal
{
    public class GeneralLog
    {
        // Constant document id used for the general log in the cloud
        public readonly string id = Constants.GeneralLogID;

        // Fixed email field used as partition for the general log
        public readonly string Email = Constants.GeneralLogID;

        // List of general log lines stored in this document
        public List<string> LogContent { get; set; }

        //Ctor
        public GeneralLog()
        {
            LogContent = new List<string>();
        }
    }
}
