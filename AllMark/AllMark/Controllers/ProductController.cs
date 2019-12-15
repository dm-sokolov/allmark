using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllMark.AutoMapper.Extensions;
using AllMark.Controllers.Base;
using AllMark.Core.Models;
using AllMark.DTO;
using AllMark.Repository;
using AllMark.Services.Interfaces;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;

namespace AllMark.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> _productRepository;
        private readonly INationalCatalogService _nationalCatalogService;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ProductAttribute> _productAttributeRepository;
        private readonly ICustomerService _customerService;
        private readonly IExcelService _excelService;
        private readonly IMapper _mapper;

        public ProductController(INationalCatalogService nationalCatalogService,
            IExcelService excelService,
            IMapper mapper,
            IRepository<Category> categoryRepository,
            IRepository<ProductAttribute> productAttributeRepository,
            ICustomerService customerService,
            IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _productAttributeRepository = productAttributeRepository;
            _nationalCatalogService = nationalCatalogService;
            _excelService = excelService;
            _mapper = mapper;
            _customerService = customerService;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Products() => View();

        [HttpPost]
        public async Task<ActionResult> GetProducts([DataSourceRequest] DataSourceRequest request)
        {
            var products = await _productRepository.Query().ToListAsync();
            var dtos = products.MapTo<List<ProductDto>>(_mapper);
            return Json(dtos.ToDataSourceResult(request));
        }

        public void UploadExcel(IEnumerable<IFormFile> files) => _excelService.ReadFiles(files);

        public async Task<IActionResult> GetAttributes(int categoryId)
        {
            var attributesResponse = await _nationalCatalogService.GetAttributes(categoryId);
            if (attributesResponse.IsSuccess)
                return PartialView("_attrTabStrip", attributesResponse.Content?.Items);
            return RedirectToAction("ErrorPartial", "Home", new { message = attributesResponse.Message });
        }

        public async Task<IActionResult> GetCategories(int? categoryId)
        {
            var categories = await _categoryRepository.GetAllCacheableAsync();

            var selectedCategories = new List<Category>();
            if (categoryId.HasValue)
            {
                selectedCategories = categories.Where(i => i.ParentId == categoryId.Value).ToList();
            }
            else
            {
                var minLevel = categories.Min(i => i.Level);
                selectedCategories = categories.Where(i => i.Level == minLevel).ToList();
            }
            var categoryDtos = selectedCategories.MapTo<List<CategoryDto>>(_mapper);
            categoryDtos.ForEach(category => category.HasChildren = categories.Any(i => i.ParentId == category.CategoryId));

            return Json(_mapper, categoryDtos, typeof(List<CategoryDto>));
        }

        public async Task<IActionResult> GetBrands()
        {
            var brandsResponse = await _nationalCatalogService.GetBrands();
            return Json(brandsResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            var newProduct = productDto.MapTo<Product>(_mapper);

            var customer = await _customerService.GetCurrentAsync();
            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);

            if (productDto.Id == 0)
            {
                foreach(var attribute in newProduct.Attributes)
                    await _productAttributeRepository.SaveAsync(attribute);
            }
            else
            {
                var attrIds = productDto.Attributes.Select(i => i.AttributeId).ToList();
                var existingAttributes = await _productAttributeRepository.Query()
                    .Where(i => i.Product.Id == productDto.Id && attrIds.Contains(i.AttributeId))
                    .ToListAsync();
                var newAttributes = newProduct.Attributes.Where(i => existingAttributes.All(a => a.AttributeId != i.AttributeId))
                    .ToList();
                foreach (var attribute in newAttributes)
                    await _productAttributeRepository.SaveAsync(attribute);
                foreach(var attribute in existingAttributes)
                {
                    await _productAttributeRepository.EvictAsync(attribute);
                    var newAttribute = newProduct.Attributes.FirstOrDefault(i => i.AttributeId == attribute.AttributeId);
                    newAttribute.Id = attribute.Id;
                    await _productAttributeRepository.UpdateAsync(newAttribute);
                }
            }

            newProduct.Customer = customer;
            if (category != null)
                newProduct.Categories.Add(category);

            var result = await _productRepository.SaveAsync(newProduct);
            return Json(result);
        }
    }
}