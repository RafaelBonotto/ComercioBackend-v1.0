using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Dominio.Entidades;
using Pagamentos.Infra.Repositorios.Interfaces;

namespace Pagamentos.Aplicacao.Handles
{
    public class InserirPagamentoHandle : IInserirPagamentoHandle
    {
        private IPagamentoRepositorio _repositorio;

        public InserirPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> PostAsync(Pagamento pagamento)
            => await _repositorio.PostAsync(pagamento);
    }
}
