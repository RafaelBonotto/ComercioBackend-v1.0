using Dapper.Contrib.Extensions;

namespace Pagamentos.Dominio.Entidades
{
    [Table("tb_pagamento")]
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Dt_entrega { get; set; }
        public DateTime Dt_vencimento { get; set; }
        public int Num_parcela { get; set; }
        public int Qtd_parcela { get; set; }
        public int Nota_fiscal { get; set; }
        public int Fornecedor_id { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }
    }
}
