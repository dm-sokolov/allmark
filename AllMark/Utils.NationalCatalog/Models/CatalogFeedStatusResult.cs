using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogFeedStatusResult
    {

        [JsonProperty("feed_id")]
        public int FeedId { get; set; }

        [JsonProperty("status_id")]
        public StatusId StatusId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("status_updated_at")]
        public DateTime StatusUpdatedAt { get; set; }

        [JsonProperty("result")]
        public ICollection<string> CatalogResults { get; set; } = new List<string>();

        [JsonProperty("item")] 
        public ICollection<CatalogItem> CatalogItems { get; set; } = new List<CatalogItem>();

        [JsonProperty("totalErrors")]
        public string TotalErrors { get; set; }

        [JsonProperty("commonError")]
        public string CommonError { get; set; }

    }
}
