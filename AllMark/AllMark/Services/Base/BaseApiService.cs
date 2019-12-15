using System.Net;
using System.Threading.Tasks;
using AllMark.Config;
using AllMark.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AllMark.Services.Base
{
    public abstract class BaseApiService
    {
        protected readonly string _apiKey;
        protected readonly IRestClient _client;

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

        protected async Task<BaseApiResponse<T>> ExecuteRequestAsync<T>(RestRequest request)
        {
            var response = await _client.ExecuteTaskAsync(request);
            var httpResponse = new BaseApiResponse<T>
            {
                IsSuccess = response.IsSuccessful,
                Status = response.StatusCode,
                Content = response.IsSuccessful ? JsonConvert.DeserializeObject<T>(response.Content) : default,
                Message = ProcessResponseError(response.StatusCode)
            };
            return httpResponse;
        }

        protected abstract string ProcessResponseError(HttpStatusCode statusCode);

        protected string GetResponseStatusDescription(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return "Сервер не смог понять запрос из-за недействительного синтаксиса";
                case HttpStatusCode.Forbidden:
                    return "У клиента нет прав доступа к содержимому";
                case HttpStatusCode.NotFound:
                    return "Сервер не может найти запрашиваемый ресурс";
                case HttpStatusCode.ServiceUnavailable:
                    return "Сервер не доступен";
                case HttpStatusCode.Unauthorized:
                    return "Не удалось авторизоваться";
                default:
                    return "Неизвестная ошибка";
            }
        }
    }
}
