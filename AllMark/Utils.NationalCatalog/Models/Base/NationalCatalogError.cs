using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogError
    {
        [JsonProperty("goodId")]
        public int? GoodId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("gtin")]
        public string GTIN { get; set; }
    }
}
