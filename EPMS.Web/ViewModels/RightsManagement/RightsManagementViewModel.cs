using System.Collections.Generic;
using IST.Models.DomainModels;
using IST.Models.MenuModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IST.Web.ViewModels.RightsManagement
{
    public class RightsManagementViewModel
    {
        public List<Rights> Rights { get; set; }
        public string SelectedRoleId { get; set; }

        public List<AspNetRole> Roles { get; set; }
    }
}