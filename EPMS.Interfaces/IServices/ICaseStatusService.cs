using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.IServices
{
    public interface ICaseStatusService
    {
        /// <summary>
        /// Load all Case Statuses for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<CaseStatus> LoadAll();

        bool UpdateCaseStatus(CaseStatus caseStatus);

        void DeleteCaseStatus(CaseStatus caseStatus);

        bool AddCaseStatus(CaseStatus caseStatus);

        CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest);

        CaseStatus FindCaseStatusById(int? id);
    }
}
