using System;
using System.Collections.Generic;
using System.Text;
using AllMark.Core.Models.Base;

namespace AllMark.Core.Models
{
    public class Product: BaseModel
    {
        public virtual int GoodId { get; set; }
        public virtual int GTIN { get; set; }
        public virtual string GoodName { get; set; }
        public virtual int TNVED { get; set; }
        public virtual int BrandId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
