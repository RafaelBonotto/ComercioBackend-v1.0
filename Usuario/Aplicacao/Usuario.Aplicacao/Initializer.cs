using Comum.Aplicacao.Services;
using Comum.Aplicacao.Services.Interfaces;
using Comum.Infra.ConnectionManager;
using Comum.Infra.ConnectionManager.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Aplicacao.Handles;
using Usuario.Aplicacao.Handles.Interfaces;
using Usuario.Infra.Conexao;
using Usuario.Infra.Conexao.Interfaces;
using Usuario.Infra.Repositorios;
using Usuario.Infra.Repositorios.Interfaces;

namespace Usuario.Aplicacao
{
    public static class Initializer
    {
        public static void ConfigureIoc(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioHandle, UsuarioHandle>();   
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioConexao, UsuarioConexao>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IConnectionManager, ConnectionManager>();
        }
    }
}
