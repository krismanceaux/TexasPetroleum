using TexasPetroleum.DAL;
//using TexasPetroleum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum;
using TexasPetroleum.ViewModels;
using static TexasPetroleum.Enums.DisplayEnums;
using System.Data.Entity;
using TexasPetroleum.AuthData;

namespace FuelRatePredictor.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        
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

                var quote = new QuoteVM();
                quote.AddressLine1 = client.AddressLine1 == null ? "" : client.AddressLine1;
                quote.AddressLine2 = client.AddressLine2 == null ? "" : client.AddressLine2;
                quote.City = client.City == null ? "" : client.City;
                quote.State = client.State == null ? "" : client.State;
                quote.Zipcode = client.ZipCode == null ? "" : client.ZipCode;

                return View(quote);
            }
            else
            {
                return View();
            }
    
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult Edit(QuoteVM quote)
        {
            if (ModelState.IsValid)
            {
                var context = new QuoteContext();
                var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
                var client = context.Clients.Single(x => x.LoginId == login.Id);

                FuelQuote fuelQuote = new FuelQuote();

                fuelQuote.DeliveryDate = quote.DeliveryDate;
                fuelQuote.GallonsRequested = quote.GallonsRequested;
                fuelQuote.Client = client;

                client.FuelQuotes.Add(fuelQuote);
                context.FuelQuotes.Add(fuelQuote);
                context.SaveChanges();

                return Redirect("/Home/UserHub");
            }
            else
            {
                return View(quote);
            }
        }

        [AuthAttribute]
        public ActionResult QuoteHistory()
        {
            if (ApplicationSession.Username != "" && ApplicationSession.Username != null)
            {
                var context = new QuoteContext();
                var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
                var client = context.Clients.Single(x => x.LoginId == login.Id);
                
                List<FuelQuote> fuelQuotes = client.FuelQuotes.ToList();
                List<QuoteVM> history = new List<QuoteVM>();

                foreach (var quote in fuelQuotes)
                {

                    var vm = new QuoteVM
                    {
                        AddressLine1 = quote.Client == null ? "" : quote.Client.AddressLine1,
                        AddressLine2 = quote.Client == null ? "" : quote.Client.AddressLine2,
                        City = quote.Client == null ? "" : quote.Client.City,
                        State = quote.Client == null ? "" : quote.Client.State,
                        Zipcode = quote.Client == null ? "" : quote.Client.ZipCode,
                        DeliveryDate = quote.DeliveryDate.Date,
                        GallonsRequested = quote.GallonsRequested,
                        SuggestedPrice = quote.SuggestedPrice
                    };

                    history.Add(vm);
                }

                return View(history);
            }
            return View();
        }

        public double CalculateQuotePrice()
        {
            //Placeholder for Pricing Module calculations

            return 0.00;
        }

      
        public ActionResult SubmitSuccess()
        {
            return View();
        }
    }
}