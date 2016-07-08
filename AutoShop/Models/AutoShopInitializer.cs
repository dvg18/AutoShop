﻿using System.Data.Entity;

namespace AutoShop.Models
{
    public class AutoShopInitializer : DropCreateDatabaseAlways<AutoShopContext>
      
    {
        protected override void Seed(AutoShopContext db)
        {
            var razvalShozhdenie = new Services
            {
                name = "Компьютерная регулировка «Развал-схождение»",
                cost = 950,
                description = "В нашей автомастерской проводится компьютерная регулировка «Сход-развал» на современном оборудовании TechnoVector. Рекомендуется проводить регулировку «Развал-схождение», каждые 10.000 км пробега. Это исключительно важно, поскольку не отрегулированный своевременно «Сход-развал» может привести к порче покрышек и к аварийной ситуации, особенно в зимний период эксплуатации."
            };
            var Diagnostika = new Services
            {
                name = "Компьютерная диагностика автомобилей",
                cost = 700,
                description = "Своевременная автодиагностика является обязательным условием длительной и безопасной эксплуатации автомобиля. Диагностика авто — услуга, на которой не нужно экономить ни время, ни деньги. Поскольку автомобиль является техническим средством повышенной опасности, тщательный контроль его состояния необходим и автолюбителям, и профессиональным водителям.Регулярная и качественная диагностика автомобиля позволяет получить объективную оценку функционирования всех систем на основе важнейших параметров работы автомобиля.Современные диагностические комплексы на основе компьютерной техники и программного обеспечения используются для тестирования автомобиля при возникновении поломок,для подготовки авто к ремонту,при проведении плановых техосмотров."
            };
            var Forsunki = new Services
            {
                name = "Ультразвуковая промывка и тестирование форсунок",
                cost = 400,
                description = "Радикальный способ и предназначен, в первую очередь для тех автомобилей которые никогда не проходили профилактической очистки инжекторов. Для начала форсунки демонтируются и производится их диагностика на специальном аппарате.Затем форсунки помещают в специальную ванну и под воздействием ультразвуковых колебаний рабочая жидкость как бы «бомбардирует» очищаемое изделие и срывает с нее частички грязи. После очистки производится контроль качества по тем же параметрам, что и до процедуры. Иногда, для достижение приемлемого качества, процесс очистки приходится повторять несколько раз."
            };
            var ZamenaMasla = new Services
            {
                name = "Замена масла",
                cost = 500,
                description = "Загрязнение масла в двигателе происходит непрерывно, что вызывает повышенный износ и преждевременный выход из строя трущихся деталей. От чистоты моторного масла зависят ресурс и надежность двигателя автомобиля, его мощность и экологические показатели."
            };
            var Shina = new Services
            {
                name = "Шиномонтаж и балансировка колес",
                cost = 950,
                description = "Высококачественные немецкие шиномонтажный и балансировочный станки, имеющиеся в нашей автомастерской, позволяют качественно и оперативно осуществить сборку-разборку, шиномонтаж и балансировку колеса.Каждый автовладелец рано или поздно сталкивается с необходимостью быстро найти хороший шиномонтаж и воспользоваться услугами шиномонтажа в удобное для себя время.Если вы также попали в число тех,кому необходим шиномонтаж в Омске,то мы рекомендуем вам воспользоваться нашими услугами.С нашей помощью вы сможете очень быстро привести в порядок шины, а это ремонт автошин,сезонная замена, балансировка колес."
            };
            
            var Guzikov = new Employees
            {
                fio = "Гузиков Даниил Родионович",
                jobProfile = "Мастер-универсал",
                phone = "8-904-378-86-56"
            };
            var Borodulin = new Employees
            {
                fio = "Бородулин Павел Николаевич",
                jobProfile = "Механик",
                phone = "8-923-445-32-11"
            };
            var Aspombitov = new Employees
            {
                fio = "Аспомбитов Сабыржан Олегович",
                jobProfile = "Шиномонтажник",
                phone = "8-923-446-21-51"
            };
            var Gerasimov = new Employees
            {
                fio = "Герасимов Дмитрий Викторович",
                jobProfile = "Слесарь",
                phone = "8-923-589-12-12"
            };
            var Ivanov = new Employees
            {
                fio = "Абишев Темирлан Меиргазиевич",
                jobProfile = "Стажер",
                phone = "8-913-777-77-77"
            };
            var action1 = new Actia
            {
                name = "Бесплатная замена масла в ДВС",
                date = "01.06.2016-01.09.2016",
                description = "Бесплатно меняем масло при условии покупки масляного фильтра и моторного масла у наших партнеров"

            };
            var action2 = new Actia
            {
                name = "Бесплатная замена колодок",
                date = "01.07.2016-01.08.2016",
                description = "Бесплатно меняем колодки при условии покупки колодок у наших партнеров"

            };

            var action3 = new Actia
            {
                name = "Скидка 10% на все услуги автосервиса",
                date = "22.08.2016-31.08.2016",
                description = "В связи с окончанием летнего сезона, в автосервисе \"У Иваныча\" проходят скидки на все услуги "

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
            db.Services.Add(Diagnostika);
            db.Services.Add(razvalShozhdenie);
            db.Services.Add(Forsunki);
            db.Services.Add(ZamenaMasla);
            db.Services.Add(Shina);
            db.Employees.Add(Guzikov);
            db.Employees.Add(Aspombitov);
            db.Employees.Add(Gerasimov);
            db.Employees.Add(Borodulin);
            db.Employees.Add(Ivanov);
            db.Action.Add(action1);
            db.Action.Add(action2);
            db.Action.Add(action3);
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