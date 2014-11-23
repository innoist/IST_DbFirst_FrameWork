using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.Repository
{
    public interface ICaseTypeRepository : IBaseRepository<CaseType, int>
    {
        IEnumerable<CaseType> GetAll();

        CaseTypeResponse GetAllCaseTypes(CaseTypeSearchRequest caseTypeSearchRequest);
        CaseType FindCaseTypeById(int caseTypeId);

    }
}
