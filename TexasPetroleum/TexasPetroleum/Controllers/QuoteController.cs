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
                var client = context.Clients.Include(c => c.Address).Single(x => x.Username.Contains(ApplicationSession.Username));

                var quote = new QuoteVM();
                quote.AddressLine1 = client.Address.AddressLine1 == null ? "" : client.Address.AddressLine1;
                quote.AddressLine2 = client.Address.AddressLine2 == null ? "" : client.Address.AddressLine2;
                quote.City = client.Address.City == null ? "" : client.Address.City;
                quote.State = client.Address.State == null ? "" : client.Address.State;
                quote.Zipcode = client.Address.Zipcode == null ? "" : client.Address.Zipcode;

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
                var client = context.Clients.Include(c => c.Address).Single(x => x.Username.Contains(ApplicationSession.Username));
                var address = client.Address;

                FuelQuote fuelQuote = new FuelQuote();

                fuelQuote.DeliveryDate = quote.DeliveryDate;
                fuelQuote.GallonsRequested = quote.GallonsRequested;
                fuelQuote.TimeCreated = DateTime.Now;
                fuelQuote.DeliveryAddress = address;

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

                var client = context.Clients.Include(x => x.FuelQuotes).Include(x => x.Address).Single(x => x.Username == ApplicationSession.Username);
                List<FuelQuote> fuelQuotes = client.FuelQuotes.ToList();
                List<QuoteVM> history = new List<QuoteVM>();

                foreach (var quote in fuelQuotes)
                {

                    var vm = new QuoteVM
                    {
                        //Added a few checks for null while debugging, but may not be necessary in final version
                        AddressLine1 = quote.DeliveryAddress == null ? "" : quote.DeliveryAddress.AddressLine1,
                        AddressLine2 = quote.DeliveryAddress == null ? "" : quote.DeliveryAddress.AddressLine2,
                        City = quote.DeliveryAddress == null ? "" : quote.DeliveryAddress.City,
                        State = quote.DeliveryAddress == null ? "" : quote.DeliveryAddress.State,
                        Zipcode = quote.DeliveryAddress == null ? "" : quote.DeliveryAddress.Zipcode,
                        DeliveryDate = quote.DeliveryDate,
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