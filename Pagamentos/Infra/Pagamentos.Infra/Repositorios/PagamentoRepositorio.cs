using Comum.Infra.ConnectionManager.Interfaces;
using Pagamentos.Dominio.Entidades;
using Pagamentos.Infra.Repositorios.Interfaces;
using Dapper.Contrib;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using Dapper;
using Pagamentos.Infra.Querys;

namespace Pagamentos.Infra.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private IConnectionManager _connection;
        private IConfiguration _config;
        private string _connectionString;

        public PagamentoRepositorio(
            IConnectionManager connection, 
            IConfiguration config)
        {
            _connection = connection;
            _config = config;
            _connectionString = _config.GetConnectionString("Comerciodb");
        }

        public async Task<int> PostAsync(Pagamento pagamento)
        {
            using var connection = await _connection.GetConnectionAsync(_connectionString);
            return await connection.InsertAsync<Pagamento>(pagamento);
        }

        public async Task<List<Pagamento>> GetByDataVencimento(DateTime dataVencimentoDe, DateTime dataVencimentoAte)
        {
            List<Pagamento> ret = new();
            using var connection = await _connection.GetConnectionAsync(_connectionString);
            var pagamentosResponse = await connection.QueryAsync<Pagamento>(
                sql: PagamentoQuerys.SELECT_PGTO_BY_DT_VCTO,
                param: new { dataVencimentoDe, dataVencimentoAte });

            if (pagamentosResponse != null && pagamentosResponse.Any())
                ret = pagamentosResponse.ToList();

            return ret;
        }
    }
}
