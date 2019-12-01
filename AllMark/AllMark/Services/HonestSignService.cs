using AllMark.Config;
using AllMark.Services.Base;
using AllMark.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using RestSharp;
using Utils.HonestSign.Models;
using System.Net;

namespace AllMark.Services
{
    public class HonestSignService : BaseApiService, IHonestSignService
    {
        private readonly string ApiVersion;

        public HonestSignService(IOptions<HonestSignConfig> config) : base(config.Value) 
        {
            ApiVersion = config.Value.ApiVersion;
        }

        private string GetMethodString(string method) => $"api/{ApiVersion}/{method}";

        private RestRequest GetAuthorizedRequest(RestRequest request, string token)
        {
            request.AddHeader("Authorization", $"token {token}");
            return request;
        }

        /// <summary>
        /// Регистрация учетной системы
        /// Необходимые права доступа: MANAGE_ACCOUNTS
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<AccountingSystemRegistered> RegisterAccountingSystem(AccountingSystem accountingSystem, string token)
        {
            var request = GetRequest(GetMethodString("registration/accounting_system"), Method.POST);
            request = GetAuthorizedRequest(request, token);
            request.AddJsonBody(accountingSystem);
            var httpResponse = await ExecuteRequestAsync<AccountingSystemRegistered>(request);
            return httpResponse.Content;
        }

        /// <summary>
        /// Получение кода аутентификации
        /// </summary>
        /// <param name="info">Данные о пользователе</param>
        /// <returns></returns>
        public async Task<string> GetAuthentificationCode(UserAuthInfo info)
        {
            var request = GetRequest(GetMethodString("auth"), Method.POST);
            request.AddJsonBody(info);
            var httpResponse = await ExecuteRequestAsync<AuthCode>(request);
            return httpResponse.Content.Code;
        }

        protected override string ProcessResponseError(HttpStatusCode statusCode)
        {
            throw new System.NotImplementedException();
        }
    }
}
