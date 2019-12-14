using System.Collections.Generic;

namespace AllMark.Core.Models
{
    public class Product: BaseModel
    {
        public virtual int GoodId { get; set; }
        public virtual long GTIN { get; set; }
        public virtual string GoodName { get; set; }
        public virtual int TNVED { get; set; }
        public virtual int BrandId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>(); //если у товара всего одна категория, то нужен ли нам список?
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
