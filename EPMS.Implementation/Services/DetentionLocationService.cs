using System.Collections.Generic;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;
using EPMS.Models.ModelMapers;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Implementation.Services
{
    public class DetentionLocationService : IDetentionLocationService
    {
        private readonly IDetentionLocationRepository iRepository;

        public DetentionLocationService(IDetentionLocationRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<DetentionLocation> LoadAll()
        {
            return iRepository.GetAll();
        }
        public bool UpdateDetentionLocation(DetentionLocation detentionLocation)
        {
            var caseTypeToupdate = FindDetentionLocationById(detentionLocation.DetentionLocationId);
            if (caseTypeToupdate != null)
            {
                detentionLocation.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public void DeleteDetentionLocation(DetentionLocation detentionLocation)
        {
            iRepository.Delete(detentionLocation);
            iRepository.SaveChanges();
        }

        public bool AddDetentionLocation(DetentionLocation detentionLocation)
        {
            iRepository.Add(detentionLocation);
            iRepository.SaveChanges();
            return true;
        }

        public DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest)
        {
            return iRepository.GetAllDetentionLocations(detentionLocationSearchRequest);
        }

        public DetentionLocation FindDetentionLocationById(int? id)
        {
            if (id != null) return iRepository.FindDetentionLocationById((int)id);
            return null;
        }

    }
}
