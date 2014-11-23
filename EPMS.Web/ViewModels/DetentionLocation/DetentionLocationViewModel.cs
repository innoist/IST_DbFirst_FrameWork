using System.Collections.Generic;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.DetentionLocation
{
    public class DetentionLocationViewModel
    {
        public IEnumerable<Models.DetentionLocation> DetentionLocationList { get; set; }

        //Take Data For Edit
        public Models.DetentionLocation DetentionLocation { get; set; }

        public DetentionLocationSearchRequest SearchRequest { get; set; }
    }
}