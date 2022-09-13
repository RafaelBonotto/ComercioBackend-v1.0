using Comum.Aplicacao.Extensions;
using Microsoft.AspNetCore.Mvc;
using Usuario.Api.ViewModel;
using Usuario.Aplicacao.Handles.Interfaces;

namespace Usuario.Api.Controllers
{
    [Route("v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioHandle _handle;

        public UsuarioController(IUsuarioHandle handle)
        {
            _handle = handle;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> PostAsync([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErros());

            var usuario = new Comum.Dominio.Entidades.Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            };
            var response = await _handle.CadastrarUsuarioAsync(usuario);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErros());

            var response = await _handle.LoginAsync(model.Email, model.Senha);

            if (response is null)
                return StatusCode(401, "Usuário ou senha inválidos");

            return Ok(response);
        }
    }
}
