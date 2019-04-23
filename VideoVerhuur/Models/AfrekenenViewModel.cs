using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class AfrekenenViewModel
    {
        public List<Film> Films { get; set; }
        public Klant Klant { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal TotaalPrijs { get; set; }
    }
}