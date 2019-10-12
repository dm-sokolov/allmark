using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AllMark.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
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
