using Pagamentos.Dominio.Entidades;

namespace Pagamentos.Infra.Repositorios.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<int> PostAsync(Pagamento pagamento);
        Task<List<Pagamento>> GetByDataVencimento(DateTime dataVencimentoDe, DateTime dataVencimentoAte);
    }
}
