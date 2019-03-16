using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Entitties
{
    public class ProjectLinksEntity
    {
        public ProjectEntity Porject { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
    }
}
