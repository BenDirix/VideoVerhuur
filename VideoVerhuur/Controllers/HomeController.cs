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
        
        public ActionResult Aanmelden(string naam, int postcode = 0)
        {
            var klant = _dbContext.GetKlant(naam.ToUpper(), postcode);
            Session["klant"] = klant;
            if(klant == null)
                return View("Foutief");
            return View("Welkom");
        }

        public ActionResult Uitloggen()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public new RedirectToRouteResult RedirectToAction(string action, string controller)
        {
            return base.RedirectToAction(action, controller);
        }
    }
}