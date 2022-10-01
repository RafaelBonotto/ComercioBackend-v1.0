using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;
using Pagamentos.Infra.Repositorios.Interfaces;
using System.Globalization;

namespace Pagamentos.Aplicacao.Handles
{
    public class ObterPagamentoHandle : IObterPagamentoHandle
    {
        private IPagamentoRepositorio _repositorio;

        public ObterPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ListaPagamentoResponse> GetByDataVencimentoAsync(GetByDataVencimentoRequest req)
        {
            ListaPagamentoResponse ret = new();
            var dtVctoDe = DateTime.ParseExact(req.DataVencimentoDe, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var dtVctoAte = DateTime.ParseExact(req.DataVencimentoAte, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var pgtos = await _repositorio.GetByDataVencimentoAsync(dtVctoDe, dtVctoAte);
            if (pgtos != null && pgtos.Any())
            {
                foreach (var pgto in pgtos)
                    ret.Pagamentos.Add(new PagamentoResponse
                    {
                        PagamentoId = pgto.Id,
                        Valor = pgto.Valor,
                        Dt_entrega = pgto.Dt_entrega,
                        Dt_vencimento = pgto.Dt_vencimento,
                        Num_parcela = pgto.Num_parcela,
                        Qtd_parcela = pgto.Qtd_parcela,
                        Nota_fiscal = pgto.Nota_fiscal,
                        Fornecedor_id = pgto.Fornecedor_id
                    });
            }
            return ret;
        }
    }
}
