using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogFeedResult
    {
        [JsonProperty("feed_id")]
        public int FeedId { get; set; }
    }
}
