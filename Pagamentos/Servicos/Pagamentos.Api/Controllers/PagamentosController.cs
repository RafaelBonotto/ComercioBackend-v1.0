using Comum.Aplicacao.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Aplicacao.Request;
using System.Text;

namespace Pagamentos.Api.Controllers
{
    [Route("api/v1/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
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
                
            return Ok();
        }
    }
}
