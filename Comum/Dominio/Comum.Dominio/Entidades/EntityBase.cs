using Dapper.Contrib.Extensions;

namespace Comum.Dominio.Entidades
{
    public class EntityBase
    {
        [Write(false)]
        public bool Success { get; set; } = true;

        [Write(false)]
        public List<string> Errors { get; set; } = new();
    }
}
