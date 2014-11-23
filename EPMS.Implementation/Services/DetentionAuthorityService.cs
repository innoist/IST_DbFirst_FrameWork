using System.Collections.Generic;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;
using EPMS.Models.ModelMapers;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Implementation.Services
{
    public class DetentionAuthorityService : IDetentionAuthorityService
    {
        private readonly IDetentionAuthorityRepository iRepository;

        public DetentionAuthorityService(IDetentionAuthorityRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<DetentionAuthority> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            var caseTypeToupdate = FindDetentionAuthorityById(detentionAuthority.DetentionAuthorityId);
            if (caseTypeToupdate != null)
            {
                detentionAuthority.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            iRepository.Delete(detentionAuthority);
            iRepository.SaveChanges();
        }

        public bool AddDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            iRepository.Add(detentionAuthority);
            iRepository.SaveChanges();
            return true;
        }

        public DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest)
        {
            return iRepository.GetAllDetentionAuthorities(detentionAuthoritySearchRequest);
        }

        public DetentionAuthority FindDetentionAuthorityById(int? id)
        {
            if (id != null) return iRepository.FindDetentionAuthorityById((int)id);
            return null;
        }
    }
}
