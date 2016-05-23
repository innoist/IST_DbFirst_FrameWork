
using System.Collections.Generic;

namespace IST.Models.LoggerModels
{
    /// <summary>
    /// Log Category Class for database logging
    /// </summary>
    public sealed class LogCategory
    {
        public int LogCategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<CategoryLog> CategoryLogs { get; set; }
    }
}
