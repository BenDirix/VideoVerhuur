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
    }
}