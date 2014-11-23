using System.Collections.Generic;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;
using EPMS.Models.ModelMapers;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Implementation.Services
{
    public class CaseTypeService : ICaseTypeService
    {
        private readonly ICaseTypeRepository iRepository;

        public CaseTypeService(ICaseTypeRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<CaseType> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateCaseType(CaseType caseType)
        {
            var caseTypeToupdate = FindCaseTypeById(caseType.CaseTypeId);
            if (caseTypeToupdate != null)
            {
                caseType.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteCaseType(CaseType caseType)
        {
            iRepository.Delete(caseType);
            iRepository.SaveChanges();
        }

        public bool AddCaseType(CaseType caseType)
        {
            iRepository.Add(caseType);
            iRepository.SaveChanges();
            return true;
        }

        public CaseTypeResponse GetAllCaseType(CaseTypeSearchRequest caseTypeSearchRequest)
        {
            return iRepository.GetAllCaseTypes(caseTypeSearchRequest);
        }

        public CaseType FindCaseTypeById(int? id)
        {
            if (id != null) return iRepository.FindCaseTypeById((int)id);
            return null;
        }
    }
}
