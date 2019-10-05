using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using AllMark.Interfaces;

namespace AllMark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISimpleHelper _helper;

        public HomeController(ISimpleHelper helper)
        {
            _helper = helper;
        }

        public IActionResult Index()
        {
            var value = _helper.GetValue();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
