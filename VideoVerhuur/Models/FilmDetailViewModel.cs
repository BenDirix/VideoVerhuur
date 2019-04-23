using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class FilmDetailViewModel
    {
        public List<Film> Films { get; set; }
        public Genre Genre { get; set; }
    }
}