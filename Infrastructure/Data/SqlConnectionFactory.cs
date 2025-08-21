using System.Data;
using Microsoft.Data.SqlClient;
using Application.Abstractions.Behaviors.Data;

namespace Infrastructure.Data
{
    internal class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}