using Comum.Dominio.Entidades;
using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Infra.Repositorios.Interfaces;

namespace Pagamentos.Aplicacao.Handles
{
    public class ExcluirPagamentoHandle : IExcluirPagamentoHandle
    {
        private readonly IPagamentoRepositorio _repositorio;

        public ExcluirPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<EntityBase> DesativarPagamentoAsync(int id)
            => await _repositorio.DesativarPagamentoAsync(id);
    }
}
