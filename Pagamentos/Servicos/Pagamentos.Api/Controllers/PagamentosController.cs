using Comum.Aplicacao.Extensions;
using Comum.Aplicacao.Tools;
using Comum.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;

namespace Pagamentos.Api.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Route("api/v1/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private IInserirPagamentoHandle _inserirPagamentoHandle;
        private IObterPagamentoHandle _obterPagamentoHandle;
        private IExcluirPagamentoHandle _excluirPagamentoHandle;
        private IAtualizarPagamentoHandle _atualizarPagamentoHandle;

        public PagamentosController(
            IInserirPagamentoHandle inserirPagamentoHandle,
            IObterPagamentoHandle obterPagamentoHandle,
            IExcluirPagamentoHandle excluirPagamentoHandle,
            IAtualizarPagamentoHandle atualizarPagamentoHandle)
        {
            _inserirPagamentoHandle = inserirPagamentoHandle;
            _obterPagamentoHandle = obterPagamentoHandle;
            _excluirPagamentoHandle = excluirPagamentoHandle;
            _atualizarPagamentoHandle = atualizarPagamentoHandle;
        }

        [HttpPost("Inserir")]
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

        [HttpPost("Atualizar")]
        public async Task<IActionResult> UpadteAsync([FromBody] PagamentoRequest req)
        {
            EntityBase ret = new();
            if (!ModelState.IsValid)
                return BadRequest(Helper.MensagemConcatenada(ModelState.GetErros()));

            try
            {
                ret.Success = await _atualizarPagamentoHandle.UpdateAsync(req);

                if (!ret.Success)
                {
                    ret.Errors.Add("Não foi possível atualizar o pagamento");
                    return BadRequest(ret);
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

        [HttpGet("desativar/{id}")]
        public async Task<IActionResult> DesativarAsync(int id)
        {
            EntityBase ret = new();

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
