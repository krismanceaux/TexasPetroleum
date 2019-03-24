using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.DAL;
using TexasPetroleum.ViewModels;
using static TexasPetroleum.Enums.DisplayEnums;

namespace TexasPetroleum.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var context = new QuoteContext();
            var client = context.Clients.Single(x => x.Username == ApplicationSession.Username);
            var address = client.Address == null ? new Address() : client.Address;

            ProfileVM vm = new ProfileVM()
            {
                Name = client.Name,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                StateOption = (StateOptions)Enum.Parse(typeof(StateOptions), address.State),
                Zipcode = address.Zipcode
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ProfileVM model)
        {

            var context = new QuoteContext();
            var client = context.Clients.Single(x => x.Username == ApplicationSession.Username);
            var address = context.Addresses.Single(x => x.Id == client.Id);

            client.Name = model.Name;
            address.AddressLine1 = model.AddressLine1;
            address.AddressLine2 = model.AddressLine2;
            address.City = model.City;
            address.State = model.StateOption.ToString();
            address.Zipcode = model.Zipcode;

            client.Address = address;
            context.SaveChanges();

            return Redirect("/Home/UserHub");
        }
    }
}