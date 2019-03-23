using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TexasPetroleum.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountVM user)
        {
            if (ModelState.IsValid)
            {
                var context = new QuoteContext();

                //Temp while DB is down
                //return Redirect("/Home/UserHub");

                if (false)   //context.Clients.Any(x => x.Username == user.Username && x.Password == user.Password)
                {
                    //redirect to UserHub
                    return Redirect("/Home/UserHub");
                }
                else
                {
                    // display error
                    ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    return View(user);
                }
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Register()
        {
            //Displays Registration Page
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountVM user)
        {
            if(ModelState.IsValid)
            {
                using (var context = new QuoteContext())
                {
                    //check database for existing username
                    if (context.Clients.Any(x => x.Username == user.Username))
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists");
                        return View(user);
                    }
                    else
                    {
                        return Redirect("/Home/Login");
                    }
                }
            }

            //Redirect to Login Page if model state valid
            return View();
        }
    }
}