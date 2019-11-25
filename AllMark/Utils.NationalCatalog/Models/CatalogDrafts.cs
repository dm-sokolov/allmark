using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogDrafts
    {
        [JsonProperty("gtin")]
        public long Gtin { get; set; }
    }
}