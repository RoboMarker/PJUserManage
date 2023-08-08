using Dapper;
using Generally;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlTypes;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class MenuRepository: IMenuRepository
    {
        private readonly IDbConnection _conn;
        private readonly IConfiguration _config;
        MsDBConn2 _DBconn = null;
        public MenuRepository(IDbConnection conn, IConfiguration config)
        {
            this._conn = conn;
            _config = config;
        }


        public async Task<IList<MenuVM>> GetMenu_For_All2(MenuInput input)
        {
           
            IList<MenuVM> IEnumMenuVM_Permissions = await GetMenu_for_Permissions(input);
            IList<MenuVM> IEnumMenuVM_User = await GetMenu_for_User(input);
            var result=IEnumMenuVM_Permissions.Union(IEnumMenuVM_User).ToList();

            return result;
        }

        public async Task<IList<MenuVM>> GetMenu_For_All(MenuInput input)
        {
            _DBconn = new MsDBConn2(_config);
            var paramters = new DynamicParameters();
            paramters.Add("UserId", input.UserId);
            var sqlCmd = @" 
                    SELECT m.[MenuId],m.[MenuName],m.[Status],m.[MenuType] ,m.[PermissionsId] ,m.[CustomizedUserId]
                    from [User] u
                    join MenuPermissions mp on u.PermissionsId=mp.PermissionsId
                    join Menu m on m.MenuID=mp.MenuID
                    where u.UserId=@UserId
                    union
                    SELECT m.[MenuId],m.[MenuName],m.[Status],m.[MenuType] ,m.[PermissionsId] ,m.[CustomizedUserId]
                    from MenuPermissions mc 
                    join Menu m on m.MenuID=mc.MenuID
                    where mc.UserId=@UserId
            ";
            var result = _DBconn.QueryData<MenuVM, DynamicParameters>(sqlCmd, paramters).Result.ToList();
            return result;

        }

        public async Task<IList<MenuVM>> GetMenu_for_Permissions(MenuInput input)
        {
            _DBconn = new MsDBConn2(_config);
            var paramters = new DynamicParameters();
            paramters.Add("UserId", input.UserId);
            var sqlCmd = @" 
                    SELECT m.[MenuId],m.[MenuName],m.[Status],m.[MenuType] ,m.[PermissionsId] ,m.[CustomizedUserId]
                    from [User] u
                    join MenuPermissions mp on u.PermissionsId=mp.PermissionsId
                    join Menu m on m.MenuID=mp.MenuID
                    where u.UserId=@UserId
            ";
            var result =   _DBconn.QueryData<MenuVM, DynamicParameters>(sqlCmd, paramters).Result.ToList();
            return result;

        }

        public async Task<IList<MenuVM>> GetMenu_for_User(MenuInput input)
        {
            _DBconn = new MsDBConn2(_config);
            var paramters = new DynamicParameters();
            paramters.Add("UserId", input.UserId);
            var sqlCmd = @" 
            SELECT m.[MenuId],m.[MenuName],m.[Status],m.[MenuType] ,m.[PermissionsId] ,m.[CustomizedUserId]
            from MenuPermissions mc 
            join Menu m on m.MenuID=mc.MenuID
            where mc.UserId=@UserId
            ";
            var result =  _DBconn.QueryData<MenuVM, DynamicParameters>(sqlCmd, paramters).Result.ToList();
            return result;
        }

        public async Task<Menu> GetMenu_for_MenuName(MenuInput input)
        {
            _DBconn = new MsDBConn2(_config);
            var paramters = new DynamicParameters();
            paramters.Add("MenuName", input.MenuName);
            var sqlCmd = @" 
            select *
            from Menu
            where MenuName=@MenuName
            ";
            var result = _DBconn.QueryData<Menu, DynamicParameters>(sqlCmd, paramters).Result.FirstOrDefault();
            return result;
        }


        public async Task<IEnumerable<MenuVM>> GetAllMenu()
        {
            _DBconn = new MsDBConn2(_config);
            var sqlCmd = @" select * from Menu ";
            var result = await _DBconn.QueryData<MenuVM>(sqlCmd);
            return  result;

        }

        public async Task<int> Add(Menu pi)
        {
            MsDBConn_Dapper _DBconn = new MsDBConn_Dapper(_config);
            var parmerter = new DynamicParameters();

           // var result = await _DBconn.Insert<Menu>(sqlCmd);
            // var result = await _DBconn.ExecuteData2<MenuPermission>(sqlCmd, mp);

            var result = 1;
            return result;

        }

    }
}
