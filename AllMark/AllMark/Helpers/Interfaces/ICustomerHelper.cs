using AllMark.Core.Models;
using System.Threading.Tasks;

namespace AllMark.Helpers.Interfaces
{
    public interface ICustomerHelper
    {
        Task SendConfirmEmail(Customer customer);
    }
}
