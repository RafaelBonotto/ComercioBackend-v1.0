using System.ComponentModel.DataAnnotations;

namespace Usuario.Api.ViewModel
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
    }
}
