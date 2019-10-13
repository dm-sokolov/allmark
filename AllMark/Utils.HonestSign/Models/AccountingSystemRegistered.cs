using Newtonsoft.Json;

namespace Utils.HonestSign.Models
{
    /// <summary>
    /// Зарегистрированная учетная система
    /// </summary>
    public class AccountingSystemRegistered
    {
        /// <summary>
        /// Секретный ключ
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Уникальный идентификатор УС
        /// </summary>
        [JsonProperty("account_system_id")]
        public string AccountingSystemId { get; set; }
    }
}
