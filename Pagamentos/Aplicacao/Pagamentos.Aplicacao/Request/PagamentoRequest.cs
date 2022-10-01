using System.ComponentModel.DataAnnotations;

namespace Pagamentos.Aplicacao.Request
{
    public class PagamentoRequest
    {
        [Required(ErrorMessage ="Valor obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data da entrega obrigatório")]
        public string DataEntrega { get; set; }

        [Required(ErrorMessage = "Data do vencimento obrigatório")]
        public string DataVencimento { get; set; }

        [Required(ErrorMessage = "Número da parcela obrigatório")]
        public int NumeroParcela { get; set; }

        [Required(ErrorMessage = "Quantidade de parcelas obrigatório")]
        public int QtdParcela { get; set; }

        public string? NotaFiscal { get; set; }

        public int? FornecedorId{ get; set; }
    }
}
