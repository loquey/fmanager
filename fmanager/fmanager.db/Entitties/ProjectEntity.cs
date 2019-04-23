using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Entitties
{
    [Table("Projects")]
    public class ProjectEntity : BaseEntity
    {
        /// <summary>
        /// Possible project types
        /// </summary>
       
        public enum ProjectTypeEnum
        {
            ios = 0, 
            android = 1,
            other = 2,
        }

        /// <summary>
        /// Name of the project being setup 
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Type of project being setup 
        /// </summary>
        public ProjectTypeEnum ProjectType { get; set; }

        /// <summary>
        /// Optional file to be attached to the project 
        /// </summary>
        public string  FilePath { get; set; }

        /// <summary>
        /// List of associted links 
        /// </summary>
        [Write(false)]
        public ICollection<ProjectLinkEntity> ProjectLinks { set; get; }


        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectEntity()
        {
            ProjectLinks = new HashSet<ProjectLinkEntity>();
        }


    }
}
