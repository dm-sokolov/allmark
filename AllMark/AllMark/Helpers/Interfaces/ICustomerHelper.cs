using System.Threading.Tasks;
using AllMark.Core.Models;

namespace AllMark.Helpers.Interfaces
{
    public interface ICustomerHelper
    {
        Task SendConfirmEmail(Customer customer, string callbackUrl, string code);
    }
}
