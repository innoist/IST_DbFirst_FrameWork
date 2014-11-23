using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;
using EPMS.Models.ModelMapers;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Implementation.Services
{
    public class CaseStatusService : ICaseStatusService
    {
        private readonly ICaseStatusRepository iRepository;

        public CaseStatusService(ICaseStatusRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<CaseStatus> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateCaseStatus(CaseStatus caseStatus)
        {
            var caseStatusToupdate = FindCaseStatusById(caseStatus.CaseStatusId);
            if (caseStatusToupdate != null)
            {
                caseStatus.UpdateTo(caseStatusToupdate);
                iRepository.Update(caseStatusToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteCaseStatus(CaseStatus caseStatus)
        {
            iRepository.Delete(caseStatus);
            iRepository.SaveChanges();
        }

        public bool AddCaseStatus(CaseStatus caseStatus)
        {
            iRepository.Add(caseStatus);
            iRepository.SaveChanges();
            return true;
        }

        public CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest)
        {
            return iRepository.GetAllCaseStatuses(caseStatusSearchRequest);
        }

        public CaseStatus FindCaseStatusById(int? id)
        {
            if (id != null) return iRepository.FindCaseStatusById((int)id);
            return null;
        }
    }
}
