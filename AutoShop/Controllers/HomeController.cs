using AutoShop.Models;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult CreateAction()
        {
            return View();
        }
        public ActionResult CreateServices()
        {
            return View();
        }
        public ActionResult CreateEmployees()
        {
            return View();
        }
        public ActionResult Employees()
        {
            var Employees = _db.Employees.ToList();
            ViewBag.Employees = Employees;
            return View();
        }
        public ActionResult Services()
        {
            var Services = _db.Services.ToList();
            ViewBag.Services = Services;
            return View();
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}