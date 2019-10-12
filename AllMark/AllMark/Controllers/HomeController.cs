using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using AllMark.Interfaces;
using AllMark.Models.Models;
using AllMark.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AllMark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISimpleHelper _helper;
        private readonly IRepository<User> _userRepository;

        public HomeController(ISimpleHelper helper, 
            IRepository<User> userRepository)
        {
            _helper = helper;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
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
