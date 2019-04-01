using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasPetroleum.AuthData;
using TexasPetroleum.DAL;

namespace FuelRatePredictor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            if(id == 1)
            {
                if (ApplicationSession.Username != "")
                {
                    ApplicationSession.Username = "";
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AuthAttribute]
        public ActionResult UserHub()
        {
            return View();
        }
    }
}