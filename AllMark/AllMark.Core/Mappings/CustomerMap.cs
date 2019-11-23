using AllMark.Core.Models;
using FluentNHibernate.Mapping;

namespace AllMark.Core.Mappings
{
    public class CustomerMap: ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("customer");
            Id(i => i.Id, "id")
                .GeneratedBy.Native();
            Map(i => i.Name, "name");
            Map(i => i.Email, "email");
            Map(i => i.Password, "password");
            Map(i => i.EmailConfirmed, "email_confirmed");
            Map(i => i.GUID, "guid");
            Map(i => i.NationalCatalogKey, "national_catalog_apikey");
        }
    }
}
