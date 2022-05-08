using Dapper.Contrib.Extensions;
using LearnDapper.Data.Interfaces;
using LearnDapper.Data.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseSettings databaseSettings;
        protected IDbConnection dbConnection { get; private set; }

        public Repository(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            dbConnection.Open();

            try
            {
                var inserted = await dbConnection.InsertAsync<TEntity>(entity);
                return inserted == 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            dbConnection.Open();

            try
            {
                var entity = await dbConnection.GetAsync<TEntity>(id);

                if (entity == null)
                    return false;

                return await dbConnection.DeleteAsync<TEntity>(entity);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            dbConnection.Open();

            try
            {
                var results = await dbConnection.GetAllAsync<TEntity>();
                return results.AsQueryable();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            dbConnection.Open();

            try
            {
                return await dbConnection.GetAsync<TEntity>(id);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            dbConnection.Open();

            try
            {
                return await dbConnection.UpdateAsync<TEntity>(entity);
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
