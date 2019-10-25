using Newtonsoft.Json;
using System.Collections.Generic;

namespace Utils.NationalCatalog.Models
{
    public class CatalogShortProduct
    {
        [JsonProperty("identified_by")]
        public ICollection<CatalogBarcode> Barcodes { get; set; } = new List<CatalogBarcode>();

        [JsonProperty("categories")]
        public ICollection<CatalogCategory> Categories { get; set; } = new List<CatalogCategory>();

        [JsonProperty("good_images")]
        public ICollection<CatalogImage> Images { get; set; } = new List<CatalogImage>();

        [JsonProperty("good_attrs")]
        public ICollection<CatalogProductAttribute> Attributes { get; set; } = new List<CatalogProductAttribute>();
    }
}
