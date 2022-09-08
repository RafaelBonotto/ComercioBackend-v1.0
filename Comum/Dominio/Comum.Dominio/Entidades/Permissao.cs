using Dapper.Contrib.Extensions;

namespace Comum.Dominio.Entidades
{
    [Table("tb_permissao")]
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }
    }
}
