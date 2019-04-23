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
            
            return View(genres);
        }

        public ActionResult FilmDetails(int genreId)
        {
            if(Session["klant"] == null)
                return RedirectToAction("Index", "Home");

            var filmsVM = new FilmDetailViewModel
            {
                Films = _dbContext.GetFilms(genreId),
                Genre = _dbContext.GetGenre(genreId)
            };
            if(filmsVM.Genre == null)
                return HttpNotFound();

            return View(filmsVM);
        }

        public ActionResult WinkelMandje(int id)
        {
            if(Session["klant"] == null)
                return RedirectToAction("Index", "Home");

            List<Film> winkelmandje = new List<Film>();
            if(Session["Winkelmandje"] != null)            
                winkelmandje = (List<Film>)Session["Winkelmandje"];

            var film = _dbContext.GetFilm(id);
            if(film == null)
                return HttpNotFound();

            winkelmandje.Add(film);
            Session["Winkelmandje"] = winkelmandje;
            return View();
        }

        public ActionResult Verwijderen(int id)
        {
            return View();
        }
    }
}