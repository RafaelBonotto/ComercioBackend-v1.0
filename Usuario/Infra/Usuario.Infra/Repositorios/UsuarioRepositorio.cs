using Dapper.Contrib.Extensions;
using Usuario.Infra.Conexao.Interfaces;
using Usuario.Infra.Repositorios.Interfaces;

namespace Usuario.Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IUsuarioConexao _connection;

        public UsuarioRepositorio(IUsuarioConexao connection)
        {
            _connection = connection;
        }

        public async Task<dynamic> InserirUsuario(Comum.Dominio.Entidades.Usuario usuario)
        {
            using var connection = await _connection.GetConnectionAsync();
            var idUsuario = await connection.InsertAsync<Comum.Dominio.Entidades.Usuario>(usuario);
            if (idUsuario <= 0)
                throw new Exception("Não foi possível inserir o usuario");
            return idUsuario;
        }
    }
}
