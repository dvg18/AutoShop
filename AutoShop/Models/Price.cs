using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Price
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public string description { get; set; }
    }
}