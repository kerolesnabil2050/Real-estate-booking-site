using Microsoft.AspNetCore.Mvc;

namespace ProjectFinal2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult contactUs()
		{
			return View();
		}
	}
}
