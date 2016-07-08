using System;

namespace AutoShop.Models
{
    public class InfoVisit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}