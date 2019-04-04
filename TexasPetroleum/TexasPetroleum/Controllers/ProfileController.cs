using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.DAL;
using TexasPetroleum.ViewModels;
using static TexasPetroleum.Enums.DisplayEnums;
using System.Data.Entity;
using TexasPetroleum.AuthData;

namespace TexasPetroleum.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        public ActionResult Index()
        {
            return View();
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult Edit()
        {
            if (ApplicationSession.Username != "" && ApplicationSession.Username != null)
            {
                var context = new QuoteContext();
                var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
                var client = context.Clients.Single(x => x.LoginId == login.Id);

                ProfileVM vm = new ProfileVM()
                {
                    Name = client.Name,
                    AddressLine1 = client.AddressLine1,
                    AddressLine2 = client.AddressLine2,
                    City = client.City,
                    StateOption = client.State == null || client.State == String.Empty ? Enums.DisplayEnums.StateOptions.AK : (StateOptions)Enum.Parse(typeof(StateOptions), client.State),
                    Zipcode = client.ZipCode
                };

                return View(vm);
            }
            return View();
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult Edit(ProfileVM model)
        {
            if (ModelState.IsValid)
            {
                var context = new QuoteContext();
                var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
                var client = context.Clients.Single(x => x.LoginId == login.Id);

                client.Name = model.Name;
                client.AddressLine1 = model.AddressLine1;
                client.AddressLine2 = model.AddressLine2;
                client.City = model.City;
                client.State = model.StateOption.ToString();
                client.ZipCode = model.Zipcode;

                context.SaveChanges();

                return Redirect("/Home/UserHub");
            }
            else
                return View(model);
         
        }
    }
}