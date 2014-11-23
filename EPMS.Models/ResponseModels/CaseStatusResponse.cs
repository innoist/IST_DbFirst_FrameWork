using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Models.ResponseModels
{
    public sealed class CaseStatusResponse
    {
        public CaseStatusResponse()
        {
            CaseStatuses = new List<CaseStatus>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<CaseStatus> CaseStatuses { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
