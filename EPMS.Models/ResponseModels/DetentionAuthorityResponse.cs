using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Models.ResponseModels
{
    public sealed class DetentionAuthorityResponse
    {
        public DetentionAuthorityResponse()
        {
            DetentionAuthorities = new List<DetentionAuthority>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<DetentionAuthority> DetentionAuthorities { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
