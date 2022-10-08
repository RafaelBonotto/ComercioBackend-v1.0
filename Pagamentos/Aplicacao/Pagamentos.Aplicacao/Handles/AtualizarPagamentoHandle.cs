using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using Pagamentos.Dominio.Entidades;
using Pagamentos.Infra.Repositorios.Interfaces;
using System.Globalization;

namespace Pagamentos.Aplicacao.Handles
{
    public class AtualizarPagamentoHandle : IAtualizarPagamentoHandle
    {
        private readonly IPagamentoRepositorio _repositorio;

        public AtualizarPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<bool> UpdateAsync(PagamentoRequest req)
        {
            var pgto = new Pagamento()
            {
                Id = req.Id,
                Ativo = 1,
                Data_alteracao = DateTime.Now,
                Nota_fiscal = req.NotaFiscal,
                Valor = req.Valor,
                Dt_entrega = DateTime.ParseExact(req.DataEntrega, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Num_parcela = req.NumeroParcela,
                Qtd_parcela = req.QtdParcela,
                Fornecedor_id = req.FornecedorId
            };
            return await _repositorio.UpdateAsync(pgto);
        }
    }
}
