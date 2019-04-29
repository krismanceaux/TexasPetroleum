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
using static TexasPetroleum.Enums.PricingEnums;
using System.Data.Entity;
using TexasPetroleum.AuthData;
using static TexasPetroleum.Enums.PricingEnums;

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
                fuelQuote.TotalPrice = quote.TotalPrice;
                fuelQuote.SuggestedPrice = quote.SuggestedPrice;

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
                        SuggestedPrice = quote.SuggestedPrice,
                        TotalPrice = quote.TotalPrice
                    };

                    history.Add(vm);
                }

                return View(history);
            }
            return View();
        }



        public double CalculateQuotePrice(double gallons, StateOptions state)
        {
            var context = new QuoteContext();
            var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
            var client = context.Clients.Single(x => x.LoginId == login.Id);
            //Placeholder for Pricing Module calculations
            double pricePerGal = 1.50, marginPrice, profitFactor = 0.10, locationFactor, rateHistory, gallonFactor, rateFluct, sugPrice;
            string sMonth = DateTime.Now.ToString("MM"); //for current month to see which season we are in
            Int32.TryParse(sMonth, out int month);

            int QuoteCount = context.FuelQuotes.Count(x => x.ClientId == client.Id);

            if (state == StateOptions.TX)
                locationFactor = 0.02;
            else
                locationFactor = 0.04;

            if (QuoteCount > 0)
                rateHistory = 0.01;
            else
                rateHistory = 0.00;


            if (gallons > 1000)
                gallonFactor = 0.02;
            else
                gallonFactor = 0.03;

            if (Enum.GetName(typeof(Seasons), month) == "Summer")
                rateFluct = 0.04;
            else
                rateFluct = 0.03;

            marginPrice = pricePerGal * (locationFactor - rateHistory + gallonFactor + profitFactor + rateFluct); //need to add rateHistory
            sugPrice = pricePerGal + marginPrice;

            return sugPrice;
        }

        [HttpPost]
        public ActionResult GetPrice(double GallonsRequested, StateOptions State)
        {
            var context = new QuoteContext();
            var login = context.ClientLogins.Single(x => x.Username == ApplicationSession.Username);
            var client = context.Clients.Single(x => x.LoginId == login.Id);
            var user = new QuoteVM();
            user.AddressLine1 = client.AddressLine1;
            user.AddressLine2 = client.AddressLine2;
            user.City = client.City;
            user.State = client.State;
            user.Zipcode = client.ZipCode;
            user.SuggestedPrice = CalculateQuotePrice(GallonsRequested, State);
            user.TotalPrice = GallonsRequested * user.SuggestedPrice;
            return Json(user, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SubmitSuccess()
        {
            return View();
        }
    }
}