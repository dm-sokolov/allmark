using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AllMark.Models;
using AllMark.Interfaces;
using AllMark.Models.Models;
using AllMark.Repository;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var user = new User { Name = "user" };
            await _userRepository.SaveAsync(user);
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
