using Microsoft.AspNetCore.Mvc;

namespace ProjectFinal2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
