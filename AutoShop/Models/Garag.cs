using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Garazh
    {
        public int Id { get; set; } 
        public string Name { get; set; }       
        public  bool busy { get; set; }

        public ICollection<AutoCar> AutoCar { get; set; }
        public Garazh()
        {
            AutoCar = new List<AutoCar>();
        }
    
    }
}