using MySqlConnector;

namespace Usuario.Infra.Conexao.Interfaces
{
    public interface IUsuarioConexao
    {
        Task<MySqlConnection> GetConnectionAsync();
    }
}
