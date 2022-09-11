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

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Post([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErros());

            var usuario = new Comum.Dominio.Entidades.Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            };

            var response = await _handle.CadastrarUsuario(usuario);
            return Ok(response);

            //try
            //{

            //}
            //catch (DbUpdateException)
            //{
            //    return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
            //}
            //catch
            //{
            //    return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            //}
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErros());

            var token = await _handle.Login(model.Email, model.Senha);

            if (token is null)
                return StatusCode(401, "Usuário ou senha inválidos");

            return Ok(token);
        }
    }
}
