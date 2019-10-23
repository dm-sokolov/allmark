using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogBrand
    {
        [JsonProperty("brand_id")]
        public int Id { get; set; }

        [JsonProperty("brand_name")]
        public string Name { get; set; }
    }
}
