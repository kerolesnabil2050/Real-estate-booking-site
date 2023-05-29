using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using ProjectFinal2.Models;
using ProjectFinal2.ViewModels;
using System.Net;

namespace ProjectFinal2.Controllers
{
    public class RealesteController : Controller
    {

        Context context = new Context();
        int y;
        public IActionResult Index()
        {
            
            string x = HttpContext.Request.Cookies["myCookie"];
            if (x == null)
            {
                return RedirectToAction("GetAllForUser");

                //return Content("please login");
            }
            else
            {
                y = int.Parse(x);
            }
            if (!string.IsNullOrEmpty("myCookie"))
            {
                List<realestate> realestates = context.realestate.Where(r => r.ownerId == y).Include(r => r.Images).ToList();
                return View(realestates);

            }
            return RedirectToAction("GetAllForUser");
        }
        public IActionResult GetAllForUser()
        {
            List<realestate> realestates = context.realestate.Where(e=>e.Status==false).Include(r => r.Images).ToList();
            return View(realestates);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RealestateViewModel realestateVM)
        {

            var OwnersId = HttpContext.Request.Cookies["myCookie"];
			if (OwnersId != null)
				y = int.Parse(OwnersId);
			
			realestate realestate1 = new realestate();
            string ImgeName;

            if (realestateVM != null && ModelState.IsValid)
            {
                realestate1.Price = realestateVM.Price;
                realestate1.Description = realestateVM.Description;
                realestate1.RoomsNumber = realestateVM.RoomsNumber;
                realestate1.Type = realestateVM.Type;
                realestate1.Address = realestateVM.Address;
                realestate1.FloorNumber = realestateVM.FloorNumber;
                realestate1.StartDate = realestateVM.StartDate;
                realestate1.EndDate = realestateVM.EndDate;
                realestate1.ownerId = y;
                context.realestate.Add(realestate1);
                context.SaveChanges();


                string ImgePath = Directory.GetCurrentDirectory() + "/wwwroot/Image/";
                if (realestateVM.photes.Count > 0)
                {
                    foreach (var formFile in realestateVM.photes)
                    {
                        HostingEnvironment hostingEnvironment = new HostingEnvironment();
                        ImgeName = Guid.NewGuid() + Path.GetFileName(formFile.FileName);

                        string FinalIamgePath = Path.Combine(ImgePath, ImgeName);

                        using (var Stream = new FileStream(FinalIamgePath, FileMode.Create))

                        {
                            formFile.CopyTo(Stream);

                        }
                        context.Images.Add(new Images
                        {
                            Image = ImgeName,
                            realestateId = realestate1.Id,
                        });

                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");

                }
                return Content("Marwa");

            }
            else
            {

                return View(realestateVM);

            }
        }

        public IActionResult Details(int id)
        {
           
            
            realestate realestate = context.realestate.Where(realestate => realestate.Id == id ).Include(r => r.Images).Include(e => e.Feedbacks).ThenInclude(e => e.User).FirstOrDefault();
            return View(realestate);
        }
		public IActionResult DetailsForUser(int id)
		{

     
            realestate realestate = context.realestate.Where(realestate => realestate.Id == id).Include(r => r.Images).Include(e=>e.Feedbacks).ThenInclude(e=>e.User).FirstOrDefault();

            return View(realestate);
		}
		[HttpGet]
        public IActionResult Edit(int id)
        {

            return View(context.realestate.FirstOrDefault(realestate => realestate.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(realestate realestate)
        {
            context.realestate.Update(realestate);
            context.SaveChanges();
            return RedirectToAction("Index","Realeste");
        }
        public ActionResult Delete(int id)
        {
            try
            {

                realestate realestate = context.realestate.Where(r => r.Id == id).Include(r=>r.Images).FirstOrDefault();
                realestate.Images =null;
                context.SaveChanges();
                context.realestate.Remove(realestate);
                context.SaveChanges();
            }
            catch
            {
                throw new Exception("error");
            }
            return RedirectToAction("Index");
        }
      


    }
}

