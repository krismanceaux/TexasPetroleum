using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.DAL;
using TexasPetroleum.Models;
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
                var client = context.Clients.First();

                if (context.Clients.Any(x => x.Username == user.Username && x.Password == user.Password))
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
                        var newClient = new Client();

                        newClient.Username = user.Username;
                        newClient.Password = user.Password;
                        newClient.Address = new Address();
                        newClient.Address.Id = newClient.ClientId;
                        
                        context.Addresses.Add(newClient.Address);   
                        context.Clients.Add(newClient);

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