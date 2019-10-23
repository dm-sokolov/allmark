using Newtonsoft.Json;
using Utils.NationalCatalog.Enums;

namespace Utils.NationalCatalog.Models
{
    public class CatalogBarcode
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public BarcodeType Type { get; set; }

        [JsonProperty("party_id")]
        public int PartyId { get; set; }

        [JsonProperty("multiplier")]
        public int Multiplier { get; set; }

        [JsonProperty("level")]
        public BarcodeLevel Level { get; set; }
    }
}