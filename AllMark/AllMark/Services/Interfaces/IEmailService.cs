using AllMark.Core.Models;
using System.Threading.Tasks;

namespace AllMark.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendConfirmEmail(string email, string callbackUrl);
    }
}
