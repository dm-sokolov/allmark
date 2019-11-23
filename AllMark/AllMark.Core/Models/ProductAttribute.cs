using AllMark.Core.Models.Base;

namespace AllMark.Core.Models
{
    public class ProductAttribute: BaseModel
    {
        public virtual int AttributeId { get; set; }
        public virtual string AttributeValue { get; set; }
        public virtual Product Product { get; set; }
    }
}
