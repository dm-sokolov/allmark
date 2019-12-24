using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils.NationalCatalog.Models
{
    public class CatalogProduct
    {
        [JsonProperty("identified_by")]
        public ICollection<CatalogBarcode> Barcodes { get; set; } = new List<CatalogBarcode>();

        [JsonProperty("good_id")]
        public int GoodId { get; set; }

        [JsonProperty("good_name")]
        public string GoodName { get; set; }

        [JsonProperty("good_img")]
        public string GoodImage { get; set; }

        //TODO categories

        [JsonProperty("party_brand_id")]
        public int? PartyBrandId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        //TODO good_images

        //TODO good_attrs 

        //TODO good_reviews 

        [JsonProperty("good_reviews_count")]
        public int GoodReviewCount { get; set; }

        [JsonProperty("good_url")]
        public string GoodUrl { get; set; }

        //TODO good_prices 
    }
}
