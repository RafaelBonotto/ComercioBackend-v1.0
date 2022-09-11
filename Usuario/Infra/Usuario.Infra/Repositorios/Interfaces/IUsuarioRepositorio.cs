using Comum.Dominio.Entidades;

namespace Usuario.Infra.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<int> InserirUsuario(Comum.Dominio.Entidades.Usuario usuario);
        Task<Comum.Dominio.Entidades.Usuario> ObterUsuarioPorEmail(string email);
        Task<List<Permissao>> ObterPermissao(int usuarioId);
    }
}
