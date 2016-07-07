using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AutoShop.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { Email = "dumkailim@gmail.com", UserName = "dumkailim@gmail.com" };
            string password = "U$t1l1msk";
            var result = userManager.Create(admin, password);

            var user = new ApplicationUser { Email = "aaa@aaa.aaa", UserName = "aaa@aaa.aaa" };
            string userPassword = "aaa@AAA1";
            var userResult = userManager.Create(user, userPassword);

            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                //userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(user.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}