using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Models.ResponseModels
{
    public sealed class PrisonerResponse
    {
        public PrisonerResponse()
        {
            Prisoners = new List<Prisoner>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<Prisoner> Prisoners { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
