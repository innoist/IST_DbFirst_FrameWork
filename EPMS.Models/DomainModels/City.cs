using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Models.DomainModels
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<PrisonerCaseInfo> PrisonerCaseInfoes { get; set; }
        public ICollection<PrisonerWorkInfo> PrisonerWorkInfoes { get; set; }
    }
}
