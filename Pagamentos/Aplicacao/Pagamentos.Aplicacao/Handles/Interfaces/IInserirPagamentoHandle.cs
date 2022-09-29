using Pagamentos.Dominio.Entidades;

namespace Pagamentos.Aplicacao.Handles.Interfaces
{
    public interface IInserirPagamentoHandle
    {
        Task<int> PostAsync(Pagamento pagamento);
    }
}
