using Comum.Dominio.Entidades;

namespace Pagamentos.Aplicacao.Handles.Interfaces
{
    public interface IExcluirPagamentoHandle
    {
        Task<BaseResponse> DesativarPagamentoAsync(int id);
    }
}
