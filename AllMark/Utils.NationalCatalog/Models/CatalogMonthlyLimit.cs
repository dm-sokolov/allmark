using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogMonthlyLimit
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("usage")]
        public int Usage { get; set; }
    }
}