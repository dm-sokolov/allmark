using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using AllMark.Repository;
using NHibernate.Linq;
using AllMark.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AllMark.Controllers.Base;
using AllMark.Helpers.Interfaces;
using System;
using AllMark.Services.Interfaces;
using AllMark.AutoMapper.Extensions;
using AutoMapper;
using AllMark.DTO;

namespace AllMark.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ICustomerHelper _customerHelper;
        private readonly IAuthentificationHelper _authentificationHelper;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AccountController(IRepository<Customer> customerRepository,
            ICustomerHelper customerHelper,
            IAuthentificationHelper authentificationHelper,
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerHelper = customerHelper;
            _authentificationHelper = authentificationHelper;
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();

        public async Task<ActionResult> Manage()
        {
            var customer = await _customerService.GetCurrentAsync();
            if (customer != null)
                return View(_mapper, customer, typeof(CustomerDto));
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
                    await _authentificationHelper.Authenticate(customer);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerRepository.Query().FirstOrDefaultAsync(u => u.Email == model.Email);
                if (customer == null)
                {
                    customer = model.MapTo<Customer>(_mapper);
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
            await _authentificationHelper.Logout();
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

        public async Task<ActionResult> Update(CustomerDto dto)
        {
            var user = await _customerRepository.GetByIdAsync(dto?.Id);
            user.Name = dto.Name;
            user.NationalCatalogKey = dto.NationalCatalogKey;
            await _customerRepository.UpdateAsync(user);
            return Json(_mapper, user, typeof(CustomerDto));
        }
    }
}