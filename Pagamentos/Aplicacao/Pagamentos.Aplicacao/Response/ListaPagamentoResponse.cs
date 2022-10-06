using Comum.Dominio.Entidades;

namespace Pagamentos.Aplicacao.Response
{
    public class ListaPagamentoResponse : EntityBase
    {
        public List<PagamentoResponse> Pagamentos { get; set; } = new();
    }
}
