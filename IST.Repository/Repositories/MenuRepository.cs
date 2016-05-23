using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IST.Interfaces.Repository;
using IST.Models.MenuModels;
using Microsoft.Practices.Unity;
using IST.Repository.BaseRepository;

namespace IST.Web.Views.RolesAdmin
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Menu> DbSet
        {
            get { return db.Menus; }
        }
        #endregion
    }
}