using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.NationalCatalog.Models
{
    public class CatalogCategory
    {
        /// <summary>
        /// идентификатор категории
        /// </summary>
        [JsonProperty("cat_id")]
        public int Id { get; set; }

        /// <summary>
        /// наименование категории
        /// </summary>
        [JsonProperty("cat_name")]
        public string Name { get; set; }

        /// <summary>
        /// идентификатор родительской категории
        /// </summary>
        [JsonProperty("cat_parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// уровень в дереве категорий(1 верхний уровень, 2 подлежащий и так далее)
        /// </summary>
        [JsonProperty("cat_level")]
        public int Level { get; set; }
    }
}
