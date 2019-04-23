using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoVerhuur.Models;

namespace VideoVerhuur.Services
{
    public class VideoVerhuurService
    {
        public Klant GetKlant(string naam, int postcode)
        {
            using(var db = new VideoVerhuurEntities())
            {
                return db.Klanten.SingleOrDefault(k => k.Naam == naam && k.PostCode == postcode);
            }
        }

        public List<Genre> GetGenres()
        {
            using(var db = new VideoVerhuurEntities())
            {
                return db.Genres.ToList();
            }
        }
        public Genre GetGenre(int Id)
        {
            using(var db = new VideoVerhuurEntities())
            {
                return db.Genres.SingleOrDefault(g => g.GenreNr == Id);
            }
        }
        public List<Film> GetFilms(int genreId)
        {
            using(var db = new VideoVerhuurEntities())
            {
                return db.Films.Where(f => f.GenreNr == genreId).OrderBy(f => f.Titel).ToList();
            }
        }
        public Film GetFilm(int id)
        {
            using(var db = new VideoVerhuurEntities())
            {
                return db.Films.SingleOrDefault(f => f.BandNr == id);
            }
        }
        public void AddVerhuur(List<Verhuur> verhuurLijst)
        {
            using(var db = new VideoVerhuurEntities())
            {
                foreach(var verhuur in verhuurLijst)
                {
                    var film = db.Films.Single(f => f.BandNr == verhuur.BandNr);
                    film.InVoorraad -= 1;
                    film.TotaalVerhuurd += 1;
                    film.UitVoorraad += 1;
                    db.Verhuur.Add(verhuur);
                }
                    
                db.SaveChanges();
            }
        }
    }
}