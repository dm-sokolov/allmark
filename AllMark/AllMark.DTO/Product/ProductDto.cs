namespace AllMark.DTO
{
    public class ProductDto: BaseDto
    {
        public int GoodId { get; set; }
        public int GTIN { get; set; }
        public string GoodName { get; set; }
        public int TNVED { get; set; }
        public int BrandId { get; set; }
    }
}
