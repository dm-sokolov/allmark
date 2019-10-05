using AllMark.Models.Models.Base;

namespace AllMark.Models.Models
{
    public class User: BaseModel
    {
        public virtual string Name { get; set; }
    }
}
