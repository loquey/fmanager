using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Entitties
{
    public class ProjectEntity
    {
        public enum ProjectTypeEnum
        {
            ios, 
            android,
            other,
        }

        public string ProjectName { get; set; }
        public ProjectTypeEnum ProjectType { get; set; }
        public string  FilePath { get; set; }

    }
}
