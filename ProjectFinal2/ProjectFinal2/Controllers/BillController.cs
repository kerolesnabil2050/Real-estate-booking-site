using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinal2.Models;

namespace ProjectFinal2.Controllers
{
	public class BillController : Controller
	{
        Context Context = new Context();
		public IActionResult Index()
		{
           return View();
		}
        public IActionResult Recereive(int id)
        {
            string x = HttpContext.Request.Cookies["myCookie"];
            
            if (x == null)
            {
                return RedirectToAction("Login", "Registration");
            }
            else
            {
                int y = int.Parse(x);
                realestate realestate = Context.realestate.Where(e => e.Id == id).Include(e=>e.owner).Include(e => e.owner).FirstOrDefault();
                realestate.Status = true;
                Context.realestate.Update(realestate);
                Context.SaveChanges();
                
                User user = Context.User.Where(e => e.Id == y).FirstOrDefault();
                Bill bill = new Bill();
                bill.realestateId = realestate.Id;
                bill.UserId = user.Id;
                bill.StartDate = realestate.StartDate;
                bill.EndDate = realestate.EndDate;
                Context.Bill.Add(bill);
                Context.SaveChanges();
                ViewData["user"] = user;
                ViewData["Date"] = DateTime.Now;
                ViewData["realestate"] = realestate;
                return View();
            }
        }
	}
}
