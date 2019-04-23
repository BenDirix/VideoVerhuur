using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class LogInFormViewModel
    {
        public string Naam { get; set; }
        public int? Postcode { get; set; }
    }
}