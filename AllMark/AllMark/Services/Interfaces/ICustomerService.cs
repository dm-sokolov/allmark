using System.Threading.Tasks;
using AllMark.Core.Models;

namespace AllMark.Services.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Возвращает авторизованного пользователя
        /// </summary>
        /// <returns></returns>
        Task<Customer> GetCurrentAsync();
    }
}
