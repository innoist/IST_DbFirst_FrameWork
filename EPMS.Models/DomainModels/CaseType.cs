using System;
using System.Collections.Generic;

namespace EPMS.Models.DomainModels
{
    public class CaseType
    {
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public string CaseTypeDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CaseCategoryId { get; set; }
    }
}
