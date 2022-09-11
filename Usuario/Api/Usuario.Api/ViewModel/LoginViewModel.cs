using System.ComponentModel.DataAnnotations;

namespace Usuario.Api.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo email obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha obrigatório")]
        public string Senha { get; set; }
    }
}
