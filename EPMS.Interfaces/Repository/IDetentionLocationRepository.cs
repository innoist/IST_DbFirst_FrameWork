using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.Repository
{
    public interface IDetentionLocationRepository : IBaseRepository<DetentionLocation, int>
    {
        IEnumerable<DetentionLocation> GetAll();

        DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest);
        DetentionLocation FindDetentionLocationById(int detentionLocationId);
    }
}
