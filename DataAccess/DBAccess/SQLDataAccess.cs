using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DBAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _configuration;
        public SQLDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
            U parameters, string connectionId = "Default")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure,
            T parameters, string connectionId = "Default")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            await dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
