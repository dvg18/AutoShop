using System.Data.Entity;

namespace AutoShop.Models
{
    public class AutoShopInitializer : DropCreateDatabaseIfModelChanges<AutoShopContext>
      
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
                adress = "г. Томск, ул.Тимакова, 21 ст8",
                phone = "8-3822-77-77-77",
            };
            db.Services.Add(razvalShozhdenie);
            db.Employees.Add(Ivanov);
            db.Action.Add(action1);
            db.Contact.Add(contact1);
            base.Seed(db);
        }

    }
}