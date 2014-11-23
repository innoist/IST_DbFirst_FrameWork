using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.IServices
{
    public interface IDetentionLocationService
    {
        /// <summary>
        /// Load all Detention Locations for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<DetentionLocation> LoadAll();

        bool UpdateDetentionLocation(DetentionLocation detentionLocation);

        void DeleteDetentionLocation(DetentionLocation detentionLocation);

        bool AddDetentionLocation(DetentionLocation detentionLocation);

        DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest);

        DetentionLocation FindDetentionLocationById(int? id);
    }
}
