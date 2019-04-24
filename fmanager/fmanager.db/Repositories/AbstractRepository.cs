using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace fmanager.db.Repositories
{
    using Entitties;

    public class AbstractRepository<T> : IRepository<T> where T : BaseEntity
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
        public virtual async Task<int> Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return await _dbconn.InsertAsync<T>(entity);
        }

        public async Task<long> Add(IEnumerable<T> entities)
        {
            return await _dbconn.InsertAsync<IEnumerable<T>>(entities);
        }


        /// <summary>
        /// Delete and Entity from the database 
        /// </summary>
        /// <param name="entity">Entity to be removed </param>
        /// <returns>Status of the delete operation</returns>
        public virtual async Task<bool> Delete(T entity)
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
        public virtual async Task<T> Load(int id)
        {
            return await _dbconn.GetAsync<T>(id, null, null);
        }

        /// <summary>
        /// Load all existing entities
        /// </summary>
        /// <returns>Populated or empty list</returns>
        public virtual async Task<IEnumerable<T>> LoadAll()
        {
            return await _dbconn.GetAllAsync<T>(null, null);
        }

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity">Updated entity</param>
        /// <returns>Status of the update</returns>
        public virtual async Task<bool> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return await _dbconn.UpdateAsync<T>(entity);
        }

    }
}
