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
                return Ok(await _inserirPagamentoHandle.PostAsync(req));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }
    }
}
