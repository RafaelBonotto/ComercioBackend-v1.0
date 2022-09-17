using Dapper.Contrib.Extensions;

namespace Usuario.Dominio.Entidades
{
    [Table("tb_permissao_usuario")]
    public class UsuarioPermissao
    {
        public UsuarioPermissao()
        {
        }

        public UsuarioPermissao(int usuario_id, int permissao_id)
        {
            Usuario_id = usuario_id;
            Permissao_id = permissao_id;
            Ativo = 1;
            Data_criacao = DateTime.Now;
            Data_alteracao = DateTime.Now;
        }

        public int Id { get; set; } 
        public int Permissao_id { get; set; }
        public int Usuario_id { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }
    }
}
