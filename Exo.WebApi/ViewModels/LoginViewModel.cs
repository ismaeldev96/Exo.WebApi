using System.ComponentModel.DataAnnotations;

namespace Exo.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informar Email é obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informar Senha é obrigatorio")]
        public string Senha { get; set; }
    }
}
