using Microsoft.AspNetCore.Mvc;
using ProjectFinal2.Models;

namespace ProjectFinal2.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {     
            return View();
        }
        public IActionResult GetAll()
        {
            List<User> k= context.User.ToList();
            return View(k);

        }

        public IActionResult GetAllOwner()
        {
            List<owner> k = context.Owner.ToList();
            return View(k);

        }

        public IActionResult changestate([FromRoute] int id)
        {
            owner owner= context.Owner.FirstOrDefault(e => e.Id == id);
            if(owner.State)
            {
                owner.State = false;
            }
            else
            {
                owner.State = true;
            }
            
            context.Owner.Update(owner);
            context.SaveChanges();
            return RedirectToAction("GetAllOwner");

        }


    }
}
