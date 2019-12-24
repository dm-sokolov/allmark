namespace AllMark.DTO
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int CategoryId { get; set; }

        public int Level { get; set; }

        public bool HasChildren { get; set; }
    }
}
