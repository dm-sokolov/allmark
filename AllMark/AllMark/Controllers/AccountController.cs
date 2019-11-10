using System.Collections.Generic;
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
using System;
using Microsoft.AspNetCore.Http;

namespace AllMark.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IEmailService _emailService;

        public AccountController(IRepository<User> userRepository,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

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
                User user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = model.Email,
                        Password = model.Password
                    };
                    await _userRepository.SaveAsync(user);

                    await Authenticate(model.Email); // аутентификация
                    await SendConfirmMail(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
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
            {
                return View("Error");
            }
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            if (user.GUID == code)
            {
                user.EmailConfirmed = true;
                await _userRepository.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            else
                return View("Error");
        }

        private async Task SendConfirmMail(User user)
        {
            // генерация токена для пользователя. Страшно, но пока так
            var code = Guid.NewGuid().ToString("N");
            user.GUID = code;
            await _userRepository.UpdateAsync(user);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code },
                protocol: HttpContext.Request.Scheme);
            await _emailService.SendConfirmEmail(user.Email, callbackUrl);
        }

        public async Task<ActionResult> Manage()
        {
            var email = HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _userRepository.Query().FirstOrDefaultAsync(i => i.Email == email);
                return View(user);
            }
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}