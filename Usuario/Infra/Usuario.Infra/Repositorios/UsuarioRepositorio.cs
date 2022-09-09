using Dapper;
using Dapper.Contrib.Extensions;
using Usuario.Infra.Conexao.Interfaces;
using Usuario.Infra.Querys;
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
                return -1;

            return idUsuario;
        }

        public async Task<Comum.Dominio.Entidades.Usuario> ObterUsuarioPorEmail(string email)
        {
            using var connection = await _connection.GetConnectionAsync();
            var usuario = await connection.QueryAsync<Comum.Dominio.Entidades.Usuario>(
                    sql: UsuarioQuerys.SELECT_USUARIO_POR_EMAIL,
                    param: new { email });
            if (usuario.Any())
                return usuario.First();

            return null;
        }
    }
}
