namespace Pagamentos.Aplicacao.Request
{
    public class PagamentoRequest
    {
        public decimal Valor { get; set; }
        public string DataEntrega { get; set; }
        public string DataVencimento { get; set; }
        public int NumeroParcela { get; set; }
        public int QtdParcela { get; set; }
        public string NotaFiscal { get; set; }
        public int FornecedorId{ get; set; }
    }
}
