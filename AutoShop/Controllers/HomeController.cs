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
            ViewBag.Action = Action;
            return View();
        } 
        public ActionResult Index(int page = 1)  
        {
            var action = _db.Action.ToList();
            var pageSize = 3; // количество объектов на страницу        
            var actionPerPages = action.Skip((page - 1) * pageSize).Take(pageSize);
            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = action.Count()
            };
            var ivm = new IndexViewModelPage { PageInfo = pageInfo, Actions = actionPerPages };
            return View(ivm);
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