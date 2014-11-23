using System;
using System.Collections.Generic;

namespace EPMS.Models.DomainModels
{
    public class CaseType
    {
        #region Persisted Properties
        /// <summary>
        /// Case Type Id
        /// </summary>
        public int CaseTypeId { get; set; }
        /// <summary>
        /// Case Type Name
        /// </summary>
        public string CaseTypeName { get; set; }
        /// <summary>
        /// Case Type Description
        /// </summary>
        public string CaseTypeDescription { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Record Updated By
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Record Updated Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
        public ICollection<PrisonerCaseInfo> PrisonerCaseInfoes { get; set; }
    }
}
