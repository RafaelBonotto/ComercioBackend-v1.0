using Comum.Dominio.Entidades;
using Comum.Dominio.Enums;
using Comum.Infra.ConnectionManager.Interfaces;
using Comum.Infra.Logger.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;

namespace Comum.Infra.Logger
{
    public class Logger : ILogger
    {
        private readonly IConnectionManager _connection;
        private readonly IConfiguration _config;
        private string _connectionString;

        public Logger(
            IConnectionManager connection, 
            IConfiguration config)
        {
            _connection = connection;
            _config = config;
            _connectionString = _config.GetConnectionString("Comerciodb");
        }

        public async Task<Guid?> Log(string origem, TipoMensagem tipoMensagem, string msg)
        {
            Log log = new()
            {
                Trace_id = Guid.NewGuid(),
                Origem = origem,
                Tipo_mensagem_id = (int)tipoMensagem,
                Mensagem = msg,
                Dt_mensagem = DateTime.Now
            };
            using var connection = await _connection.GetConnectionAsync(_connectionString);
            var insert = await connection.InsertAsync<Log>(log);
            if (insert <= 0)
                return null;

            return log.Trace_id;
        }
    }
}
