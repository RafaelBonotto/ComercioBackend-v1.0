using Comum.Aplicacao.Extensions;
using Comum.Aplicacao.Tools;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;

namespace Pagamentos.Api.Controllers
{
    [Route("api/v1/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private IInserirPagamentoHandle _inserirPagamentoHandle;
        private IObterPagamentoHandle _obterPagamentoHandle;

        public PagamentosController(
            IInserirPagamentoHandle inserirPagamentoHandle, 
            IObterPagamentoHandle obterPagamentoHandle)
        {
            _inserirPagamentoHandle = inserirPagamentoHandle;
            _obterPagamentoHandle = obterPagamentoHandle;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PagamentoRequest req)
        {
            InserirPagamentoResponse ret = new();
            if (!ModelState.IsValid)
            {
                string errorMsg = Helper.MensagemConcatenada(ModelState.GetErros());
                return BadRequest(errorMsg);
            }
            try
            {
                ret = await _inserirPagamentoHandle.PostAsync(req);
                if(ret.PagamentoId <= 0)
                {
                    ret.Success = false;
                    ret.Errors.Add("Não foi possível inserir o pagamento");
                }
                return Ok(ret);
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Errors.Add($"Não foi possível inserir o pagamento: {ex.Message}");
                return StatusCode(500, ret);
            }
        }

        [HttpGet("dt-vcto-de-ate")]
        public async Task<IActionResult> GetDtVctoDeAteAsync([FromQuery] GetByDataVencimentoRequest req)
        {
            ListaPagamentoResponse ret = new();
            if (!ModelState.IsValid)
            {
                string errorMsg = Helper.MensagemConcatenada(ModelState.GetErros());
                return BadRequest(errorMsg);
            }
            try
            {
                ret = await _obterPagamentoHandle.GetByDataVencimentoAsync(req);
                if (!ret.Pagamentos.Any())
                    return NoContent();

                return Ok(ret);
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Errors.Add($"Erro ao tentar encontrar o pagamento: {ex.Message}");
                return StatusCode(500, ret);
            }
        }
    }
}
