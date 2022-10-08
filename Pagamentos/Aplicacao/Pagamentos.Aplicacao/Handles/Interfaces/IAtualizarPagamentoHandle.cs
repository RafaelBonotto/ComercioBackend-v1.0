using Pagamentos.Aplicacao.Request;

namespace Pagamentos.Aplicacao.Handles.Interfaces
{
    public interface IAtualizarPagamentoHandle
    {
        Task<bool> UpdateAsync(PagamentoRequest req);
    }
}
