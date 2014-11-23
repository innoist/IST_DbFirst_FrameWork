using System.Collections.Generic;
using EPMS.Models.IdentityModels;
using EPMS.Models.IdentityModels.ViewModels;
using EPMS.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EPMS.Web.ViewModels.Admin
{
    public class UserViewModel
    {
        /// <summary>
        /// Data
        /// </summary>
        public List<SystemUser> Data { get; set; }
        public string SelectedRoleId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}