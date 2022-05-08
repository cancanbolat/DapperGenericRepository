using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Data.Interfaces
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection(string connectionString);
    }
}
