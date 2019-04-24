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
            var loginVM = new LogInFormViewModel();
            return View(loginVM);
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
        
        public ActionResult Aanmelden(LogInFormViewModel loginVM)
        {
            if(loginVM.Naam == null || loginVM.Postcode == null)
                return View("FoutieveLogin");
            var user = _dbContext.GetKlant(loginVM.Naam.ToUpper(), loginVM.Postcode);            
            if(user == null)
                return View("FoutieveLogin");
            Session["klant"] = user;
            return View("Welkom");
        }

        public ActionResult Uitloggen()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}