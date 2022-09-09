using Comum.Dominio.Enums;
using Dapper.Contrib.Extensions;

namespace Comum.Dominio.Entidades
{
    [Table("tb_usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha_hash { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }

        [Write(false)]
        public string Senha { get; set; }

        [Write(false)]
        public List<Permissao> Permissao { get; set; } = new();
    }
}
