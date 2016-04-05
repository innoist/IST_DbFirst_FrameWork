using System.Data.Entity;
using EPMS.Interfaces.Repository;
using EPMS.Repository.BaseRepository;
using EPMS.Repository.Repositories;
using EPMS.Web.Views.RolesAdmin;
using Microsoft.Practices.Unity;

namespace EPMS.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<ICaseTypeRepository, CaseTypeRepository>();
            unityContainer.RegisterType<IMenuRepository, MenuRepository>();

            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
            //unityContainer.RegisterType<IUser, ApplicationUser>();
        }
    }
}
