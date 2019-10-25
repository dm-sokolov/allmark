using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogXmlResult
    {
        /// <summary>
        /// goodId — ID товара для которого передается XML
        /// </summary>
        [JsonProperty("goodId")]
        public int GoodId { get; set; }

        [JsonProperty("xml")]
        public string Xml { get; set; }
    }
}
