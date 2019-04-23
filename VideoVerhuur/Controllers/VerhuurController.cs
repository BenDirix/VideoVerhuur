using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoVerhuur.Controllers
{
    public class VerhuurController : Controller
    {
        // GET: Verhuur
        public ActionResult Index()
        {
            return View();
        }
    }
}