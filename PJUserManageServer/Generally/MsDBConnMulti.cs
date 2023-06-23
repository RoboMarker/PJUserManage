using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Generally
{
    public class MsDBConnMulti : IDisposable
    {
        private string Connectionstring = "DefaultConnection";
        IDbConnection _conn = null;
        private readonly IConfiguration _config;
        private readonly IDbTransaction _dbTrans;
        public MsDBConnMulti(IConfiguration config)
        {
            _config = config;
            _conn = new SqlConnection(_config.GetConnectionString(Connectionstring));
            if(this._conn.State==ConnectionState.Closed)
            _conn.Open();
            this._dbTrans = this._conn.BeginTransaction();
        }
        public async Task<IEnumerable<T>> QueryData<T>(string sSqlCmd)
        {
            IEnumerable<T> tResult = null;
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    _conn.Open();
                    tResult = await _conn.QueryAsync<T>(sSqlCmd, commandType: CommandType.Text);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return tResult;
        }

        public async Task<IEnumerable<T>> QueryData<T, U>(string sSqlCmd, U parmeters)
        {
            IEnumerable<T> tResult = null;
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    _conn.Open();
                    tResult = await _conn.QueryAsync<T>(sSqlCmd, parmeters, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return tResult;
        }

        public async Task<T> QueryDataOne<T>(string sSqlCmd)
        {
            T tResult = default(T);
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    _conn.Open();
                    tResult = await _conn.QueryFirstOrDefaultAsync<T>(sSqlCmd, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return tResult;
        }


        public int Execute(string sSqlCmd, object param = null)
        {
            using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                using (var tran = new TransactionScope())
                {
                    var result = 0;
                    result = _conn.Execute(sSqlCmd, param);
                    tran.Complete();
                    return result;
                }
            }
        }

        public async Task<int> ExecuteData(string sSqlCmd, dynamic parmeters)
        {
            int iResult = 0;
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {

                    _conn.Open();
                    // iResult = await conn.ExecuteAsync(sSqlCmd, new { parmeters }, commandType: CommandType.Text);
                    iResult = await _conn.ExecuteAsync(sSqlCmd, (object)parmeters, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return iResult;

        }

        public async Task<int> ExecuteData2<U>(string sSqlCmd, U parmeters, IDbConnection conn)
        {
            int iResult = 0;
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    _conn.Open();
                    iResult = await _conn.ExecuteAsync(sSqlCmd, parmeters, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return iResult;

        }

        public async Task<T> ExecuteDataOne<T>(string sSqlCmd, dynamic parmeters)
        {
            T tResult = default(T);
            try
            {
                using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    _conn.Open();
                    tResult = await _conn.QuerySingleAsync<T>(sSqlCmd, (object)parmeters, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return tResult;

        }

        public async Task<IEnumerable<T>> LoadDataSP<T, U>(string storeProcedure, U parmeters)
        {
            using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                return await _conn.QueryAsync<T>(storeProcedure, parmeters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task ExecuteDataSP<T>(string storeProcedure, T parmeters)
        {
            using (_conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                await _conn.ExecuteAsync(storeProcedure, parmeters, commandType: CommandType.StoredProcedure);
            }

        }


        public void Dispose()
        {
            this._conn.Dispose();
        }



    }
}