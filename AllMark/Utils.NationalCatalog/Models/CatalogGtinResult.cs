using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogGtinResult
    {
        [JsonProperty("monthly-limit")]
        public CatalogMonthlyLimit MonthlyLimit { get; set; }

        [JsonProperty("drafts")]
        public ICollection<CatalogDrafts> CatalogDrafts { get; set; } = new List<CatalogDrafts>();
    }
}
