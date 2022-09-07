using Comum.Dominio.Enums;

namespace Comum.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Login{ get; set; }
        public List<Permissao> Permissao { get; set; } = new();
    }
}
