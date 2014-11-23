using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.Repository
{
    public interface IDetentionAuthorityRepository : IBaseRepository<DetentionAuthority, int>
    {
        IEnumerable<DetentionAuthority> GetAll();

        DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest);
        DetentionAuthority FindDetentionAuthorityById(int detentionAuthorityId);
    }
}
