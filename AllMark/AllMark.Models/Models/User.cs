using AllMark.Models.Models.Base;

namespace AllMark.Models.Models
{
    public class User: BaseModel
    {
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }
    }
}
