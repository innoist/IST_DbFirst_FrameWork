using System.Collections.Generic;
using IST.Models.IdentityModels;
using IST.Models.IdentityModels.ViewModels;
using IST.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IST.Web.ViewModels.Admin
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