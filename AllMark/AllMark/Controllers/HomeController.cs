using System.Diagnostics;
using AllMark.Controllers.Base;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            //var draftGtins = await _nationalCatalogService.GenerateGtins(1);

            //var brands = await _nationalCatalogService.GetBrands();

            //var feed = new List<CatalogFeed>
            //{
            //    new CatalogFeed()
            //    {
            //        GTIN = draftGtins.CatalogDrafts.FirstOrDefault()?.Gtin,
            //        GoodName = "Пробный товар",
            //        TNVED = "3303",
            //        Brand = brands.FirstOrDefault()?.Name
            //    }
            //};
            //var feedResult = await _nationalCatalogService.Feed(feed);

            return View();
        }

        public async Task<IActionResult> ForLegalEntity()
        {
            //var attr = await _nationalCatalogService.GetAttributes(30141);
            //var query = string.Join("\n",attr.GroupBy(i => i.GroupName).Select(i => $"Group {i.Key} {i.Count()} \n {string.Join("\n",i.Select(k => k.Name).ToList())}\n\n"));
            
            return View();
        }//=> View();

        public IActionResult ForIP() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message = null)
        {
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };
            return View(errorModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorPartial(string message = null)
        {
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };
            return PartialView(errorModel);
        }
    }
}
