using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class NationalCatalogSignResponse
    {
        /// <summary>
        /// массив ID товаров, XML для которых прошли валидацию, были сохранены и товар переведен в статус "Опубликован"
        /// </summary>
        [JsonProperty("signed")]
        public IEnumerable<int> Signed { get; set; } = new List<int>();

        /// <summary>
        /// массив объектов, содержащих ID товара и текст ошибки, возникшей при обработке переданных XML
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<NationalCatalogError> Errors { get; set; } = new List<NationalCatalogError>();
    }
}
