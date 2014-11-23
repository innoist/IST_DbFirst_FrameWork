using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
