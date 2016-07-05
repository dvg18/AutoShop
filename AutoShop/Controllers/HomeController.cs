using AutoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//куча комментариев
//большая куча комментариев 
//my comment 
//ага
//edfbg
namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutoShopContext _db = new AutoShopContext();
        public ActionResult Action()
        {
            var Action = _db.Action.ToList();
            ViewBag.Action = Action;            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}