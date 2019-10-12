using RestSharp;

namespace AllMark.Services.Base
{
    public class BaseApiService
    {
        protected readonly string _apiKey;
        protected readonly RestClient _client;

        public BaseApiService(string apiKey, string baseUrl)
        {
            _apiKey = apiKey;
            _client = new RestClient(baseUrl);
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
    }
}
