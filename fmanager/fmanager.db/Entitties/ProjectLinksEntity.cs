using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Entitties
{
    /// <summary>
    /// Entity definition for links associated with a project
    /// </summary>
    [Table("ProjectLinks")]
    public class ProjectLinkEntity : BaseEntity
    {
        /// <summary>
        /// Parent project 
        /// </summary>
        [Write(false)]
        public ProjectEntity Project { set; get; }

        /// <summary>
        /// Link descritpion to be displayed to the user 
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Link content 
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// Linked project ID
        /// </summary>
        public int ProjectID { set; get; }
    }
}
