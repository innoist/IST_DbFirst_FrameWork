using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EPMS.Interfaces.Repository;
using EPMS.Models.Common;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;
using EPMS.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace EPMS.Repository.Repositories
{
    public sealed class DetentionAuthorityRepository : BaseRepository<DetentionAuthority>, IDetentionAuthorityRepository
    {
        #region Constructor

            /// <summary>
            /// Constructor
            /// </summary>
        public DetentionAuthorityRepository(IUnityContainer container)
                : base(container)
            {

            }

            /// <summary>
            /// Primary database set
            /// </summary>
            protected override IDbSet<DetentionAuthority> DbSet
            {
                get { return db.DetentionAuthorities; }
            }

        #endregion

            #region Private

            /// <summary>
            /// Order by Column Names Dictionary statements
            /// </summary>
            private readonly Dictionary<DetentionAuthorityByColumn, Func<DetentionAuthority, object>> detentionAuthorityClause =

                new Dictionary<DetentionAuthorityByColumn, Func<DetentionAuthority, object>>
                    {
                        { DetentionAuthorityByColumn.DetentionAuthorityId, c => c.DetentionAuthorityId},
                        { DetentionAuthorityByColumn.DetentionAuthorityName, c => c.DetentionAuthorityName },
                        { DetentionAuthorityByColumn.DetentionAuthorityDescrition, c => c.DetentionAuthorityDescription },
                    };
            #endregion
        
        public IEnumerable<DetentionAuthority> GetAll()
        {
            return DbSet.ToList();
        }

        public DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest)
        {
            int fromRow = (detentionAuthoritySearchRequest.PageNo - 1) * detentionAuthoritySearchRequest.PageSize;
            int toRow = detentionAuthoritySearchRequest.PageSize;

            Expression<Func<DetentionAuthority, bool>> query =
                s => (((detentionAuthoritySearchRequest.Id == 0) || s.DetentionAuthorityId == detentionAuthoritySearchRequest.Id
                    || s.DetentionAuthorityId.Equals(detentionAuthoritySearchRequest.Id)) &&
                    (string.IsNullOrEmpty(detentionAuthoritySearchRequest.DetentionAuthorityName)
                    || (s.DetentionAuthorityName.Contains(detentionAuthoritySearchRequest.DetentionAuthorityName))));

            IEnumerable<DetentionAuthority> detentionAuthorities = detentionAuthoritySearchRequest.IsAsc ?
                DbSet
                .Where(query).OrderBy(detentionAuthorityClause[detentionAuthoritySearchRequest.DetentionAuthorityByColumn]).Skip(fromRow).Take(toRow).ToList()
                                           :
                                           DbSet
                                           .Where(query).OrderByDescending(detentionAuthorityClause[detentionAuthoritySearchRequest.DetentionAuthorityByColumn]).Skip(fromRow).Take(toRow).ToList();
            return new DetentionAuthorityResponse { DetentionAuthorities = detentionAuthorities, TotalCount = DbSet.Count(query) };
        }

        public DetentionAuthority FindDetentionAuthorityById(int detentionAuthorityId)
        {
            return DbSet.FirstOrDefault(detentionAuthority => detentionAuthority.DetentionAuthorityId == detentionAuthorityId);
        }
    }
}
