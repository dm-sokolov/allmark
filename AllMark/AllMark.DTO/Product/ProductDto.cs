using System.Collections.Generic;
using System.ComponentModel;

namespace AllMark.DTO
{
    public class ProductDto: BaseDto
    {
        [DisplayName("Id")]
        public int GoodId { get; set; }
        
        [DisplayName("Штрих-код/GTIN")]
        public long GTIN { get; set; }

        [DisplayName("Наименование товара")]
        public string GoodName { get; set; }
        
        [DisplayName("ТН ВЭД")]
        public int TNVED { get; set; }
        
        [DisplayName("Бренд")]
        public int BrandId { get; set; }
        
        public int CategoryId { get; set; }

        [DisplayName ("Категория")]
        public string CategoriesToString { get; set; }

        public ICollection<AttributeDto> Attributes { get; set; } = new List<AttributeDto>();
    }
}
