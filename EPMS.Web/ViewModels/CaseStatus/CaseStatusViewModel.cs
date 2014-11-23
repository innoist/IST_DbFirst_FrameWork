using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.CaseStatus
{
    public class CaseStatusViewModel
    {
        public IEnumerable<Models.CaseStatus> CaseStatusList { get; set; }

        //Take Data For Edit
        public Models.CaseStatus CaseStatus { get; set; }

        public CaseStatusSearchRequest SearchRequest { get; set; }
    }
}