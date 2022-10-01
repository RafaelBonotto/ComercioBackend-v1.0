﻿using Comum.Dominio.Entidades;

namespace Pagamentos.Aplicacao.Response
{
    public class PagamentoResponse 
    {
        public int PagamentoId { get; set; }
        public decimal Valor { get; set; }
        public int Num_parcela { get; set; }
        public int Qtd_parcela { get; set; }
        public DateTime Dt_vencimento { get; set; }
        public DateTime Dt_entrega { get; set; }
        public int? Fornecedor_id { get; set; }
        public int? Nota_fiscal { get; set; }
    }
}
