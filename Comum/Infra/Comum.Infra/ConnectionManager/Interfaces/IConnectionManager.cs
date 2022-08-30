using MySqlConnector;

namespace Comum.Infra.ConnectionManager.Interfaces
{
    public interface IConnectionManager
    {
        Task<MySqlConnection> GetConnectionAsync(string connectionString);
    }
}
