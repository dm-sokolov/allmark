using System;
using System.Collections.Generic;
using System.Text;
using AllMark.Core.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Core.Mappings
{
    public class ProductMap: ClassMap<Product>
    {
        public ProductMap()
        {
            Table("product");
            Id(i => i.Id, "id")
                .GeneratedBy.Native();
            Map(i => i.BrandId, "brand_id");
            Map(i => i.GTIN, "gtin");
            Map(i => i.GoodId, "good_id");
            Map(i => i.GoodName, "good_name");
            Map(i => i.TNVED, "tnved");
            References(i => i.Customer)
                .Cascade.None();
            HasMany(i => i.Attributes)
                .KeyColumn("product_id")
                .Cascade.AllDeleteOrphan()
                .BatchSize(30);
            HasMany(i => i.Categories)
                .KeyColumn("product_id")
                .Cascade.AllDeleteOrphan()
                .BatchSize(30);
        }
    }
}
