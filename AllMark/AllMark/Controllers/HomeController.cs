using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using AllMark.Controllers.Base;
using AllMark.Services.Interfaces;
using FluentNHibernate.Testing.Values;
using Utils.NationalCatalog.Models;

namespace AllMark.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INationalCatalogService _nationalCatalogService;

        public HomeController(INationalCatalogService nationalCatalogService)
        {
            _nationalCatalogService = nationalCatalogService;
        }

        [Authorize]
        public async Task<IActionResult> Index() // => View();
        {
            var draftGtins = await _nationalCatalogService.GenerateGtins(1);

            var brands = await _nationalCatalogService.GetBrands();

            var feed = new List<CatalogFeed>
            {
                new CatalogFeed()
                {
                    GTIN = draftGtins.CatalogDrafts.FirstOrDefault()?.Gtin,
                    GoodName = "Пробный товар",
                    TNVED = "3303",
                    Brand = brands.FirstOrDefault()?.Name
                }
            };
            var feedResult = await _nationalCatalogService.Feed(feed);

            return View();
        }
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
