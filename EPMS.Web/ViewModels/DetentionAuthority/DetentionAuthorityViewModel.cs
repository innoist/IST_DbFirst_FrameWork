using System.Collections.Generic;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.DetentionAuthority
{
    public class DetentionAuthorityViewModel
    {
        public IEnumerable<Models.DetentionAuthority> DetentionAuthorityList { get; set; }

        //Take Data For Edit
        public Models.DetentionAuthority DetentionAuthority { get; set; }

        public DetentionAuthoritySearchRequest SearchRequest { get; set; }
    }
}