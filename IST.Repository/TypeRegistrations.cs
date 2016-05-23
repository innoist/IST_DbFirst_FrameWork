using System.Data.Entity;
using IST.Interfaces.Repository;
using IST.Repository.BaseRepository;
using IST.Repository.Repositories;
using IST.Web.Views.RolesAdmin;
using Microsoft.Practices.Unity;

namespace IST.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IMenuRepository, MenuRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
        }
    }
}
