using AllMark.Core.Models;
using AllMark.Helpers.Interfaces;
using AllMark.Repository;
using AllMark.Services.Interfaces;
using System.Threading.Tasks;

namespace AllMark.Helpers
{
    public class CustomerHelper: ICustomerHelper
    {
        private readonly IEmailService _emailService;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerHelper(IEmailService emailService,
            IRepository<Customer> customerRepository)
        {
            _emailService = emailService;
            _customerRepository = customerRepository;
        }

        public async Task SendConfirmEmail(Customer customer, string callbackUrl, string code)
        {
            customer.GUID = code;
            await _customerRepository.UpdateAsync(customer);
            //TODO Исправить строку подтверждения
            await _emailService.SendEmailAsync(customer.Email, "Подтверждение учетной записи",
                $@"C:\Users\Николай\Documents\allmark\AllMark\AllMark\Services\EmailService.cs: <a href='{callbackUrl}'>CONFIRM_LINK</a>");
        }
    }
}
