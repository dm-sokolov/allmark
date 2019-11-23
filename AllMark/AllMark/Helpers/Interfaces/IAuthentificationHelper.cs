using AllMark.Core.Models;
using System.Threading.Tasks;

namespace AllMark.Helpers.Interfaces
{
    public interface IAuthentificationHelper
    {
        Task Authenticate(Customer customer);
    }
}
