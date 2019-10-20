using AllMark.Config;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace AllMark.Services.Base
{
    public class BaseApiService
    {
        protected readonly string _apiKey;
        protected readonly RestClient _client;

        public BaseApiService(IApiConfig config)
        {
            _apiKey = config.ApiKey;
            _client = new RestClient(config.BaseUrl);
        }
        protected RestRequest GetRequest(string method, Method requestMethod = Method.POST)
        {
            var request = new RestRequest(method)
            {
                Method = requestMethod
            };
            request.AddQueryParameter("apikey", _apiKey);
            return request;
        }

        protected async Task<T> ExecuteRequestAsync<T>(RestRequest request)
        {
            var response = await _client.ExecuteTaskAsync(request);
            var apiResponse = JsonConvert.DeserializeObject<T>(response.Content);
            return apiResponse;
        }
    }
}
