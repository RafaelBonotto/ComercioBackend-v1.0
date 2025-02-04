﻿using Comum.Dominio.Entidades;
using Comum.Dominio.Enums;
using MySqlConnector;

namespace Usuario.Infra.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<int> InserirUsuario(Comum.Dominio.Entidades.Usuario usuario);
        Task<Comum.Dominio.Entidades.Usuario> ObterUsuarioPorEmail(string email);
        Task<List<Permissao>> ObterPermissao(int usuarioId);
    }
}
