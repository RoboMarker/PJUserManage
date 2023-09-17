using Microsoft.EntityFrameworkCore;
using UserManageRepository.Context;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class MenuPermissionsRepository : IMenuPermissionsRepository
    {
        private readonly dbCustomDbSampleContext _dbContext;
        public MenuPermissionsRepository(dbCustomDbSampleContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public UserManageRepository.Models.Data.MenuPermission Add(UserManageRepository.Models.Data.MenuPermission mp)
        {

            var result= _dbContext.Add(mp);
             _dbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<Models.Data.MenuPermission> AddAsync(Models.Data.MenuPermission mp)
        {

            var result = await _dbContext.AddAsync(mp);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}
