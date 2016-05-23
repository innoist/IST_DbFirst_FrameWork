using System;
using IST.Models.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IST.Models.MenuModels
{
    /// <summary>
    /// MenuRights class for menu assoication with role
    /// </summary>
    public class MenuRight
    {
        public int MenuRightId { get; set; }
        public int? Menu_MenuId { get; set; }
        public string Role_Id { get; set; }

        public virtual AspNetRole AspNetRole { get; set; }
        public virtual Menu Menu { get; set; }
    }
}