using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Models.Common;

namespace EPMS.Models.RequestModels
{
    public class PrisonerSearchRequest : GetPagedListRequest
    {

        public string PrisonerId { get; set; }

        public string PrisonerName { get; set; }

        public string PrisonerCnic { get; set; }

        public string PrisonerPassport { get; set; }

        public string Address { get; set; }

        public string Iqama { get; set; }
        
        public string Profession { get; set; }

        public int? CaseType { get; set; }

        public int? CaseStatus { get; set; }

        public Guid UserId { get; set; }

        public PrisonerByColumn PrisonerByColumn
        {
            get
            {
                return (PrisonerByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
