using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Entitties
{
    /// <summary>
    /// Database entity base class 
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
