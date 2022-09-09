namespace Usuario.Aplicacao.Handles.Interfaces
{
    public interface IUsuarioHandle
    {
        Task<int> CadastrarUsuario(Comum.Dominio.Entidades.Usuario usuario);
        Task<string> Login(string email, string senha);
    }
}
