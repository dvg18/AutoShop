using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
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

            var infovisit1 = new InfoVisit { VisitDate = DateTime.Now};

            context.Infovisits.Add(infovisit1);

            var admin = new ApplicationUser { Email = "dumkailim@gmail.com", UserName = "dumkailim@gmail.com", FIOName = "Группа администраторов", ClientsPhoneNumber = "8 999 999 99 99" };
            string password = "U$t1l1msk";
            
            var result = userManager.Create(admin, password);

            var user = new ApplicationUser { Email = "aaa@aaa.aaa", UserName = "aaa@aaa.aaa", FIOName = "Некий пользователь", Visits = 0, Discount = 0, ClientsPhoneNumber = "8 912 345 67 89" };
            string userPassword = "aaa@AAA1";

            user.Infovisits.Add(infovisit1);

            var userResult = userManager.Create(user, userPassword);


            var autocar1 = new AutoCar
            {
                Name = "Autocar1",
                busy = true,

            };
            var autocar2 = new AutoCar
            {
                Name = "Autocar2",
                busy = true

            };
            var autocar3 = new AutoCar
            {
                Name = "Autocar3",
                busy = false

            };
            var autocar4 = new AutoCar
            {
                Name = "Autocar4",
                busy = false

            };
            var garazh1 = new Garazh
            {
                Name = "Garahz1",
                busy = true
            };

            var garazh2 = new Garazh
            {
                Name = "Garahz2",
                busy = false
            };

            context.AutoCars.Add(autocar1);
            context.AutoCars.Add(autocar2);
            context.AutoCars.Add(autocar3);
            context.AutoCars.Add(autocar4);

            infovisit1.AutoCars.Add(autocar1);


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