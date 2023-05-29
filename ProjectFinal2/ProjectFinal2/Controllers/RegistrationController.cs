using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectFinal2.Models;
using ProjectFinal2.ViewModels;
using RestSharp;
using System.Net;

namespace ProjectFinal2.Controllers
{
    public class RegistrationController : Controller
    {
        Context context= new Context();

        
        [HttpGet]
        public IActionResult Register( )
        {
            return View(new UserRegistration());

        }
        [HttpPost]
        public IActionResult Register(UserRegistration owner)
        {
            if (ModelState.IsValid == true)
            {
                owner Existingowner=null;
                User Existinuser=null;
                if (owner.role == Role.Owner)
                {
                     Existingowner = context.Owner.FirstOrDefault(x => x.Email == owner.Email);
                }
                else
                {
                    Existinuser = context.User.FirstOrDefault(x => x.Email == owner.Email);

                }

                if (Existingowner == null &&owner.role==Role.Owner)
                {
                    owner owner1 = new owner();
                    owner1.FirstName = owner.FirstName;
                    owner1.LastName = owner.LastName;
                    owner1.Email = owner.Email;
                    owner1.Phone = owner.Phone;
                    owner1.Password = owner.Password;
                    owner1.Address = owner.Address;

                    context.Owner.Add(owner1);
                    context.SaveChanges();
                    return RedirectToAction("Login", "Registration");
                }
                else if(Existinuser==null&&owner.role==Role.user)
                {
                    User owner1 = new User();
                    owner1.FirstName = owner.FirstName;
                    owner1.LastName = owner.LastName;
                    owner1.Email = owner.Email;
                    owner1.Phone = owner.Phone;
                    owner1.Password = owner.Password;
                    owner1.Address = owner.Address;

                    context.User.Add(owner1);
                    context.SaveChanges();
                    return RedirectToAction("Login", "Registration");
                }
            }
            return View(owner);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());

        }
        [HttpPost]
        public IActionResult Login(Login ownerModel)
        {
            owner owner = null;
            if (ModelState.IsValid == true)
            {

               owner =context.Owner.FirstOrDefault(x=>x.Email== ownerModel.Email);
                string username = ownerModel.Email;
                string password = ownerModel.Password;
                if((username=="admin"&&password== "admin"))
                {
                    return RedirectToAction("Index","Admin");
                }
                else if (owner != null)
                {
                    if (owner.Password == ownerModel.Password)
                    {

                        if (owner.State == true)
                        {
                            var cookieOptions = new CookieOptions
                            {

                            };

                            HttpContext.Response.Cookies.Append("myCookie", $"{owner.Id}", cookieOptions);


                            HttpContext.Response.Cookies.Append("myRole", "owner", cookieOptions);

                            return RedirectToAction("index", "Realeste");
                        }
                        else
                        {
                            return View("Penndingpage");
                        }
                    }
                    else
                    {
                        return View(ownerModel);

                    }

                }
                else if(owner==null)
                {
                    User user = context.User.FirstOrDefault(x => x.Email == ownerModel.Email);
                    if (user != null)
                    {
                        if (user.Password == ownerModel.Password)
                        {
                            var cookieOptions = new CookieOptions
                            {

                            };
                            HttpContext.Response.Cookies.Append("myCookie", $"{user.Id}", cookieOptions);


                            HttpContext.Response.Cookies.Append("myRole", "user", cookieOptions);


                            return RedirectToAction("GetAllForUser", "Realeste");
                        }
                        else
                        {
							return View(ownerModel);

						}
					}
                    else
                    {
                        return View(ownerModel);

                    }
                }
            }
            return View(ownerModel);



        }
        public IActionResult Logout()
        {
			Response.Cookies.Delete("myCookie");
			Response.Cookies.Delete("myRole");
			return RedirectToAction("Login", "Registration");
        }


    }
}
