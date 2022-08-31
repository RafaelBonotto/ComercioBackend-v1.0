using Comum.Infra.ConnectionManager.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Pagamentos.Infra.Conexao.Interfaces;

namespace Pagamentos.Infra.Conexao
{
    public class PagamentoConexao : IPagamentoConexao
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        private readonly IConnectionManager _connection;

        public PagamentoConexao(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Comerciodb");
        }

        public async Task<MySqlConnection> GetConnectionAsync()
        {
            try
            {
                return await _connection.GetConnectionAsync(_connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível realizar a conexão - {ex.Message}");
            }
        }
    }
}
