using AllMark.Controllers.Base;
using AllMark.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllMark.AutoMapper.Extensions;
using AllMark.Core.Models;
using AllMark.DTO;
using AllMark.Repository;
using AutoMapper;


namespace AllMark.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> _productRepository;
        private readonly INationalCatalogService _nationalCatalogService;
        private readonly IExcelService _excelService;
        private readonly IMapper _mapper;

        public ProductController(INationalCatalogService nationalCatalogService,
            IExcelService excelService,
            IMapper mapper,
            IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _nationalCatalogService = nationalCatalogService;
            _excelService = excelService;
            _mapper = mapper;
        }

        public IActionResult Products() => View();

        [HttpPost]
        public async Task<ActionResult> GetProducts([DataSourceRequest] DataSourceRequest request)
        {
            var products = await _nationalCatalogService.GetProducts(gtin: 6411300162475);
            return Json(products.ToDataSourceResult(request));
        }

        public void UploadExcel(IEnumerable<IFormFile> files)
        {
            _excelService.ReadFiles(files);
        }

        public async Task<IActionResult> GetAttributes(int categoryId)
        {
            var attributesResponse = await _nationalCatalogService.GetAttributes(categoryId);
            if (attributesResponse.IsSuccess)
                return PartialView("_attrTabStrip", attributesResponse.Content?.Items);
            return RedirectToAction("ErrorPartial", "Home", new { message = attributesResponse.Message });
            
            //var attrs = new List<CatalogAttribute>
            //{
            //    new CatalogAttribute
            //    {
            //        Preset = new List<string>{"11", "22"},
            //        FieldType = "text",
            //        GroupName = "group",
            //        Name = "name"
            //    }
            //};
            //return PartialView("_Attributes", attrs);
        }

        public async Task<IActionResult> GetCategories()
        {
            var categoriesResponse = await _nationalCatalogService.GetCategories();
            return Json(categoriesResponse);
        }

        public async Task<IActionResult> GetBrands()
        {
            var brandsResponse = await _nationalCatalogService.GetBrands();
            return Json(brandsResponse);
        }
        
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            var newProduct = productDto.MapTo<Product>(_mapper);
            var result = await _productRepository.SaveAsync(newProduct);
            return Json(result);
        }
    }
}