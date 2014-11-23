using System.Collections.Generic;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;

namespace EPMS.Implementation.Services
{
    /// <summary>
    /// Category Service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Private
        private readonly ICategoryRepository categoryRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

        }
        #endregion

        #region Public
        /// <summary>
        /// Load All Categories
        /// </summary>
        public IEnumerable<Category> LoadAllCategories()
        {

            return categoryRepository.GetAllCategories();
        }
        #endregion
    }
}
