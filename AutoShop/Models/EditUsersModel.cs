using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class EditUsersModel
    {
        public string Email { get; set; }
        public string FIOName { get; set; }
        public string ClientsPhoneNumber { get; set; }
        public int Discount { get; set; }
        public int Visits { get; set; }
    }
}