using System.Collections.Generic;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.CaseType
{
    public class CaseTypeViewModel
    {
        public IEnumerable<Models.CaseType> CaseTypeList { get; set; }

        //Take Data For Edit
        public Models.CaseType CaseType { get; set; }

        public CaseTypeSearchRequest SearchRequest { get; set; }

    }
}