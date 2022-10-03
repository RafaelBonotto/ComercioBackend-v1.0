using Comum.Aplicacao.Extensions;
using Comum.Aplicacao.Tools;
using Comum.Dominio.Entidades;
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
        private IExcluirPagamentoHandle _excluirPagamentoHandle;

        public PagamentosController(
            IInserirPagamentoHandle inserirPagamentoHandle,
            IObterPagamentoHandle obterPagamentoHandle,
            IExcluirPagamentoHandle excluirPagamentoHandle)
        {
            _inserirPagamentoHandle = inserirPagamentoHandle;
            _obterPagamentoHandle = obterPagamentoHandle;
            _excluirPagamentoHandle = excluirPagamentoHandle;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PagamentoRequest req)
        {
            InserirPagamentoResponse ret = new();

            if (!ModelState.IsValid)
                return BadRequest(Helper.MensagemConcatenada(ModelState.GetErros()));

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
                return BadRequest(Helper.MensagemConcatenada(ModelState.GetErros()));

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

        [Route("desativar/{id}")]
        public async Task<IActionResult> DesativarAsync(int id)
        {
            BaseResponse ret = new();

            if (!ModelState.IsValid) 
                return BadRequest(Helper.MensagemConcatenada(ModelState.GetErros()));

            try
            {
                return Ok(await _excluirPagamentoHandle.DesativarPagamentoAsync(id));
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Errors.Add($"Erro ao tentar desativar o pagamento: {ex.Message}");
                return StatusCode(500, ret);
            }
        }
    }
}
