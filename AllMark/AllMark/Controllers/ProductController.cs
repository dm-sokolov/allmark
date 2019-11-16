using Microsoft.AspNetCore.Mvc;

namespace AllMark.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}