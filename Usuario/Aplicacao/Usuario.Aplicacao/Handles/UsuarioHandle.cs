using Comum.Aplicacao.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using SecureIdentity.Password;
using Usuario.Aplicacao.Handles.Interfaces;
using Usuario.Infra.Repositorios.Interfaces;

namespace Usuario.Aplicacao.Handles
{
    public class UsuarioHandle : IUsuarioHandle
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public UsuarioHandle(
            IUsuarioRepositorio repositorio,
            ITokenService tokenService,
            IConfiguration config)
        {
            _repositorio = repositorio;
            _tokenService = tokenService;
            _config = config;
        }

        public async Task<int> CadastrarUsuario(Comum.Dominio.Entidades.Usuario usuario)
        {
            usuario.Senha_hash = PasswordHasher.Hash(usuario.Senha);
            usuario.Ativo = 1;
            usuario.Data_criacao = DateTime.Now;
            usuario.Data_alteracao = DateTime.Now;
            return await _repositorio.InserirUsuario(usuario);
        }

        public async Task<string> Login(string email, string senha)
        {
            var usuario = await _repositorio.ObterUsuarioPorEmail(email);
            if (usuario is null)
                return null;

            bool senhaValida = PasswordHasher.Verify(usuario.Senha_hash, senha);
            if (senhaValida)
            {
                usuario.Permissao = await _repositorio.ObterPermissao(usuario.Id);
                var jwtKey = _config.GetSection("JwtKey").Value;
                var token = _tokenService.GetToken(usuario, jwtKey);
                return token;
            }
            return null;
        }
    }
}
