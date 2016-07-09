using System;
using System.Collections.Generic;

namespace AutoShop.Models
{
    public class InfoVisit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<AutoCar> AutoCars { get; set; }
        public InfoVisit()
        {
            AutoCars = new List<AutoCar>();
        } 

        //public int? AutoCarId { get; set; }
    }
}