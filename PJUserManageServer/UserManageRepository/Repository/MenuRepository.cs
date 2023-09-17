using Dapper;
using Generally;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlTypes;
using UserManageRepository.Context;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class MenuRepository:IMenuRepository
    {
        private readonly IDbConnection _conn;
        private readonly IConfiguration _config;
        MsDBConn2 _DBconn = null;
        private readonly dbCustomDbSampleContext _dbContext;
        public MenuRepository(IDbConnection conn, IConfiguration config, dbCustomDbSampleContext dbContext)
        {
            this._conn = conn;
            _config = config;
            _dbContext = dbContext;
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

        public async Task<Models.Data.Menu> GetMenu_for_MenuName(string sMenuName)
        {
            _DBconn = new MsDBConn2(_config);
            var paramters = new DynamicParameters();
            paramters.Add("MenuName", sMenuName);
            var sqlCmd = @" 
            select *
            from Menu
            where MenuName=@MenuName
            ";
            var result = _DBconn.QueryData<Models.Data.Menu, DynamicParameters>(sqlCmd, paramters).Result.FirstOrDefault();
            return result;
        }

        public async Task<IEnumerable<MenuVM>> GetAllMenu()
        {
            _DBconn = new MsDBConn2(_config);
            var sqlCmd = @" select * from Menu ";
            var result = await _DBconn.QueryData<MenuVM>(sqlCmd);
            return  result;

        }

    }
}
