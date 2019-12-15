using AllMark.Core.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Core.Mappings
{
    public class ProductAttributeMap: ClassMap<ProductAttribute>
    {
        public ProductAttributeMap()
        {
            Table("attribute");
            Id(i => i.Id, "id")
                .GeneratedBy.Native();
            Map(i => i.AttributeId, "attr_id")
                .Not.Nullable();
            Map(i => i.AttributeValue, "attr_value")
                .Not.Nullable();
            Map(i => i.ValueType, "value_type");
            References(i => i.Product, "product_id")
                .Cascade.None();
        }
    }
}
