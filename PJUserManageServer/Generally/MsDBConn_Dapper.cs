using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Generally
{
    public class MsDBConn_Dapper
    {
        private string Connectionstring = "DefaultConnection";
        IDbConnection _conn = null;
        private readonly IConfiguration _config;
        public MsDBConn_Dapper(IConfiguration config)
        {
            _config = config;
        }

        public int Insert<T>(string tableName, T model) where T : class
        {
            var isIenumerable = MyCheckType.IsEnumerableType(typeof(T));

            IEnumerable<PropertyInfo> props;
            if (isIenumerable)
            {
                props = model.GetType().IsArray
                    ? model.GetType().GetElementType().GetProperties().Where(x => !x.CustomAttributes.Any(a => a.AttributeType == typeof(NotMappedAttribute)
                    || a.AttributeType == typeof(DatabaseGeneratedAttribute)))
                    : model.GetType().GetGenericArguments()[0].GetProperties().Where(x => !x.CustomAttributes.Any(a => a.AttributeType == typeof(NotMappedAttribute)
                    || a.AttributeType == typeof(DatabaseGeneratedAttribute)));
            }
            else
            {
                props = model.GetType().GetProperties().Where(x => !x.CustomAttributes.Any(a => a.AttributeType == typeof(NotMappedAttribute)
                || a.AttributeType == typeof(DatabaseGeneratedAttribute)));
            }
            var fields = string.Join(",", props.Select(x => "[" + x.Name + "]"));
            var filedParams = string.Join(",", props.Select(x => "@" + x.Name));

            var sql = $"Insert Into [dbo].[{tableName}]({fields}) values({filedParams}) ";

            return Execute(sql, model);
        }

        public int Update(string tableName, object param, object whereParam = null)
        {
            if (param == null) return 0;

            var props = param.GetType().GetProperties().Where(x => !x.CustomAttributes.Any(a => a.AttributeType == typeof(NotMappedAttribute)
            || a.AttributeType == typeof(DatabaseGeneratedAttribute)));
            var setSql=string.Join(",",props.Select(x=>$"[{x.Name}] = @{x.Name}"));
            var whereSql = GetWhereSql(whereParam);
            var sql = $"Update [dbo].[{tableName}] set {setSql} {whereSql}";

            var allParam = new DynamicParameters();
            props.ToList().ForEach(p => allParam.Add("@" + p.Name, p.GetValue(param)));
            whereParam.GetType().GetProperties().ToList().ForEach(p => allParam.Add("@_" + p.Name, p.GetValue(whereParam)));
            return Execute(sql, allParam);
        }

        private string GetWhereSql(object whereParam)
        {
            if (whereParam == null || whereParam.GetType().GetProperties().Any() == false) return string.Empty;

            var props = whereParam.GetType().GetProperties().Where(x => !x.CustomAttributes.Any(a => a.AttributeType == typeof(NotMappedAttribute)));

            var whereConditionSqls = props.Select(p =>
            {
                var isArrayOrIenumerable = p.PropertyType.IsArray || MyCheckType.IsEnumerableType(p.PropertyType);
                return isArrayOrIenumerable
                ? $"[{p.Name}] in @_{p.Name}"
                : $"[{p.Name}] = @_{p.Name}";


            });
            return " where " + string.Join(" and ", whereConditionSqls);
        }

        public int Execute(string sql, object param = null)
        {
            using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                using (var tran = new TransactionScope())
                {
                    var result = 0;
                    result = _conn.Execute(sql, param);
                    tran.Complete();

                    return result;
                }
            }
        }

    }
}
