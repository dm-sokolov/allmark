using AllMark.Config;
using AllMark.Services.Base;
using AllMark.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.NationalCatalog.Models;

namespace AllMark.Services
{
    public class NationalCatalogService: BaseApiService, INationalCatalogService
    {
        public NationalCatalogService(IOptions<NationalCatalogConfig> nationalCatalogConfig)
            : base(nationalCatalogConfig.Value)
        {  }

        /// <inheritdoc />
        public async Task<IEnumerable<CatalogAttribute>> GetAttributes(int? categoryId = null, string attributeType = null)
        {
            var request = GetRequest("attributes");
            if (categoryId.HasValue)
                request.AddQueryParameter("cat_id", categoryId.Value.ToString());
            if (!string.IsNullOrEmpty(attributeType))
                request.AddQueryParameter("attr_type", attributeType);
            var apiResponse = await ExecuteRequestAsync<NationalCatalogResponse<CatalogAttribute>>(request);
            return apiResponse.Items;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CatalogBrand>> GetBrands(int? partyId = null)
        {
            var request = GetRequest("brands");
            if (partyId.HasValue)
                request.AddQueryParameter("party_id", partyId.Value.ToString());
            var apiResponse = await ExecuteRequestAsync<NationalCatalogResponse<CatalogBrand>>(request);
            return apiResponse.Items;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CatalogProduct>> GetProducts(int? goodId, long? gtin, int? ltin, int? sku, string product_name, int? catId)
        {
            var request = GetRequest("product");
            if (goodId.HasValue)
                request.AddQueryParameter("good_id", goodId.Value.ToString());
            if (gtin.HasValue)
                request.AddQueryParameter("gtin", gtin.Value.ToString());
            if (ltin.HasValue)
                request.AddQueryParameter("ltin", ltin.Value.ToString());
            if (sku.HasValue)
                request.AddQueryParameter("sku", sku.Value.ToString());
            if (!string.IsNullOrEmpty(product_name))
                request.AddQueryParameter("product_name", product_name);
            if (catId.HasValue)
                request.AddQueryParameter("cat_id", catId.Value.ToString());
            var apiResponse = await ExecuteRequestAsync<NationalCatalogResponse<CatalogProduct>>(request);
            return apiResponse.Items;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CatalogCategory>> GetCategories()
        {
            var request = GetRequest("categories");
            var apiResponse = await ExecuteRequestAsync<NationalCatalogResponse<CatalogCategory>>(request);
            return apiResponse.Items;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CatalogShortProduct>> GetShortProduct(int? goodId, long? gtin, long? ltin, long? sku, string productName, int? categoryId)
        {
            var request = GetRequest("short-product");
            if (goodId.HasValue)
                request.AddQueryParameter("good_id", goodId.Value.ToString());
            if (gtin.HasValue)
                request.AddQueryParameter("gtin", gtin.Value.ToString());
            if (ltin.HasValue)
                request.AddQueryParameter("ltin", ltin.Value.ToString());
            if (sku.HasValue)
                request.AddQueryParameter("sku", sku.Value.ToString());
            if (!string.IsNullOrEmpty(productName))
                request.AddQueryParameter("product_name", productName);
            if (categoryId.HasValue)
                request.AddQueryParameter("cat_id", categoryId.Value.ToString());
            var apiResponse = await ExecuteRequestAsync<NationalCatalogResponse<CatalogShortProduct>>(request);
            return apiResponse.Items;
        }

        /// <inheritdoc />
        public async Task<NationalCatalogXmlResponse> FeedProductDocument(IEnumerable<int> goodIds, IEnumerable<string> gtins)
        {
            var request = GetRequest("feed-product-document");
            if (goodIds != null && goodIds.Any())
                request.AddParameter("goodIds", goodIds);
            if (gtins != null && gtins.Any())
                request.AddParameter("gtins", gtins);
            var apiResponse = await ExecuteRequestAsync<NationalCatalogXmlResponse>(request);
            return apiResponse;
        }

        /// <inheritdoc />
        public async Task<NationalCatalogSignResponse> FeedProductSign(IEnumerable<NationalCatalogXmlResult> xmlResult)
        {
            var request = GetRequest("feed-product-sign");
            request.AddJsonBody(xmlResult);
            var apiResponse = await ExecuteRequestAsync<NationalCatalogSignResponse>(request);
            return apiResponse;
        }
    }
}
