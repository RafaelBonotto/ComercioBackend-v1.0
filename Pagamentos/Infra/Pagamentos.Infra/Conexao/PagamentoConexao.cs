using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Pagamentos.Infra.Conexao.Interfaces;

namespace Pagamentos.Infra.Conexao
{
    public class PagamentoConexao : IPagamentoConexao
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public PagamentoConexao(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Comerciodb");
        }

        public async Task<MySqlConnection> GetConnectionAsync()
        {
            MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
