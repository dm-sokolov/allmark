using Newtonsoft.Json;

namespace Utils.HonestSign.Models
{
    /// <summary>
    /// Учетная система
    /// </summary>
    public class AccountingSystem
    {
        /// <summary>
        /// Идентификатор субъекта обращения в ИС "Маркировка товаров"
        /// </summary>
        [JsonProperty("sys_id")]
        public string SysId { get; set; }

        /// <summary>
        /// Название учетной системы
        /// </summary>
        public string Name { get; set; }
    }
}
