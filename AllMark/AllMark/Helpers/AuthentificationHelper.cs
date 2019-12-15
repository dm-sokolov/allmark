using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AllMark.Core.Models;
using AllMark.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AllMark.Helpers
{
    public class AuthentificationHelper : IAuthentificationHelper
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthentificationHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task Authenticate(Customer customer)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, customer.Email)
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task Logout() => await _accessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
