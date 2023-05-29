using Microsoft.AspNetCore.Mvc;
using ProjectFinal2.Models;

namespace ProjectFinal2.Controllers
{
    public class UserController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
           return View( context.User.ToList());
        }
        
    }
}
