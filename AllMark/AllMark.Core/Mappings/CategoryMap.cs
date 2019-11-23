using System;
using System.Collections.Generic;
using System.Text;
using AllMark.Core.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Core.Mappings
{
    public class CategoryMap: ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("category");
            Id(i => i.Id).GeneratedBy.Native();
            Map(i => i.CategoryId, "cat_id").Not.Nullable();
            References(i => i.Product, "product_id").Cascade.None().Not.Nullable();
        }
    }
}
