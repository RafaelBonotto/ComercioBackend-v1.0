using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;

namespace Pagamentos.Aplicacao.Handles.Interfaces
{
    public interface IObterPagamentoHandle
    {
        Task<ListaPagamentoResponse> GetByDataVencimentoAsync(GetByDataVencimentoRequest req);
    }
}
