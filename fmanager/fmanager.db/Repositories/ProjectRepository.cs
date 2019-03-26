using System;
using System.Collections.Generic;
using System.Data;

namespace fmanager.db.Repositories
{
    using Entitties;

    /// <summary>
    ///  Project entity repository
    /// </summary>
    public class ProjectRepository : AbstractRepository<ProjectEntity>
    {
        /// <summary>
        /// Construstor taking dbonnection entity
        /// </summary>
        /// <param name="dbconn">Database connection</param>
        public ProjectRepository(IDbConnection dbconn)
            :base(dbconn)
        {

        }
    }
}
