using System;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Models
{
    public class InfoVisit
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime VisitDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}