using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.Repository
{
    public interface ICaseStatusRepository : IBaseRepository<CaseStatus, int>
    {
        IEnumerable<CaseStatus> GetAll();

        CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest);
        CaseStatus FindCaseStatusById(int caseStatusId);
    }
}
