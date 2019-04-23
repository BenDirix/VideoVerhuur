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
                return db.Klanten.Where(k => k.Naam == naam && k.PostCode == postcode).FirstOrDefault();
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
    }
}