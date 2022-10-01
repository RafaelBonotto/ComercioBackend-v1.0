using Comum.Dominio.Entidades;

namespace Pagamentos.Aplicacao.Response
{
    public class ListaPagamentoResponse : BaseResponse
    {
        public List<PagamentoResponse> Pagamentos { get; set; } = new();
    }
}
