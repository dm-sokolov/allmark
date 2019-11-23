using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AllMark.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AllMark.Repository;
using NHibernate.Linq;
using AllMark.Core.Models;
using Microsoft.AspNetCore.Authorization;
using AllMark.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using AllMark.Controllers.Base;
using AllMark.Helpers.Interfaces;
using System;

namespace AllMark.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ICustomerHelper _customerHelper;
        private readonly IAuthentificationHelper _authentificationHelper;

        public AccountController(IRepository<Customer> customerRepository,
            ICustomerHelper customerHelper,
            IAuthentificationHelper authentificationHelper)
        {
            _customerRepository = customerRepository;
            _customerHelper = customerHelper;
            _authentificationHelper = authentificationHelper;
        }

        public IActionResult Login() => View();

        public async Task<ActionResult> Manage()
        {
            var email = HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _customerRepository.Query().FirstOrDefaultAsync(i => i.Email == email);
                return View(user);
            }
            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerRepository.Query().FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (customer != null)
                {
                    await _authentificationHelper.Authenticate(customer); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = await _customerRepository.Query().FirstOrDefaultAsync(u => u.Email == model.Email);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        Email = model.Email,
                        Password = model.Password
                    };
                    await _customerRepository.SaveAsync(customer);

                    await _authentificationHelper.Authenticate(customer); // аутентификация
                    var code = Guid.NewGuid().ToString("N");
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = customer.Id, code },
                        protocol: HttpContext.Request.Scheme);
                    await _customerHelper.SendConfirmEmail(customer, callbackUrl, code);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int userId, string code)
        {
            if (code == null)
                return RedirectToAction("Error", "Home");

            var user = await _customerRepository.GetByIdAsync(userId);
            if (user == null)
                return RedirectToAction("Error", "Home");

            if (user.GUID == code)
            {
                user.EmailConfirmed = true;
                await _customerRepository.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Update(Customer customerModel)
        {
            var user = await _customerRepository.GetByIdAsync(customerModel?.Id);
            user.Name = customerModel.Name;
            user.NationalCatalogKey = customerModel.NationalCatalogKey;
            await _customerRepository.UpdateAsync(user);
            return Json(user);
        }
    }
}