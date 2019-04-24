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
        Task<int> Add(T entity);
        Task<long> Add(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Load(int id);
        Task<IEnumerable<T>> LoadAll();
    }
}
