using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EPMS.Interfaces.Repository;
using EPMS.Repository.BaseRepository;
using EPMS.Models.DomainModels;
using Microsoft.Practices.Unity;

namespace EPMS.Repository.Repositories
{
    public sealed class CityRepository : BaseRepository<City>, ICityRepository
    {
        #region Constructor

            /// <summary>
            /// Constructor
            /// </summary>
            public CityRepository(IUnityContainer container)
                : base(container)
            {

            }

            /// <summary>
            /// Primary database set
            /// </summary>
            protected override IDbSet<City> DbSet
            {
                get { return db.Cities; }
            }

        #endregion

        public IEnumerable<City> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
