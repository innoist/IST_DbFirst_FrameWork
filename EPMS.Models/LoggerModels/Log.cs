using System;
using System.Collections.Generic;

namespace EPMS.Models.LoggerModels
{
    /// <summary>
    /// Log class for database logging
    /// </summary>
    public class Log
    {
        public int LogID { get; set; }
        public int EventID { get; set; }
        public int Priority { get; set; }
        public string Severity { get; set; }
        public string Title { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string MachineName { get; set; }
        public string AppDomainName { get; set; }
        public string ProcessID { get; set; }
        public string ProcessName { get; set; }
        public string ThreadName { get; set; }
        public string Win32ThreadId { get; set; }
        public string Message { get; set; }
        public string FormattedMessage { get; set; }
        public string HandlingInstanceId { get; set; }

        public virtual ICollection<CategoryLog> CategoryLogs { get; set; }
    }
}
