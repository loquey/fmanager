using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Repositories
{
    public interface IRepository
    {
        void Add();
        void Update();
        void Delete();
        void Load();
        void LoadAll();
    }
}
