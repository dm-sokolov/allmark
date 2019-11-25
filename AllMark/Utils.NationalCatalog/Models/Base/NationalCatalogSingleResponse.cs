using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogSingleResponse<T>
    {
        [JsonProperty("apiversion")]
        public int ApiVersion { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
