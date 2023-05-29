using Microsoft.AspNetCore.Mvc;
using ProjectFinal2.Models;

namespace ProjectFinal2.Controllers
{
    public class CommentController : Controller
    {
        Context Context=new Context();
        public IActionResult comments(Feedback feedback)
        {
            string x = HttpContext.Request.Cookies["myCookie"];
            int y = 0;
            if (x != null)
            {
                y = int.Parse(x);

            }
            else
            {
                return RedirectToAction("Login", "Registration");
            }
            Feedback feedback1 = new Feedback();
            feedback1.UserId=y;
            feedback1.realestateId=feedback.realestateId;
            feedback1.FeedbackBody=feedback.FeedbackBody;
            Context.Feedback.Add(feedback1);
            Context.SaveChanges();
            //return RedirectToAction("DetailsForUser", "Realeste");
            return RedirectToAction("GetAllForUser", "realeste");
        }
    }
}
