using System.ComponentModel;

namespace AllMark.DTO
{
    public class ProductDto: BaseDto
    {
        [DisplayName("Id")]
        public int GoodId { get; set; }
        
        [DisplayName("Штрих-код/GTIN")]
        public int GTIN { get; set; }

        [DisplayName("Наименование товара")]
        public string GoodName { get; set; }
        
        [DisplayName("ТН ВЭД")]
        public int TNVED { get; set; }
        
        [DisplayName("Бренд")]
        public int BrandId { get; set; }
        
        [DisplayName ("Категория")]
        public int CategoryId { get; set; }
    }
}
