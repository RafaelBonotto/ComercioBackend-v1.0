using Comum.Infra.ConnectionManager.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data.Common;
using Usuario.Infra.Conexao.Interfaces;

namespace Usuario.Infra.Conexao
{
    public class UsuarioConexao : IUsuarioConexao
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        private readonly IConnectionManager _connection;

        public UsuarioConexao(IConfiguration config)
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
