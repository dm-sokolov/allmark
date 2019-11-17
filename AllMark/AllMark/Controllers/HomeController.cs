using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using AllMark.Services.Interfaces;
using AllMark.Controllers.Base;

namespace AllMark.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IExcelService _excelService;

        public HomeController(IExcelService excelService)
        {
            _excelService = excelService;
        }

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

        public void Upload(IEnumerable<IFormFile> files)
        {
            _excelService.ReadFiles(files);
        }
    }
}
