using System.Data;
using Application.Abstractions.Behaviors.Data;
using Npgsql;

namespace Infrastructure.Data
{
    internal class SqlConnectionFactory : ISqlConnecionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}