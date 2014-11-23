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
    public sealed class CaseTypeRepository : BaseRepository<CaseType>, ICaseTypeRepository
    {
        #region Constructor

            /// <summary>
            /// Constructor
            /// </summary>
            public CaseTypeRepository(IUnityContainer container)
                : base(container)
            {

            }

            /// <summary>
            /// Primary database set
            /// </summary>
            protected override IDbSet<CaseType> DbSet
            {
                get { return db.CaseTypes; }
            }

        #endregion

        #region Private

        /// <summary>
        /// Order by Column Names Dictionary statements
        /// </summary>
        private readonly Dictionary<CaseTypeByColumn, Func<CaseType, object>> caseTypeClause =

            new Dictionary<CaseTypeByColumn, Func<CaseType, object>>
                    {
                        { CaseTypeByColumn.CaseTypeId, c => c.CaseTypeId},
                        { CaseTypeByColumn.CaseTypeName, c => c.CaseTypeName },
                        { CaseTypeByColumn.CaseTypeDescrition, c => c.CaseTypeDescription },
                    };
        #endregion


        public IEnumerable<CaseType> GetAll()
        {
            return DbSet.ToList();
        }

        public CaseTypeResponse GetAllCaseTypes(CaseTypeSearchRequest caseTypeSearchRequest)
        {
            int fromRow = (caseTypeSearchRequest.PageNo - 1) * caseTypeSearchRequest.PageSize;
            int toRow = caseTypeSearchRequest.PageSize;

            Expression<Func<CaseType, bool>> query =
                s => (((caseTypeSearchRequest.Id == 0) || s.CaseTypeId == caseTypeSearchRequest.Id
                    || s.CaseTypeId.Equals(caseTypeSearchRequest.Id)) &&
                    (string.IsNullOrEmpty(caseTypeSearchRequest.CaseTypeName)
                    || (s.CaseTypeName.Contains(caseTypeSearchRequest.CaseTypeName))));

            IEnumerable<CaseType> caseTypes = caseTypeSearchRequest.IsAsc ?
                DbSet
                .Where(query).OrderBy(caseTypeClause[caseTypeSearchRequest.CaseTypeByColumn]).Skip(fromRow).Take(toRow).ToList()
                                           :
                                           DbSet
                                           .Where(query).OrderByDescending(caseTypeClause[caseTypeSearchRequest.CaseTypeByColumn]).Skip(fromRow).Take(toRow).ToList();
            return new CaseTypeResponse { CaseTypes = caseTypes, TotalCount = DbSet.Count(query) };
        }

        public CaseType FindCaseTypeById(int caseTypeId)
        {
            return DbSet.FirstOrDefault(caseType => caseType.CaseTypeId == caseTypeId);
        }
    }
}
