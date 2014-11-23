using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Models.ResponseModels
{
    public sealed class CaseTypeResponse
    {
        public CaseTypeResponse()
        {
            CaseTypes = new List<CaseType>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<CaseType> CaseTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
