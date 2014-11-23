using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.IServices
{
    public interface ICaseTypeService
    {
        /// <summary>
        /// Load all Case Types for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<CaseType> LoadAll();

        bool UpdateCaseType(CaseType casetype);

        void DeleteCaseType(CaseType casetype);

        bool AddCaseType(CaseType casetype);

        CaseTypeResponse GetAllCaseType(CaseTypeSearchRequest caseTypeSearchRequest);
        
        CaseType FindCaseTypeById(int? id);

    }
}
