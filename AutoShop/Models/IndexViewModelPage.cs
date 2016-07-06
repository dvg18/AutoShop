using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class IndexViewModelPage
    {
        public IEnumerable<Action> Actions { get; set; }  
        public PageInfo PageInfo { get; set; }      
    }
}