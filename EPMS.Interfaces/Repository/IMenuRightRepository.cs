using System.Collections.Generic;
using System.Linq;
using IST.Models.MenuModels;

namespace IST.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
