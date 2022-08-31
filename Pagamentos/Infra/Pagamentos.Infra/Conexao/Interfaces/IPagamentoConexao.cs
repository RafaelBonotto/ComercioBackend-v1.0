using MySqlConnector;

namespace Pagamentos.Infra.Conexao.Interfaces
{
    public interface IPagamentoConexao
    {
        Task<MySqlConnection> GetConnectionAsync(); 
    }
}
