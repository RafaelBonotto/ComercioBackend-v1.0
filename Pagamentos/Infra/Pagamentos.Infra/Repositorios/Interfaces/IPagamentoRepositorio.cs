using Comum.Dominio.Entidades;
using Pagamentos.Dominio.Entidades;

namespace Pagamentos.Infra.Repositorios.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<int> PostAsync(Pagamento pagamento);
        Task<List<Pagamento>> GetByDataVencimentoAsync(DateTime dataVencimentoDe, DateTime dataVencimentoAte);
        Task<BaseResponse> DesativarPagamentoAsync(int idPagamento);
        Task<bool> UpdateAsync(Pagamento pagamento);
    }
}
