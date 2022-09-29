using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Handles;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Infra.Repositorios;
using Pagamentos.Infra.Repositorios.Interfaces;

namespace Pagamentos.Aplicacao
{
    public static class Initializer 
    {
        public static void ConfigureIocDI(this IServiceCollection services)
        {
            //Handles
            services.AddScoped<IInserirPagamentoHandle, InserirPagamentoHandle>();
            services.AddScoped<IObterPagamentoHandle, ObterPagamentoHandle>();
            services.AddScoped<IAtualizarPagamentoHandle, AtualizarPagamentoHandle>();
            services.AddScoped<IExcluirPagamentoHandle, ExcluirPagamentoHandle>();

            //Repositorios
            services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
        }
    }
}