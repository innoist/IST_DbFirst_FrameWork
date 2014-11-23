using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Interfaces.Repository
{
    public interface ICityRepository
    {
        /// <summary>
        /// Get All Cities
        /// </summary>
        /// <returns></returns>
        IEnumerable<City> GetAll();
    }
}
