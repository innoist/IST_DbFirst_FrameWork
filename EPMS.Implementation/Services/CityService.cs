using System.Collections.Generic;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;

namespace EPMS.Implementation.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository iRepository;

        public CityService(ICityRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<City> LoadAll()
        {
            return iRepository.GetAll();
        }
    }
}
