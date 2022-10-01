using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;

namespace Pagamentos.Aplicacao.Handles.Interfaces
{
    public interface IInserirPagamentoHandle
    {
        Task<PagamentoResponse> PostAsync(PagamentoRequest pagamento);
    }
}
