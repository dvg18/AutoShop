using AutoShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext db1= new ApplicationDbContext();
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        private ApplicationUserManager UserManager {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        public ActionResult Users()
        {
            return View(UserManager.Users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string email)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                EditUsersModel model = new EditUsersModel { FIOName = user.FIOName, Visits = user.Visits, Discount = user.Discount, Email = user.Email };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditUsersModel model)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                user.FIOName = model.FIOName;
                user.Visits = model.Visits;
                user.Discount = model.Discount;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }
    }
    
}