using Comum.Dominio.Enums;

namespace Comum.Infra.Logger.Interfaces
{
    public interface ILogger
    {
        Task<Guid?> Log(string origem, TipoMensagem tipoMensagem, string msg);
    }
}
