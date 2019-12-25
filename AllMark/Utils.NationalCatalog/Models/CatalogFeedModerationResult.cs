using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogFeedModerationResult
    {
        [JsonProperty("good_draft_id")]
        public int GoodDraftId { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
