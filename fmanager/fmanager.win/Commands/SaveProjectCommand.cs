using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fmanager.win.Commands
{
    using db.Repositories;
    using db.Entitties; 

    public class SaveProjectCommand : ICommand
    {
        private IRepository<ProjectEntity> _Repo; 

        public event EventHandler CanExecuteChanged;

        //public SaveProjectCommand(IRepository<ProjectEntity> repo)
        //{
        //    _Repo = repo;
        //}

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
