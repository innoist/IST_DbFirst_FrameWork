using System;
using System.ComponentModel.DataAnnotations;

namespace EPMS.Models.DomainModels
{
    public class Attachment
    {
        

        [Key]
        public int AttachmentId { get; set; }
        public int PrisonerId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string AttachmentName { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Prisoner Prisoner{ get; set; }
    }
}
