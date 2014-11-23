using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Models.DomainModels;

namespace EPMS.Models.ResponseModels
{
    public sealed class DetentionLocationResponse
    {
        public DetentionLocationResponse()
        {
            DetentionLocations = new List<DetentionLocation>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<DetentionLocation> DetentionLocations { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
