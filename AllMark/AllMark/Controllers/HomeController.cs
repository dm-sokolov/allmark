using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AllMark.Controllers.Base;

namespace AllMark.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public IActionResult Index() => View();

        public IActionResult ForLegalEntity() => View();

        public IActionResult ForIP() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
