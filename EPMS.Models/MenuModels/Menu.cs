using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace EPMS.Models.MenuModels
{
    /// <summary>
    /// MainMenu class for dynamic menu population from database
    /// </summary>
    public class Menu
    {
        public int MenuId { get; set; }
        public int MenuKey { get; set; }
        public string MenuTitle { get; set; }
        public int SortOrder { get; set; }
        public string MenuTargetController { get; set; }
        public string MenuImagePath { get; set; }
        public string MenuFunction { get; set; }
        public string PermissionKey { get; set; }
        public bool IsRootItem { get; set; }
        public int? ParentItem_MenuId { get; set; }
        public bool IsMenuItem { get; set; }
        public string MenuTitleArbic { get; set; }
        public bool IsMenuItem1 { get; set; }

        public virtual Menu ParentItem { get; set; }
        public virtual ICollection<MenuRight> MenuRights { get; set; }
    }
}
