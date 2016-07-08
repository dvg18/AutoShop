using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoShop.Models
{
    public class IndexViewModelPage
    {
        public IEnumerable<Services> Services { get; set; }  
        public PageInfo PageInfo { get; set; }      
    }
}