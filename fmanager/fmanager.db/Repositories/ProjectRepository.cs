using System;
using System.Collections.Generic;
using System.Data;

namespace fmanager.db.Repositories
{
    using Entitties;

    /// <summary>
    ///  Project entity repository
    /// </summary>
    public class ProjectRepository : IRepository<ProjectEntity>
    {
        /// <summary>
        /// Construstor taking dbonnection entity
        /// </summary>
        /// <param name="dbconn">Databse connection</param>
        public ProjectRepository(IDbConnection dbconn)
        {

        }

        public void Add(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public ProjectEntity Load(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectEntity> LoadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
