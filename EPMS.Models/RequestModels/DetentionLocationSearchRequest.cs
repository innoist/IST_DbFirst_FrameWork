using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Models.Common;

namespace EPMS.Models.RequestModels
{
    public sealed class DetentionLocationSearchRequest : GetPagedListRequest
    {
        public string DetentionLocationId { get; set; }

        public string DetentionLocationName { get; set; }

        public string DetentionLocationDescrition { get; set; }

        public Guid UserId { get; set; }

        public DetentionLocationByColumn DetentionLocationByColumn
        {
            get
            {
                return (DetentionLocationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
