using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.DAL;
using TexasPetroleum.ViewModels;

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
        public ActionResult Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var context = new QuoteContext();
                var client = context.ClientLogins.First();

                if (context.ClientLogins.Any(x => x.Username == user.Username && x.Password == user.Password))
                {
                    // Redirect to UserHub
                    ApplicationSession.Username = user.Username;
                    return Redirect("/Home/UserHub");
                }
                else
                {
                    // Display error
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
        public ActionResult Register(RegistrationVM user)
        {
            if (ModelState.IsValid)
            {
                using (var context = new QuoteContext())
                {
                    //check database for existing username
                    if (context.ClientLogins.Any(x => x.Username == user.Username))
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists");
                        return View(user);
                    }
                    else
                    {
                        var newLogin = new ClientLogin();
                        newLogin.Id = 1;
                        newLogin.Username = user.Username;
                        newLogin.Password = user.Password;
                        context.ClientLogins.Add(newLogin);
                        context.SaveChanges();

                        return Redirect("/Account/Login");
                    }
                }
            }

            //Redirect to Login Page if model state valid
            return View();
        }
    }
}