using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoVerhuur.Services;
using VideoVerhuur.Models;

namespace VideoVerhuur.Controllers
{
    public class VerhuurController : Controller
    {
        private VideoVerhuurService _dbContext = new VideoVerhuurService();
        // GET: Verhuur
        public ActionResult Index()
        {
            var genres = _dbContext.GetGenres();
            if(Session["klant"] == null)
                return RedirectToAction("Index", "Home");
            return View(genres);
        }

        public ActionResult FilmDetails(int genreId)
        {
            var filmsVM = new FilmDetailViewModel
            {
                Films = _dbContext.GetFilms(genreId),
                Genre = _dbContext.GetGenre(genreId)
            };
            return View(filmsVM);
        }
    }
}