using TexasPetroleum.DAL;
using TexasPetroleum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum;
using TexasPetroleum.ViewModels;
using static TexasPetroleum.Enums.DisplayEnums;

namespace FuelRatePredictor.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(QuoteVM quote)
        {
            
            var context = new QuoteContext();
            var client = context.Clients.Single(x => x.Username == ApplicationSession.Username);

            Address address = new Address();
            FuelQuote fuelQuote = new FuelQuote();

            address.AddressLine1 = quote.AddressLine1;
            address.AddressLine2 = quote.AddressLine2;
            address.City = quote.City;
            address.State = quote.StateOption.ToString();
            address.Zipcode = quote.Zipcode;

            fuelQuote.GallonsRequested = quote.GallonsRequested;
            fuelQuote.TimeCreated = DateTime.Now;
            fuelQuote.DeliveryAddress = address;

            client.FuelQuotes.Add(fuelQuote);

            //context.Quotes.Add(fuelQuote);

            context.SaveChanges();

            return Redirect("/Home/UserHub");
            
         
            
        }
        
        public ActionResult QuoteHistory()
        {
            var context = new QuoteContext();

            var client = context.Clients.Single(x => x.Username == ApplicationSession.Username);

            List<FuelQuote> fuelQuotes = client.FuelQuotes.ToList();
            List<QuoteVM> history = new List<QuoteVM>();

            foreach (var quote in fuelQuotes)
            {
                var vm = new QuoteVM
                {
                    AddressLine1 = quote.DeliveryAddress.AddressLine1,
                    AddressLine2 = quote.DeliveryAddress.AddressLine2,
                    City = quote.DeliveryAddress.City,
                    StateOption = (StateOptions)Enum.Parse(typeof(StateOptions), quote.DeliveryAddress.State),
                    Zipcode = quote.DeliveryAddress.Zipcode,
                    DeliveryDate = quote.DeliveryDate,
                    GallonsRequested = quote.GallonsRequested,
                    SuggestedPrice = quote.SuggestedPrice
                };

                history.Add(vm);
            }

            return View(history);
        }

      
        public ActionResult SubmitSuccess()
        {
            return View();
        }
    }
}