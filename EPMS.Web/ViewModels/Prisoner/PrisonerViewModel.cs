using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.Prisoner
{
    public class PrisonerViewModel
    {
        //Show List On ClientSide
        public IEnumerable<Models.Prisoner> PrisonerList { get; set; }
        public IEnumerable<Models.Prisoner> PrisonerDetainedList { get; set; }
        public IEnumerable<Models.Prisoner> PrisonerReleasedList { get; set; }

        public IEnumerable<Models.PrisonerAddress> PrisonerAddressList { get; set; }

        public IEnumerable<Models.PrisonerWorkInfo> PrisonerWorkInfoList { get; set; }

        public IEnumerable<Models.PrisonerCaseInfo> PrisonerCaseInfoList { get; set; }

        public IEnumerable<EPMS.Models.DomainModels.CaseType> CaseTypes { get; set; }

        public IEnumerable<EPMS.Models.DomainModels.CaseStatus> CaseStatuses { get; set; }

        public IEnumerable<EPMS.Models.DomainModels.DetentionAuthority> DetanAuthorities { get; set; }

        public IEnumerable<EPMS.Models.DomainModels.DetentionLocation> DetanLocations { get; set; }

        public IEnumerable<City> Cities { get; set; }
        

        //Take Data For Edit
        public Models.Prisoner Prisoner { get; set; }

        public PrisonerSearchRequest SearchRequest { get; set; }

        public int DetainedToday { get; set; }
        public int ReleasedToday { get; set; }
        public int DetainedWeek { get; set; }
        public int ReleasedWeek { get; set; }
        public int DetainedMonth { get; set; }
        public int ReleasedMonth { get; set; }
    }
}