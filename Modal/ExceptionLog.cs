using Cloud_FinalProject.Utils;
using System.Collections.Generic;

namespace Cloud_FinalProject.Modal
{
    public class ExceptionLog
    {
        // Constant document id used for the exception log in the cloud
        public readonly string id = Constants.ExceptionLogID;

        // Fixed email field used as partition for the exception log
        public readonly string Email = Constants.ExceptionLogID;

        // List of exception log lines stored in this document
        public List<string> LogContent { get; set; }

        //Ctor
        public ExceptionLog()
        {
            LogContent = new List<string>();
        }
    }
}
