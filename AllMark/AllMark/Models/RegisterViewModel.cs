using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AllMark.Models
{
    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Укажите Email")]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
