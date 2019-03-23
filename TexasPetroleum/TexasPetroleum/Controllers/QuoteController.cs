<<<<<<< HEAD
﻿using TexasPetroleum.DAL;
using TexasPetroleum.Models;
using System;
=======
﻿using System;
>>>>>>> 210021c846258e352b59940db0ca1295f3469d60
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum;

namespace FuelRatePredictor.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult QuoteHistory()
        {
            QuoteContext dbContext = new QuoteContext();
            List<Client> clients = dbContext.Clients.ToList();
            dbContext = new QuoteContext();
            clients = dbContext.Clients.ToList();
            List<FuelQuote> history = clients.First().FuelQuotes.ToList();
            return View(history);
        }

      
        public ActionResult SubmitSuccess()
        {
            return View();
        }
    }
}