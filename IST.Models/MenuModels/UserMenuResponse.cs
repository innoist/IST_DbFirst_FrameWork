using System.Collections.Generic;
using IST.Models.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IST.Models.MenuModels
{
    public class UserMenuResponse
    {
        public IList<MenuRight> MenuRights { get; set; }

        public IList<Menu> Menus { get; set; }

        public IList<AspNetRole> Roles { get; set; }
    }
}
