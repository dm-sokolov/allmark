using AllMark.Core.Models;
using System.Threading.Tasks;

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
