using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Utils.NationalCatalog.Models
{
    public class CatalogFeed
    {
        /// <summary>
        /// идентификатор энтри, который лаборатория может задать для более конкретной идентификации ответа (необязательный)
        /// </summary>
        [JsonProperty("@id")]
        public int Id { get; set; }

        /// <summary>
        /// идентификатор товара (обязательный для обновляемых товаров)
        /// </summary>
        [DisplayName("Id товара")]
        [JsonProperty("good_id")]
        public int GoodId { get; set; }

        /// <summary>
        /// идентификатор в Национальном каталоге товаров GTIN (обязательный для нового товара)
        /// </summary>
        [DisplayName("GTIN")]
        [JsonProperty("gtin")]
        public long? GTIN { get; set; }

        /// <summary>
        /// наименование товара (обязательный для нового товара)
        /// </summary>
        [DisplayName("Наименование товара")]
        [JsonProperty("good_name")]
        public string GoodName { get; set; }

        /// <summary>
        /// ТН ВЭД (обязательный для нового товара)
        /// </summary>
        [DisplayName("ТН ВЭД")]
        [JsonProperty("tnved")]
        public string TNVED { get; set; }

        /// <summary>
        /// торговая марка товара (обязательный для нового товара)
        /// </summary>
        [DisplayName("Торговая марка")]
        [JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// признак что товар надо отправлять на модерацию (необязательный)
        /// </summary>
        [DisplayName("Модерация")]
        [JsonProperty("moderation")]
        public bool Moderation { get; set; }

        /// <summary>
        /// массив идентификаторов (необязательный)
        /// </summary>
        [DisplayName("Идентификатор")]
        [JsonProperty("identified_by")]
        public ICollection<CatalogBarcode> Barcodes { get; set; } = new List<CatalogBarcode>();

        /// <summary>
        /// массив идентификаторов категорий
        /// </summary>
        [DisplayName("Категория")]
        [JsonProperty("categories")]
        public ICollection<CatalogCategory> Categories { get; set; } = new List<CatalogCategory>();

        /// <summary>
        /// массив атрибутов (необязательный)
        /// </summary>
        [DisplayName("Атрибуты")]
        [JsonProperty("good_attrs")]
        public ICollection<CatalogProductAttribute> Attributes { get; set; } = new List<CatalogProductAttribute>();

        /// <summary>
        /// массив изображений (необязательный)
        /// </summary>
        [DisplayName("Изображения")]
        [JsonProperty("good_images")]
        public ICollection<CatalogImage> Images { get; set; } = new List<CatalogImage>();
    }
}
