using System;

namespace EPMS.Web.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int PrisonerId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string AttachmentName { get; set; }
        public string Comment { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}