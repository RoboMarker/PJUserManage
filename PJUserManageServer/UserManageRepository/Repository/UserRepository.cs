using Dapper;
using Generally;
using Microsoft.Extensions.Configuration;
using UserManageRepository.Models;

namespace UserManageRepository.Repository
{
    public class UserRepository
    {
        private readonly string sConnectionStr = "";
        MsDBConn _DBconn = null;
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        //public async Task<User?> Get(int id)
        //{
        //    _DBconn = new MsDBConn(_config);
        //    var sqlCmd = @" ";
        //    var parameter = new { Id = id };
        //    var result = await _DBconn.QueryData<User, dynamic>(sqlCmd, parameter);
        //    return result.FirstOrDefault();
        //}
        //
        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    _DBconn = new MsDBConn(_config);
        //    var sqlCmd = @" select * from ToDoItem ";
        //    var result = await _DBconn.QueryData<User>(sqlCmd);
        //    return result;
        //}
        //
        //public async Task<int> Add(User entity)
        //{
        //    int iResult = 0;
        //    _DBconn = new MsDBConn(_config);
        //    var sqlCmd = @"";
        //    var parameter = new { };
        //    iResult = await _DBconn.ExecuteData(sqlCmd, parameter);
        //    //iResult = await MsDBConn.ExecuteData2<dynamic>(sqlCmd, parameter, _conn);
        //    return iResult;
        //}
        //
        //public async Task<User?> AddRIdentity(User entity)
        //{
        //    _DBconn = new MsDBConn(_config);
        //    return null;
        //}
        //
        //public async Task<IEnumerable<User>> Search(string sTitle, string sDescription)
        //{
        //    _DBconn = new MsDBConn(_config);
        //    string sWhere = "";
        //    var paramters = new DynamicParameters();
        //    if (sTitle != null)
        //    {
        //        sWhere += "  title like @title ";
        //        paramters.Add("title", "%" + sTitle + "%");
        //    }
        //
        //    if (sDescription != null)
        //    {
        //        if (sWhere != "")
        //        {
        //            sWhere += " or ";
        //        }
        //        sWhere += $"  Description like @Description";
        //        paramters.Add("Description", "%" + sDescription + "%");
        //    }
        //    var sqlCmd = @" select * from ToDoItem where  " + sWhere;
        //    var result = await _DBconn.QueryData<User, dynamic>(sqlCmd, paramters);
        //    return result;
        //}
        //
        //public async Task<int> Delete(int id)
        //{
        //    _DBconn = new MsDBConn(_config);
        //    var sqlCmd = @" delete from ToDoItem where id=@id";
        //    //var result = await connection.ExecuteAsync(sqlCmd, new { Id = id });
        //    var result = await _DBconn.ExecuteData(sqlCmd, new { Id = id });
        //    return result;
        //}
        //
        //public async Task<int> Update(User entity)
        //{
        //    _DBconn = new MsDBConn(_config);
        //    var sqlCmd = @"update [ToDoItem]
        //   set title=@title,Description=@Description,Plan_Date=@Plan_Date,Update_Date=@Update_Date,Update_Mid=@Update_Mid,Iscomplete=@Iscomplete where Id=@Id";
        //    var parameter = new { };
        //    //var result = await connection.ExecuteAsync(sql, entity);
        //    var result = await _DBconn.ExecuteData(sqlCmd, parameter);
        //    return result;
        //}
    }
}
