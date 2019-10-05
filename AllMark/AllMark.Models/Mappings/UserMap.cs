using AllMark.Models.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Models.Mappings
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Table("user");
            Id(i => i.Id, "id")
                .GeneratedBy.Native();
            Map(i => i.Name, "name");
        }
    }
}
