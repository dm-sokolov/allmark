using AllMark.Core.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Core.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("category");
            Id(i => i.Id, "id")
                .GeneratedBy.Native();
            Map(i => i.CategoryId, "cat_id")
                .Not.Nullable();
            Map(i => i.Level, "level");
            Map(i => i.Name, "name");
            Map(i => i.ParentId, "parent_id");
        }
    }
}
