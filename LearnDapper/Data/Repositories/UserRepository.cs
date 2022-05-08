using LearnDapper.Data.Entities;
using LearnDapper.Data.Interfaces;
using LearnDapper.Data.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await DeleteAsync(id);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await FindAllAsync();
        }

        public async Task<bool> InsertUserAsync(User user)
        {
            return await CreateAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await UpdateAsync(user);
        }
    }
}
