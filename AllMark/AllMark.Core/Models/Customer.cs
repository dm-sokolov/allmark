using AllMark.Core.Models.Base;
using System.ComponentModel;

namespace AllMark.Core.Models
{
    public class Customer: BaseModel
    {
        [DisplayName("Название")]
        public virtual string Name { get; set; }

        [DisplayName("Адрес электронной почты")]
        public virtual string Email { get; set; }

        [DisplayName("Пароль")]
        public virtual string Password { get; set; }

        [DisplayName("Почта подтверждена")]
        public virtual bool EmailConfirmed { get; set; }

        public virtual string GUID { get; set; }

        [DisplayName("Ключ от \"Национального каталога\"")]
        public virtual string NationalCatalogKey { get; set; }
    }
}
