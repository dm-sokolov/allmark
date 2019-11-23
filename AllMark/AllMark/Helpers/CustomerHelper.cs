using AllMark.Core.Models;
using AllMark.Helpers.Interfaces;
using AllMark.Repository;
using AllMark.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AllMark.Helpers
{
    public class CustomerHelper: ICustomerHelper
    {
        private readonly IEmailService _emailService;
        private readonly IRepository<Customer> _customerRepository;

        public async Task SendConfirmEmail(Customer customer, string callbackUrl, string code)
        {
            customer.GUID = code;
            await _customerRepository.UpdateAsync(customer);

            await _emailService.SendEmailAsync(customer.Email, "Подтверждение учетной записи",
                $@"C:\Users\Николай\Documents\allmark\AllMark\AllMark\Services\EmailService.cs: <a href='{callbackUrl}'>CONFIRM_LINK</a>");
        }
    }
}
