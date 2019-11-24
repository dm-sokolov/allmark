namespace AllMark.Core.Models
{
    public class Customer: BaseModel
    {
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string GUID { get; set; }

        public virtual string NationalCatalogKey { get; set; }
    }
}
