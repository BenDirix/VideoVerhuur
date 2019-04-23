using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoVerhuur.Services;
using VideoVerhuur.Models;

namespace VideoVerhuur.Controllers
{
    [UserLoggedInFilter]
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
            var filmsVM = new FilmDetailViewModel
            {
                Films = _dbContext.GetFilms(genreId),
                Genre = _dbContext.GetGenre(genreId)
            };
            return View(filmsVM);
        }

        public ActionResult Huren(int id)
        {
            List<Film> winkelmandje = new List<Film>();
            if(Session["Winkelmandje"] != null)
                winkelmandje = (List<Film>)Session["Winkelmandje"];

            var film = _dbContext.GetFilm(id);
            if(film == null)
                return HttpNotFound();

            winkelmandje.Add(film);
            Session["Winkelmandje"] = winkelmandje;

            return RedirectToAction("Winkelmandje");
        }
        public ActionResult WinkelMandje()
        {
            if(Session["Winkelmandje"] == null)
                Session["Winkelmandje"] = new List<Film>();

            return View();
        }

        public ActionResult Verwijderen(int id)
        {
            var film = _dbContext.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public ActionResult VerwijderenBevestiging(int id)
        {
            //var teVerwijderenFilm = _dbContext.GetFilm(id);
            var winkelmandje = (List<Film>)Session["Winkelmandje"];
            var teVerwijderenFilm = winkelmandje.SingleOrDefault(f => f.BandNr == id);
            if(teVerwijderenFilm != null)
                winkelmandje.Remove(teVerwijderenFilm);

            return RedirectToAction("Winkelmandje");
        }

        public ActionResult Afrekenen()
        {
            if(((List<Film>)Session["Winkelmandje"]).Count == 0)
                return RedirectToAction("Winkelmandje");

            var klant = (Klant)Session["Klant"];
            var teHurenFilms = (List<Film>)Session["Winkelmandje"];
            var afrekenenVM = new AfrekenenViewModel
            {
                Films = teHurenFilms,
                Klant = klant
            };
            var verhuurLijst = new List<Verhuur>();
            foreach(var film in teHurenFilms)
            {
                var verhuur = new Verhuur
                {
                    KlantNr = klant.KlantNr,
                    BandNr = film.BandNr,
                    VerhuurDatum = DateTime.Now
                };
                verhuurLijst.Add(verhuur);
            }
            _dbContext.AddVerhuur(verhuurLijst);
            Session.Clear();
            return View(afrekenenVM);
        }
    }
}