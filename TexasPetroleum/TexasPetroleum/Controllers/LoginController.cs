using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TexasPetroleum.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            var context = new QuoteContext();

            if (context.Clients.Any(x => x.Username == user.Username && x.Password == user.Password))
            {
                //redirect to home page
            }
            else
            {
                // display error
            }

            return View();
        }

    }
}