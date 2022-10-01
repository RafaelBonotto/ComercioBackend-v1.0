namespace Pagamentos.Infra.Querys
{
    public class PagamentoQuerys
    {
        public const string SELECT_PGTO_BY_DT_VCTO = @"SELECT * 
                                                       FROM comerciodb.tb_pagamento TBPGTO 
                                                       WHERE TBPGTO.dt_vencimento >= @dataVencimentoDe 
                                                       AND TBPGTO.dt_vencimento <= @dataVencimentoAte";
    }
}
