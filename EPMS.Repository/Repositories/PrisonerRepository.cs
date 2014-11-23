using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EPMS.Interfaces.Repository;
using EPMS.Models.Common;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;
using EPMS.Repository.BaseRepository;
using EPMS.Models.DomainModels;
using Microsoft.Practices.Unity;

namespace EPMS.Repository.Repositories
{
    public sealed class PrisonerRepository : BaseRepository<Prisoner>, IPrisonerRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PrisonerRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Prisoner> DbSet
        {
            get { return db.Prisoners; }
        }

        #endregion

        #region Private
        /// <summary>
        /// Order by Column Names Dictionary statements
        /// </summary>
        private readonly Dictionary<PrisonerByColumn, Func<Prisoner, object>> prisonerClause =

            new Dictionary<PrisonerByColumn, Func<Prisoner, object>>
                    {
                        { PrisonerByColumn.PrisonerId, c => c.PrisonerId},
                        { PrisonerByColumn.PrisonerPassport, c => c.PrisonerPassport },
                        { PrisonerByColumn.PrisonerCnic, c => c.PrisonerCnic },
                        { PrisonerByColumn.Iqama, c => c.PrisonerWorkInfo != null ? c.PrisonerWorkInfo.Iqama : string.Empty },
                        { PrisonerByColumn.Name, c => c.PrisonerFirstNameE},
                        { PrisonerByColumn.Address, c => c.PrisonerAddress != null ? c.PrisonerAddress.PostOfficeOrCity : string.Empty },
                        { PrisonerByColumn.CaseType, c => c.PrisonerCaseInfo != null && c.PrisonerCaseInfo.CaseType != null ? c.PrisonerCaseInfo.CaseType.CaseTypeName : string.Empty },
                        { PrisonerByColumn.DetentionLocation, c => c.PrisonerCaseInfo != null && c.PrisonerCaseInfo.DetentionLocation != null ? 
                            c.PrisonerCaseInfo.DetentionLocation.DetentionLocationName : string.Empty },
                        { PrisonerByColumn.PenaltyAmount, c => c.PrisonerCaseInfo != null ? c.PrisonerCaseInfo.Penalty : string.Empty },
                        { PrisonerByColumn.PenaltyStatus, c => c.PrisonerCaseInfo != null ? c.PrisonerCaseInfo.PenaltyStatus : string.Empty },
                        { PrisonerByColumn.ImprisonmentDate, c => c.PrisonerCaseInfo != null ? c.PrisonerCaseInfo.ImprisonmentDate : DateTime.MinValue },
                        { PrisonerByColumn.ReleaseDate, c => c.PrisonerCaseInfo != null ? c.PrisonerCaseInfo.ReleaseDate : DateTime.MinValue },
                    };
        #endregion

        public PrisonerResponse GetAllPrisoners(PrisonerSearchRequest prisonerSearchRequest)
        {
            int fromRow = (prisonerSearchRequest.PageNo - 1) * prisonerSearchRequest.PageSize;
            int toRow = prisonerSearchRequest.PageSize;

            Expression<Func<Prisoner, bool>> query =
                s => (((prisonerSearchRequest.Id == 0) || s.PrisonerId == prisonerSearchRequest.Id || s.PrisonerId.Equals(prisonerSearchRequest.Id)) &&
                    (string.IsNullOrEmpty(prisonerSearchRequest.PrisonerName) || (s.PrisonerFirstNameE.Contains(prisonerSearchRequest.PrisonerName)
                    || s.PrisonerMiddleNameE.Contains(prisonerSearchRequest.PrisonerName) || s.PrisonerLastNameE.Contains(prisonerSearchRequest.PrisonerName))) &&
                    (string.IsNullOrEmpty(prisonerSearchRequest.PrisonerCnic) || s.PrisonerCnic.Contains(prisonerSearchRequest.PrisonerCnic)) &&
                    (string.IsNullOrEmpty(prisonerSearchRequest.PrisonerPassport) || s.PrisonerPassport.Contains(prisonerSearchRequest.PrisonerPassport)) &&
                    (string.IsNullOrEmpty(prisonerSearchRequest.Address) ||
                    (s.PrisonerAddress.Province.Contains(prisonerSearchRequest.Address) ||
                    s.PrisonerAddress.District.Contains(prisonerSearchRequest.Address) ||
                    s.PrisonerAddress.PostOfficeOrCity.Contains(prisonerSearchRequest.Address))) &&
                    (string.IsNullOrEmpty(prisonerSearchRequest.Iqama) || s.PrisonerWorkInfo.Iqama.Contains(prisonerSearchRequest.Iqama)) &&
                    (prisonerSearchRequest.CaseType == null || prisonerSearchRequest.CaseType == 0 || s.PrisonerCaseInfo.CaseTypeId == prisonerSearchRequest.CaseType));

            IEnumerable<Prisoner> prisoners = prisonerSearchRequest.IsAsc ?
                DbSet
                .Include(p => p.PrisonerWorkInfo)
                .Include(p => p.PrisonerCaseInfo)
                .Include(p => p.PrisonerAddress).Where(query).OrderBy(prisonerClause[prisonerSearchRequest.PrisonerByColumn]).Skip(fromRow).Take(toRow).ToList()
                                           :
                                           DbSet
                                           .Include(p => p.PrisonerWorkInfo)
                .Include(p => p.PrisonerCaseInfo)
                .Include(p => p.PrisonerAddress).Where(query).OrderByDescending(prisonerClause[prisonerSearchRequest.PrisonerByColumn]).Skip(fromRow).Take(toRow).ToList();
            return new PrisonerResponse { Prisoners = prisoners, TotalCount = DbSet.Count(query) };
        }
        public IEnumerable<Prisoner> GetAllPrisoners()
        {
            DateTime today = DateTime.Now.Date;
            DateTime month = DateTime.Now.AddDays(30).Date;
            return DbSet.Where(x => (x.PrisonerCaseInfo.ReleaseDate >= today) && (x.PrisonerCaseInfo.ReleaseDate <= month)).ToList();
        }

        public IEnumerable<Prisoner> GetAllDetainedPrisoners(DateTime from, DateTime to)
        {
            return DbSet.Where(x => (x.PrisonerCaseInfo.DetentionDate >= from) && (x.PrisonerCaseInfo.DetentionDate <= to)).ToList();
        }

        public IEnumerable<Prisoner> GetAllReleasedPrisoners(DateTime from, DateTime to)
        {
            return DbSet.Where(x => (x.PrisonerCaseInfo.ReleaseDate >= from) && (x.PrisonerCaseInfo.ReleaseDate <= to)).ToList();
        }

        public Prisoner FindPrisonerById(int prisonerId)
        {
            return DbSet.Include(prisoner => prisoner.PrisonerAddress).Include(prisoner => prisoner.PrisonerWorkInfo).Include(prisoner => prisoner.PrisonerCaseInfo).FirstOrDefault(prisoner => prisoner.PrisonerId == prisonerId);
        }

    }
}
