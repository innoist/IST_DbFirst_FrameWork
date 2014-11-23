using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Models.Common;

namespace EPMS.Models.RequestModels
{
    public class CaseStatusSearchRequest : GetPagedListRequest
    {
        public string CaseStatusId { get; set; }

        public string CaseStatusName { get; set; }

        public string CaseStatusDescrition { get; set; }

        public Guid UserId { get; set; }

        public CaseStatusByColumn CaseStatusByColumn
        {
            get
            {
                return (CaseStatusByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
