using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class AutoCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool busy { get; set; }

        public int? GarazhId { get; set; }
        public Garazh Garazh { get; set; }
    }
}