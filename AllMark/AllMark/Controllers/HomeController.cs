using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using AllMark.Services.Interfaces;
using System.Threading.Tasks;

namespace AllMark.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            await _emailService.SendEmailAsync("esaulkovNikolay@yandex.ru", "test subject", "test message");
            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
