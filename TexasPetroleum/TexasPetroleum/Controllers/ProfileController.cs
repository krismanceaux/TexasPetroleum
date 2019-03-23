using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.ViewModels;

namespace TexasPetroleum.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        public ActionResult Index()
        {
            return View();
        }

        //I just commented this out for now/ change later?
        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    //var context = new QuoteContext();
        //    //var client = context.Clients.SingleOrDefault(x => x.ClientId == )

        //    //// If no client data exists, create new client to pass to view
        //    //if (currentUser.Client == null)
        //    //{
        //    //    currentUser.Client = new Client();
        //    //}

        //    //ProfileViewModel vm = new ProfileViewModel()
        //    //{
        //    //    Name = currentUser.Client.Name,
        //    //    Address = currentUser.Client.Address
        //    //};

        //    //return View();
        //}

        [HttpPost]
        public ActionResult Edit(ProfileVM model)
        {

            //var context = new ApplicationDbContext();
            //var currentUserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //var currentUser = context.Users.Single(x => x.Id == currentUserID);
            //var client = currentUser.Client;

            //if (client == null)
            //{
            //    client = new Client();
            //    client.ApplicationUser = currentUser;
            //}

            //client.Name = model.Name;
            //client.Address.AddressLine1 = model.Address.AddressLine1;
            //client.Address.AddressLine2 = model.Address.AddressLine2;
            //client.Address.City = model.Address.City;

            //var stateStringVal = model.StateOption.ToString();

            //client.Address.State = stateStringVal;
            //client.Address.ZipCode = model.Address.ZipCode;

            //context.Clients.Add(client);
            //context.Users.Attach(client.ApplicationUser);

            //context.SaveChanges();

            return View();
        }
    }
}