using Newtonsoft.Json;
using System.Collections.Generic;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogResponse<T>
    {
        [JsonProperty("apiversion")]
        public int ApiVersion { get; set; }

        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<T> Items { get; set; } = new List<T>();
    }
}
