using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Models.DomainModels
{
    public class CaseStatus
    {
        #region Persisted Properties
        /// <summary>
        /// Case Status Id
        /// </summary>
        public int CaseStatusId { get; set; }
        /// <summary>
        /// Case Status Name
        /// </summary>
        public string CaseStatusName { get; set; }
        /// <summary>
        ///  Case Status Description
        /// </summary>
        public string CaseStatusDescription { get; set; }

        #endregion

        public ICollection<PrisonerCaseInfo> PrisonerCaseInfoes { get; set; }
    }
}
