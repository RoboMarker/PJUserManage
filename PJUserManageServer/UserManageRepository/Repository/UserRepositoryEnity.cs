using Microsoft.EntityFrameworkCore;
using UserManageRepository.Context;
using UserManageRepository.Interface;
using UserManageRepository.Models.Data;

namespace UserManageRepository.Repository
{
    public class UserRepositoryEnity: IUserRepositoryEnity
    {
        private readonly dbCustomDbSampleContext _dbCustomDbSampleContext;
        public UserRepositoryEnity(dbCustomDbSampleContext context) {
            _dbCustomDbSampleContext = context;
        }

        public async Task<IList<User>> GetUser()
        {
            return await _dbCustomDbSampleContext.Users.ToListAsync();

        }
    }
}
