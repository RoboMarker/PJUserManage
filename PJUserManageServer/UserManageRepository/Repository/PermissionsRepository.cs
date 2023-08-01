using Dapper;
using Generally;
using Microsoft.Extensions.Configuration;
using System.Data;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class PermissionsRepository: IPermissionsRepository
    {
        private readonly IDbConnection _conn;
        private readonly IConfiguration _config;
        MsDBConn2 _DBconn = null;
        public PermissionsRepository(IDbConnection conn, IConfiguration config)
        {
            this._conn = conn;
            _config = config;
        }
        public async Task<IEnumerable<PermissionVM>> GetAllMenu()
        {
            _DBconn = new MsDBConn2(_config);
            var sqlCmd = @" select * from [Permissions] ";
            var result = await _DBconn.QueryData<PermissionVM>(sqlCmd);
            return result;

        }

        public async Task<int> Add(PermissionInpurt pi)
        {
            MsDBConn_Dapper _DBconn = new MsDBConn_Dapper(_config);
            var parmerter = new DynamicParameters();
            var result = 0;
            return result;

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
