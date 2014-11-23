using System.Collections.Generic;
using System.Linq;
using EPMS.Models.MenuModels;

namespace EPMS.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
