using AutoShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

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
        public ActionResult Visits()
        {
            var users = db1.Infovisits.Include(p => p.ApplicationUser);
            return View(users.ToList());
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
                EditUsersModel model = new EditUsersModel { FIOName = user.FIOName, Visits = user.Visits, Discount = user.Discount, Email = user.Email, ClientsPhoneNumber = user.ClientsPhoneNumber };
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
                user.ClientsPhoneNumber = model.ClientsPhoneNumber;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Users", "Roles");
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
        [HttpGet]
        public async Task<ActionResult> Delete(string email)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                EditUsersModel model = new EditUsersModel { Email = user.Email };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(EditUsersModel model)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Users", "Roles");
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult EditVisits(int? id)
        {
            
            // ApplicationUser user = await UserManager.FindByEmailAsync(email);
            if (id == null) {
                return HttpNotFound();
            }
            var infovisit = db1.Infovisits.Find(id);

            if (infovisit != null)
            {
                var users = new SelectList(db1.Users, "Id", "Email", infovisit.ApplicationUserId);
                ViewBag.Users = users;
                return View(infovisit);
                //EditUsersModel model = new EditUsersModel { FIOName = user.FIOName, Visits = user.Visits, Discount = user.Discount, Email = user.Email, ClientsPhoneNumber = user.ClientsPhoneNumber };
                //return View(model);
            }
            return RedirectToAction("Visits");
        }
        [HttpPost]
        public ActionResult EditVisits(InfoVisit infovisit)
        {
            db1.Entry(infovisit).State = EntityState.Modified;
            db1.SaveChanges();
            return RedirectToAction("Visits");
        }



        [HttpGet]
        public ActionResult DeleteVisits(int? id)
        {
            var infovisit = db1.Infovisits.Find(id);
            if (infovisit == null)
            {
                return HttpNotFound();
            }
            return View(infovisit);
        }

        [HttpPost]
        [ActionName("DeleteVisits")]
        public ActionResult DeleteConfirmedVisits(int? id)
        {
            var infovisit = db1.Infovisits.Find(id);
            db1.Infovisits.Remove(infovisit);
            db1.SaveChanges();

            return RedirectToAction("Visits");
        }
    }
    
}