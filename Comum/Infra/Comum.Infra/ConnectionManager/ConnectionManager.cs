using Comum.Infra.ConnectionManager.Interfaces;
using MySqlConnector;

namespace Comum.Infra.ConnectionManager
{
    public class ConnectionManager : IConnectionManager
    {
        public async Task<MySqlConnection> GetConnectionAsync(string connectionString)
        {
            MySqlConnection connection = new(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
