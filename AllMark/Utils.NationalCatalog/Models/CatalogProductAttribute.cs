using System;
using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using Utils.NationalCatalog.Enums;

namespace Utils.NationalCatalog.Models
{
    public class CatalogProductAttribute
    {
        /// <summary>
        /// идентификатор атрибута
        /// </summary>
        [JsonProperty("attr_id")]
        public int Id { get; set; }

        /// <summary>
        /// наименование атрибута
        /// </summary>
        [JsonProperty("attr_name")]
        public string Name { get; set; }

        /// <summary>
        /// идентификатор значения атрибута(только для атрибутов 2502, 2503)
        /// </summary>
        [JsonProperty("attr_value_id")]
        public int? AttrValueId { get; set; }

        /// <summary>
        /// значение атрибута
        /// </summary>
        [JsonProperty("attr_value")]
        public string Value { get; set; }

        /// <summary>
        /// идентификатор значения атрибута
        /// </summary>
        [JsonProperty("value_id")]
        public int ValueId { get; set; }

        /// <summary>
        /// тип значения атрибута
        /// </summary>
        [JsonProperty("attr_value_type")]
        public string ValueType { get; set; }

        /// <summary>
        /// идентификатор группы атрибутов
        /// </summary>
        [JsonProperty("attr_group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// наименование группы атрибутов
        /// </summary>
        [JsonProperty("attr_group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// дата измерения атрибута(UTC), (опционально)
        /// </summary>
        [JsonProperty("measure_date")]
        public DateTime? MeasureDate { get; set; }

        /// <summary>
        /// дата публикации атрибута(UTC), (опционально)
        /// </summary>
        [JsonProperty("published_date")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// дата с которой действительно значение атрибута(UTC), (опционально)
        /// </summary>
        [JsonProperty("effective_date")]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// дата с которой недействительно значение атрибута(UTC), (опционально)
        /// </summary>
        [JsonProperty("expired_date")]
        public DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// идентификатор локации, в которой было проведено измерение(опционально)
        /// </summary>
        [JsonProperty("location_id")]
        public int? LocationId { get; set; }

        /// <summary>
        /// внутренний идентификатор локации для компании, в которой было проведено измерение(опционально, отображается только компании, которой принадлежит локация)
        /// </summary>
        [JsonProperty("party_location_id")]
        public int? PartyLocationId { get; set; }

        /// <summary>
        /// уровень упаковки(опционально)
        /// </summary>
        [JsonProperty("level")]
        public BarcodeLevel Level { get; set; }

        /// <summary>
        /// штрих-код(опционально)
        /// </summary>
        [JsonProperty("gtin")]
        public long? GTIN { get; set; }

        /// <summary>
        /// мультипликатор(опционально)
        /// </summary>
        [JsonProperty("multiplier")]
        public float Multiplier { get; set; }

        /// <summary>
        /// номер сертификата
        /// </summary>
        [JsonProperty("certificate_number")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// дата начала срока действия
        /// </summary>
        [JsonProperty("certificate_issued_date")]
        public DateTime? CertificateIssuedDate { get; set; }

        /// <summary>
        /// дата окончания срока действия
        /// </summary>
        [JsonProperty("certificate_valid_until_date")]
        public DateTime? CertificateValidUntilDate { get; set; }

        /// <summary>
        /// заявитель
        /// </summary>
        [JsonProperty("certificate_applicant")]
        public string CertificateApplicant { get; set; }

        /// <summary>
        /// изготовитель
        /// </summary>
        [JsonProperty("certificate_manufacturer")]
        public string CertificateManufacturer { get; set; }

        /// <summary>
        /// продукция
        /// </summary>
        [JsonProperty("certificate_product_description")]
        public string CertificateProductDescription { get; set; }
    }
}
