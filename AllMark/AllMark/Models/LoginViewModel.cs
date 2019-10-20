using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AllMark.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Укажите Email")]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
