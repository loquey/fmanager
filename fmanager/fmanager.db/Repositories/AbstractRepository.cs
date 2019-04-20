using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Contrib;
using System.Data; 

namespace fmanager.db.Repositories
{
    using Repositories;
    using Entitties; 

    public class AbstractRepository<T>  : IRepository<T> where T : BaseEntity
    {
        protected IDbConnection _dbconn;

        /// <summary>
        /// Constructor accepting database connection
        /// </summary>
        /// <param name="dbconn">Database connection</param>
        public AbstractRepository(IDbConnection dbconn)
        {
            _dbconn = dbconn;
        }

        /// <summary>
        /// Add new ProjectLinkEntity to database
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Number of entity added</returns>
        async virtual public Task<int> Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return await _dbconn.InsertAsync<T>(entity);
        }

        async public Task<long> Add(IEnumerable<T> entities)
        {
            return await _dbconn.InsertAsync<IEnumerable<T>>(entities);
        }


        /// <summary>
        /// Delete and Entity from the database 
        /// </summary>
        /// <param name="entity">Entity to be removed </param>
        /// <returns>Status of the delete operation</returns>
        virtual public async Task<bool> Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return await _dbconn.DeleteAsync<T>(entity);
        }


        /// <summary>
        /// Load and entity using key
        /// </summary>
        /// <param name="guid">Entity key to be loaded </param>
        /// <returns>Null or ProjectLinkEntity instance</returns>
        virtual public async Task<T> Load(Guid guid)
        {
            return await _dbconn.GetAsync<T>(guid);
        }

        /// <summary>
        /// Load all existing entities
        /// </summary>
        /// <returns>Populated or empty list</returns>
        virtual public async Task<IEnumerable<T>> LoadAll()
        {
            return await _dbconn.GetAllAsync<T>();
        }

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity">Updated entity</param>
        /// <returns>Status of the update</returns>
        virtual public async Task<bool> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return await _dbconn.UpdateAsync<T>(entity);
        }
        
    }
}
