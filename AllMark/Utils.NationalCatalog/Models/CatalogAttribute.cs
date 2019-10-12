using Newtonsoft.Json;
using System.Collections.Generic;

namespace Utils.NationalCatalog.Models
{
    public class CatalogAttribute
    {
        [JsonProperty("attr_id")]
        public int Id { get; set; }

        [JsonProperty("attr_name")]
        public string Name { get; set; }

        [JsonProperty("attr_group_name")]
        public string GroupName { get; set; }

        [JsonProperty("attr_group_id")]
        public int GroupId { get; set; }

        [JsonProperty("attr_value_type")]
        public ICollection<string> ValueTypes { get; set; } = new List<string>();

        [JsonProperty("attr_field_type")]
        public string FieldType { get; set; }

        [JsonProperty("attr_preset")]
        public ICollection<string> Preset { get; set; } 

        [JsonProperty("attr_type")]
        public string Type { get; set; }            
    }
}
