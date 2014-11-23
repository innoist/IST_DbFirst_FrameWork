using System;
using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;


namespace EPMS.Interfaces.IServices
{
    public interface IPrisonerService
    {
        bool AddPrisoner(Prisoner prisoner);
        /// <summary>
        /// Get all Prisoners by Column
        /// </summary>
        /// <param name="prisonerSearchRequest"></param>
        /// <returns></returns>
        PrisonerResponse GetAllPrisoners(PrisonerSearchRequest prisonerSearchRequest);
        /// <summary>
        /// Prisoner by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Prisoner FindPrisonerById(int? id);
        /// <summary>
        /// Get all Prisoners
        /// </summary>
        /// <returns></returns>
        IEnumerable<Prisoner> GetAllPrisoners();
        /// <summary>
        /// Get all Prisoners Detained (Reporting)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerable<Prisoner> GetAllDetainedPrisoners(DateTime from, DateTime to);
        /// <summary>
        /// Get all Prisoners Released (Reporting)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerable<Prisoner> GetAllReleasedPrisoners(DateTime from, DateTime to);
        /// <summary>
        /// Update Prisoner Record
        /// </summary>
        /// <param name="prisoner"></param>
        /// <returns></returns>
        bool UpdatePrisoner(Prisoner prisoner);
        /// <summary>
        /// Delete Prisoner Record
        /// </summary>
        /// <param name="prisoner"></param>
        void DeletePrisoner(Prisoner prisoner);

        IEnumerable<Prisoner> LoadAllPrisoners();

    }
}
