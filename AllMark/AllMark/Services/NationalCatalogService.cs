using AllMark.Config;
using AllMark.Services.Base;
using AllMark.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.NationalCatalog.Models;

namespace AllMark.Services
{
    public class NationalCatalogService: BaseApiService, INationalCatalogService
    {
        public NationalCatalogService(IOptions<NationalCatalogConfig> nationalCatalogConfig)
            : base(nationalCatalogConfig.Value)
        {  }

        public async Task<ICollection<CatalogAttribute>> GetAttributes(int? categoryId, string attributeType = null)
        {
            var request = GetRequest("attributes");
            if (categoryId.HasValue)
                request.AddQueryParameter("cat_id", categoryId.Value.ToString());
            if (!string.IsNullOrEmpty(attributeType))
                request.AddQueryParameter("attr_type", attributeType);
            var response = await _client.ExecuteTaskAsync(request);
            var apiResponse = JsonConvert.DeserializeObject<NationalCatalogResponse<CatalogAttribute>>(response.Content);
            return apiResponse.Items;
        }
    }
}
