using System.Security.Claims;
using System.Threading.Tasks;
using AllMark.Core.Models;
using AllMark.Repository;
using AllMark.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using NHibernate.Linq;

namespace AllMark.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IHttpContextAccessor contextAccessor,
            IRepository<Customer> customerRepository)
        {
            _contextAccessor = contextAccessor;
            _customerRepository = customerRepository;
        }

        /// <inheritdoc />
        public async Task<Customer> GetCurrentAsync()
        {
            var email = _contextAccessor.HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (!string.IsNullOrEmpty(email))
                return await _customerRepository.Query().FirstOrDefaultAsync(i => i.Email == email);
            return null;
        }
    }
}
