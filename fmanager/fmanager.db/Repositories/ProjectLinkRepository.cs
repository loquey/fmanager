using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace fmanager.db.Repositories
{
    using db.Entitties;
    /// <summary>
    /// Project link repository
    /// </summary>
    public class ProjectLinkRepository : AbstractRepository<ProjectLinkEntity>
    {

        /// <summary>
        /// Constructor accepting database connection
        /// </summary>
        /// <param name="dbconn">Database connection</param>
        public ProjectLinkRepository(IDbConnection dbconn)
            :base(dbconn)
        {
        }
    }
}
