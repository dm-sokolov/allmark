using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogXmlResponse
    {
        [JsonProperty("xmls")]
        public IEnumerable<NationalCatalogXmlResult> Xmls { get; set; } = new List<NationalCatalogXmlResult>();

        [JsonProperty("errors")]
        public IEnumerable<NationalCatalogError> Errors { get; set; } = new List<NationalCatalogError>();
    }
}
