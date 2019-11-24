namespace AllMark.Core.Models
{
    public class Category: BaseModel
    {
        public virtual int CategoryId { get; set; }
        public virtual Product Product { get; set; }
    }
}
