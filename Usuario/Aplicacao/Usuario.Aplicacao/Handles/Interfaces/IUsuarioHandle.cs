using Usuario.Aplicacao.Response;

namespace Usuario.Aplicacao.Handles.Interfaces
{
    public interface IUsuarioHandle
    {
        Task<CadastrarUsuarioResponse> CadastrarUsuarioAsync(Comum.Dominio.Entidades.Usuario usuario);
        Task<LoginResponse> LoginAsync(string email, string senha);
    }
}
