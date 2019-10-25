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

        /// <summary>
        /// xml — подписанный XML товара
        /// </summary>
        [JsonProperty("xml")]
        public string Xml { get; set; }
    }
}
