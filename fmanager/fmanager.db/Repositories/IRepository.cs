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
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Load(Guid guid);
        Task<IEnumerable<T>> LoadAll();
    }
}
