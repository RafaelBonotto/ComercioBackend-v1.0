using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Handles;
using Microsoft.Extensions.DependencyInjection;

namespace Pagamentos.Aplicacao
{
    public static class Initializer 
    {
        public static void ConfigureIocDI(this IServiceCollection services)
        {
            services.AddScoped<IInserirPagamentoHandle, InserirPagamentoHandle>();
            services.AddScoped<IObterPagamentoHandle, ObterPagamentoHandle>();
            services.AddScoped<IAtualizarPagamentoHandle, AtualizarPagamentoHandle>();
            services.AddScoped<IExcluirPagamentoHandle, ExcluirPagamentoHandle>();
        }
    }
}