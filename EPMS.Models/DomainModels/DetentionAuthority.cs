using System;
using System.Collections.Generic;

namespace EPMS.Models.DomainModels
{
    public class DetentionAuthority
    {
        #region Persisted Properties
        /// <summary>
        /// Detention Authority Id
        /// </summary>
        public int DetentionAuthorityId { get; set; }
        /// <summary>
        /// Detention Authority Name
        /// </summary>
        public string DetentionAuthorityName { get; set; }
        /// <summary>
        /// Detention Authority Description
        /// </summary>
        public string DetentionAuthorityDescription { get; set; }

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
