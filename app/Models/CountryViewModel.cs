using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public BaseInf Inf { get; set; }
        public IEnumerable<Showplace> Places { get; set; }
    }
}