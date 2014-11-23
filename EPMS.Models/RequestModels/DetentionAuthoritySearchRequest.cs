using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Models.Common;

namespace EPMS.Models.RequestModels
{
    public class DetentionAuthoritySearchRequest :  GetPagedListRequest
    {
        public string DetentionAuthorityId { get; set; }

        public string DetentionAuthorityName { get; set; }

        public string DetentionAuthorityDescrition { get; set; }

        public Guid UserId { get; set; }

        public DetentionAuthorityByColumn DetentionAuthorityByColumn
        {
            get
            {
                return (DetentionAuthorityByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
