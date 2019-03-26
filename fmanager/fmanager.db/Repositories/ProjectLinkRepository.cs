using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Repositories
{
    using db.Entitties;
    /// <summary>
    /// Project link repository
    /// </summary>
    public class ProjectLinkRepository : IRepository<ProjectLinkEntity>
    {
        private IDbConnection _dbconn;
       
        /// <summary>
        /// Constructor accepting database connection
        /// </summary>
        /// <param name="dbconn">Database connection</param>
        public ProjectLinkRepository(IDbConnection dbconn)
        {
            _dbconn = dbconn;
        }
}
