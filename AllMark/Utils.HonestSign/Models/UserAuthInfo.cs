using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.HonestSign.Models
{
    /// <summary>
    ///  Данные о пользователе
    /// </summary>
    public class UserAuthInfo
    {
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Секретный ключ
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// Если идентификация идет для резидента, то это поле заполняется идентификатором сертификата,
        /// если для нерезидента, то – email.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Тип аутентификации
        /// SIGNED_CODE - ЭЦП(резиденты)
        /// PASSWORD - пароль(нерезиденты)
        /// </summary>
        [JsonProperty("auth_type")]
        public string AuthType { get; set; }
    }
}
