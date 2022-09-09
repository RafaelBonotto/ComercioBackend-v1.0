﻿namespace Usuario.Infra.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<dynamic> InserirUsuario(Comum.Dominio.Entidades.Usuario usuario);
        Task<Comum.Dominio.Entidades.Usuario> ObterUsuarioPorEmail(string email);
    }
}
