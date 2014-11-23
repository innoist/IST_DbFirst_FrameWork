using System;
using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Interfaces.Repository
{
    public interface IPrisonerRepository : IBaseRepository<Prisoner, int>
    {
        //IEnumerable<Prisoner> GetAllPrisoners();

        //Prisoner CheckByCnic(Prisoner data);

        PrisonerResponse GetAllPrisoners(PrisonerSearchRequest prisonerSearchRequest);
        Prisoner FindPrisonerById(int prisonerId);
        IEnumerable<Prisoner> GetAllPrisoners();
        IEnumerable<Prisoner> GetAllDetainedPrisoners(DateTime from, DateTime to);
        IEnumerable<Prisoner> GetAllReleasedPrisoners(DateTime from, DateTime to);
    }
}
