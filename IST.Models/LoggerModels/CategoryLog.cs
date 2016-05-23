
namespace IST.Models.LoggerModels
{
    /// <summary>
    /// Category Log class for database logging
    /// </summary>
    public class CategoryLog
    {
        public int CategoryLogID { get; set; }
        public int LogCategoryID { get; set; }
        public int LogID { get; set; }

        public virtual Log Log { get; set; }
        public virtual LogCategory LogCategory { get; set; }

    }
}
