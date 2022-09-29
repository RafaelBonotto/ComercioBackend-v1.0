using Comum.Aplicacao.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using System.Globalization;
using System.Text;

namespace Pagamentos.Api.Controllers
{
    [Route("api/v1/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private IInserirPagamentoHandle _inserirPagamentoHandle;

        public PagamentosController(IInserirPagamentoHandle inserirPagamentoHandle)
        {
            _inserirPagamentoHandle = inserirPagamentoHandle;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PagamentoRequest req)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder msg = new();
                foreach (var erro in ModelState.GetErros())
                    msg.Append(erro.ToString());

                return BadRequest(msg.ToString());
            }
            try
            {
                var pagamento = new Dominio.Entidades.Pagamento
                {
                    Ativo = 1,
                    Data_criacao = DateTime.Now,
                    Data_alteracao = DateTime.Now,
                    Dt_vencimento = DateTime.ParseExact(req.DataVencimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Dt_entrega = DateTime.ParseExact(req.DataEntrega, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Valor = req.Valor,
                    Num_parcela = req.NumeroParcela,
                    Qtd_parcela = req.QtdParcela,
                    Fornecedor_id = req.FornecedorId,
                    NotaFiscal = int.Parse(req.NotaFiscal)
                };
                return Ok(await _inserirPagamentoHandle.PostAsync(pagamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }
    }
}
