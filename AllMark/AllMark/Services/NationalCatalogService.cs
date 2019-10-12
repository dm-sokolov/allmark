using AllMark.Config;
using AllMark.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.NationalCatalog.Models;

namespace AllMark.Services
{
    public class NationalCatalogService: INationalCatalogService
    {
        private readonly string _apiKey;
        private readonly RestClient _client;

        public NationalCatalogService(IOptions<NationalCatalogConfig> nationalCatalogConfig)
        {
            _apiKey = nationalCatalogConfig.Value.ApiKey;
            _client = new RestClient(nationalCatalogConfig.Value.BaseUrl);
        }

        private RestRequest GetRequest(string method, Method requestMethod = Method.POST)
        {
            var request = new RestRequest(method)
            {
                Method = requestMethod
            };
            request.AddQueryParameter("apikey", _apiKey);
            return request;
        }

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
