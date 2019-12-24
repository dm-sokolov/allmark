using System.Threading.Tasks;
using AllMark.Core.Models;

namespace AllMark.Helpers.Interfaces
{
    public interface IAuthentificationHelper
    {
        Task Authenticate(Customer customer);

        Task Logout();
    }
}
