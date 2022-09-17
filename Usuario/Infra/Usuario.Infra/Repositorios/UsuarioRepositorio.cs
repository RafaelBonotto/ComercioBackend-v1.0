using Comum.Dominio.Entidades;
using Comum.Dominio.Enums;
using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using Usuario.Dominio.Entidades;
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

        public async Task<int> InserirUsuario(Comum.Dominio.Entidades.Usuario usuario)
        {
            using (var connection = await _connection.GetConnectionAsync())
            {
                var usuarioExiste = await connection.QueryFirstOrDefaultAsync<Comum.Dominio.Entidades.Usuario>(
                        sql: UsuarioQuerys.SELECT_USUARIO_POR_EMAIL,
                        param: new { usuario.Email });
                if (usuarioExiste != null)
                    return -1;

                using (var transaction = connection.BeginTransaction())
                {
                    var idUsuario = await connection.InsertAsync<Comum.Dominio.Entidades.Usuario>(
                        entityToInsert: usuario,
                        transaction: transaction);

                    if (idUsuario <= 0)
                        return -1;

                    var permissaoInsert = await connection.InsertAsync<UsuarioPermissao>(
                            entityToInsert: new UsuarioPermissao(idUsuario, (int)PermissaoEnum.USUARIO),
                            transaction: transaction);

                    if (permissaoInsert <= 0)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao tentar inserir permissão do usuário");
                    }
                    transaction.Commit();
                    return idUsuario;
                }
            }
                
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

        public async Task<List<Permissao>> ObterPermissao(int usuarioId)
        {
            List<Permissao> ret = new();
            using var connection = await _connection.GetConnectionAsync();

            var permissaoId = await connection.QueryAsync<int>(
                    sql: UsuarioQuerys.SELECT_PERMISSAO_ID,
                    param: new { usuario_id = usuarioId });

            if (permissaoId.Any())
                foreach (var id in permissaoId)
                    ret.Add(await connection.GetAsync<Permissao>(id));

            return ret;
        }
    }
}
