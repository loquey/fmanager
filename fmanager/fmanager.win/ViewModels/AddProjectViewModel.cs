using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fmanager.win.ViewModels
{
    using db.Entitties;
    using Commands;

    /// <summary>
    /// View model for Add Project Page
    /// </summary>
    public class AddProjectViewModel
    {
        public SaveProjectCommand SaveCommand { get; private set; }
        public ProjectEntity NewProject { get; set; }

        public AddProjectViewModel()
        {
            NewProject = new ProjectEntity();
            SaveCommand = new SaveProjectCommand();
        }
    }
}
