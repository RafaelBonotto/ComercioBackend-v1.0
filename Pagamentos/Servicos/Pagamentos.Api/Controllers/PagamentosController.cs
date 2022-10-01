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

        public PagamentosController(IInserirPagamentoHandle inserirPagamentoHandle)
        {
            _inserirPagamentoHandle = inserirPagamentoHandle;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PagamentoRequest req)
        {
            PagamentoResponse ret = new();
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
    }
}
