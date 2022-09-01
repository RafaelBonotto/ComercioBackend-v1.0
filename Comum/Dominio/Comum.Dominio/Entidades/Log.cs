using Dapper.Contrib.Extensions;

namespace Comum.Dominio.Entidades
{
    [Table("tb_log")]
    public class Log
    {
        public int Id { get; set; }
        public Guid Trace_id { get; set; } 
        public string Origem { get; set; }
        public DateTime Dt_mensagem { get; set; }
        public int Tipo_mensagem_id { get; set; }
        public string Mensagem { get; set; }
    }
}
