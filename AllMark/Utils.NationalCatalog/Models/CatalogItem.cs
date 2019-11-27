using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Utils.NationalCatalog
{
    public class CatalogItem
    {
        [JsonProperty("gtin")]
        public string Gtin { get; set; }

        [JsonProperty("good_id")]
        public string GoodId { get; set; }

        [JsonProperty("attribute_id")]
        public string AttributeId { get; set; }

        [JsonProperty("attribute_name")]
        public string AttributeName { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}