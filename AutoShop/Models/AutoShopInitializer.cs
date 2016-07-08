using System.Data.Entity;

namespace AutoShop.Models
{
    public class AutoShopInitializer : DropCreateDatabaseAlways<AutoShopContext>
      
    {
        protected override void Seed(AutoShopContext db)
        {
            var razvalShozhdenie = new Services
            {
                name = "Регулировка углов установки (сход-развал)",
                cost = 950,
                description = "Краткое описание"
            };
            var Ivanov = new Employees
            {
                fio = "Иванов Иван Иванович",
                jobProfile = "Механик",
                phone = "8-913-897-79-45"
            };
            var action1 = new Actia
            {
                name = "Бесплатная замена масла в ДВС",
                date = "01.06.2016-01.09.2016",
                description = "Бесплатно меняем масло при условии покупки масляного фильтра и моторного масла у наших партнеров"

            };
            var contact1 = new Contact
            {
                adress = "г. Омск, Енисейская, 1/1",
                phone = "+7(3812) 49-23-97",
            };
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
            db.Services.Add(razvalShozhdenie);
            db.Employees.Add(Ivanov);
            db.Action.Add(action1);
            db.Contact.Add(contact1);
            db.AutoCar.Add(autocar1);
            db.AutoCar.Add(autocar2);
            db.AutoCar.Add(autocar3);
            db.AutoCar.Add(autocar4);

            garazh1.AutoCar.Add(autocar1);
            garazh1.AutoCar.Add(autocar2);
            garazh2.AutoCar.Add(autocar3);
            garazh2.AutoCar.Add(autocar4);

            db.Garazh.Add(garazh1);
            db.Garazh.Add(garazh2);


            base.Seed(db);
        }

    }
}