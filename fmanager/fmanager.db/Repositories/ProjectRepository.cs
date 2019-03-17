using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Repositories
{
    /// <summary>
    /// Project entity repository
    /// </summary>
    public class ProjectRepository : IRepository
    {
        /// <summary>
        /// Construstor taking dbonnection entity
        /// </summary>
        /// <param name="dbconn">Databse connection</param>
        public ProjectRepository(IDbConnection dbconn)
        {

        }
    }
}
