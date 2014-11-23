using System.Collections.Generic;
using EPMS.Models.DomainModels;

namespace EPMS.Interfaces.IServices
{
    public interface  ICityService
    {
        /// <summary>
        /// Load all Cities for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<City> LoadAll();
    }
}
