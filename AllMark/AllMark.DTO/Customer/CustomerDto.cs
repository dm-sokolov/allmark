using System.ComponentModel;

namespace AllMark.DTO
{
    public class CustomerDto: BaseDto
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Адрес электронной почты")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Почта подтверждена")]
        public bool EmailConfirmed { get; set; }

        public string GUID { get; set; }

        [DisplayName("Ключ от \"Национального каталога\"")]
        public string NationalCatalogKey { get; set; }
    }
}
