using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.MenuModels;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EPMS.Interfaces.IServices
{
    /// <summary>
    /// Interface for Menu Rights Service
    /// </summary>
    public interface IMenuRightsService
    {
        /// <summary>
        /// Find Menu item by Role
        /// </summary>        
        IEnumerable<MenuRight> FindMenuItemsByRoleId(string roleId);

        /// <summary>
        /// Save Roles Menu Rights
        /// </summary>
        UserMenuResponse SaveRoleMenuRight(string roleId, string menuIds, AspNetRole role);

        /// <summary>
        /// Get Role Menu Rights
        /// </summary>
        UserMenuResponse GetRoleMenuRights(string roleId);
    }
}
