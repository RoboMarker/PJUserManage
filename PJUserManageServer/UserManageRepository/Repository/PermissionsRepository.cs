using Dapper;
using Generally;
using Microsoft.Extensions.Configuration;
using System.Data;
using UserManageRepository.Context;
using UserManageRepository.Models.Data;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class PermissionsRepository: IPermissionsRepository
    {
        private readonly IDbConnection _conn;
        private readonly IConfiguration _config;
        MsDBConn2 _DBconn = null;
        private readonly dbCustomDbSampleContext _dbContext;
        public PermissionsRepository(IDbConnection conn, IConfiguration config, dbCustomDbSampleContext dbContext)
        {
            this._conn = conn;
            _config = config;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PermissionVM>> GetAllMenu()
        {
            _DBconn = new MsDBConn2(_config);
            var sqlCmd = @" select * from [Permissions] ";
            var result = await _DBconn.QueryData<PermissionVM>(sqlCmd);
            return result;

        }

        public async Task<Permission> Add(Permission pi)
        {
           var result= await _dbContext.AddAsync(pi);
            await _dbContext.SaveChangesAsync(); // 将更改保存到数据库
            return result.Entity; // 返回实体

        }
        public async Task<int> Update(int MenuPermissionsId, MenuPermission mp)
        {
            _DBconn = new MsDBConn2(_config);
            var parmerter = new DynamicParameters();
            var sqlCmd = @" Update  MenuPermissions ";
            // var result = await _DBconn.ExecuteData2<MenuPermission>(sqlCmd, mp);
            var result = 1;
            return result;

        }
        public async Task<int> Delete(int MenuPermissionsId)
        {
            _DBconn = new MsDBConn2(_config);
            var parmerter = new DynamicParameters();
            var sqlCmd = @" Delete  MenuPermissions ";
            // var result = await _DBconn.ExecuteData2<MenuPermission>(sqlCmd, mp);
            var result = 1;
            return result;

        }
    }
}
