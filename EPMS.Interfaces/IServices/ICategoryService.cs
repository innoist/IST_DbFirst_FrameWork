using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadAllCategories();
    }
}
