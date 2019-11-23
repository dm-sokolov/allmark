using System;
using System.Collections.Generic;
using System.Text;
using AllMark.Core.Models.Base;

namespace AllMark.Core.Models
{
    public class Category: BaseModel
    {
        public virtual int CategoryId { get; set; }
        public virtual Product Product { get; set; }
    }
}
