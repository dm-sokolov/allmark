using System;
using Newtonsoft.Json;
using Utils.NationalCatalog.Enums;

namespace Utils.NationalCatalog.Models
{
    public class CatalogImage
    {
        [JsonProperty("photo_type")]
        public PhotoType Type { get; set; }

        /// <summary>
        /// дата создания фотографии в UTC
        /// </summary>
        [JsonProperty("photo_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// ссылка на med(medium) размер фотографии
        /// </summary>
        [JsonProperty("photo_url")]
        public string Url { get; set; }

        /// <summary>
        /// (опционально) штрихкод или артикул товара, для которого сделана фотография
        /// </summary>
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
    }
}
