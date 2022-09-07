using Comum.Dominio.Entidades;

namespace Comum.Aplicacao.Services.Interfaces
{
    public interface ITokenService
    {
        string GetToken(Usuario usuario, string jwtKey);
    }
}
