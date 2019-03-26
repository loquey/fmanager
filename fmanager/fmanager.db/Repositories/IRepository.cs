using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmanager.db.Repositories
{
    using db.Entitties;

    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Load(Guid guid);
        IEnumerable<T> LoadAll();
    }
}
