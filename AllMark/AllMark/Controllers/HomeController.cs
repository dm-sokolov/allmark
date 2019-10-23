using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AllMark.Services.Interfaces;

namespace AllMark.Controllers
{
    public class HomeController : Controller
    {
        private readonly INationalCatalogService _nationalCatalogService;

        public HomeController(INationalCatalogService nationalCatalogService)
        {
            _nationalCatalogService = nationalCatalogService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await _nationalCatalogService.GetBrands();
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
