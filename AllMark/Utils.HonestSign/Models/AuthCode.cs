using Newtonsoft.Json;

namespace Utils.HonestSign.Models
{
    public class AuthCode
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
