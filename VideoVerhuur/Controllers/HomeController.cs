using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoVerhuur.Models;
using VideoVerhuur.Services;

namespace VideoVerhuur.Controllers
{
    public class HomeController : Controller
    {
        private VideoVerhuurService _dbContext = new VideoVerhuurService();
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            Session.Clear();
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
        
        public ActionResult Bevestiging(string naam, int postcode)
        {
            var klant = _dbContext.GetKlant(naam.ToUpper(), postcode);
            Session["klant"] = klant;
            if(klant == null)
                return View("Foutief");
            return View("Welkom");
        }
    }
}