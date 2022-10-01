using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Infra.Repositorios.Interfaces;

namespace Pagamentos.Aplicacao.Handles
{
    public class ObterPagamentoHandle : IObterPagamentoHandle
    {
        private IPagamentoRepositorio _repositorio;

        public ObterPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
