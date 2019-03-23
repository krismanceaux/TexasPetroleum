using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.Models;

namespace TexasPetroleum.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult QuoteHistory()
        {
            QuoteContext dbContext = new QuoteContext();
            List<Client> clients = dbContext.Clients.ToList();
            dbContext = new QuoteContext();
            clients = dbContext.Clients.ToList();
            List<FuelQuote> history = clients.First().FuelQuotes.ToList();
            return View(history);
        }

        [Authorize]
        public ActionResult SubmitSuccess()
        {
            return View();
        }
    }
}