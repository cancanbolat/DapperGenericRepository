using LearnDapper.Data.Interfaces;
using LearnDapper.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Data
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;

        public DbContext SetStartegy(string providerType)
        {
            _dbStrategy = providerType switch
            {
                "local" => _dbStrategy = new SqlServerStrategy(),
                //"mysql",
                _ => null
            };

            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
        {
            return _dbStrategy.GetConnection(connectionString);
        }
    }
}
