using AllMark.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AllMark.Controllers
{
    public class ProductController : Controller
    {
        private readonly INationalCatalogService _nationalCatalogService;

        public ProductController(INationalCatalogService nationalCatalogService)
        {
            _nationalCatalogService = nationalCatalogService;
        }

        public IActionResult Products() => View();

        [HttpPost]
        public async Task<ActionResult> GetProducts([DataSourceRequest] DataSourceRequest request)
        {
            var products = await _nationalCatalogService.GetProducts(gtin: 6411300162475);
            return Json(products.ToDataSourceResult(request));
        }
    }
}