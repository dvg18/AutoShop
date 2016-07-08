using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoShop.Models;

namespace AutoShop.Controllers
{
    public class AutoCarsController : Controller
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: AutoCars
        public ActionResult Index()
        {
            var autoCar = db.AutoCar.Include(a => a.Garazh);
            return View(autoCar.ToList());
        }

        // GET: AutoCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // GET: AutoCars/Create
        public ActionResult Create()
        {
            ViewBag.GarazhId = new SelectList(db.Garazh, "Id", "Name");
            return View();
        }

        // POST: AutoCars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,busy,GarazhId")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.AutoCar.Add(autoCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarazhId = new SelectList(db.Garazh, "Id", "Name", autoCar.GarazhId);
            return View(autoCar);
        }

        // GET: AutoCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.GarazhId = new SelectList(db.Garazh, "Id", "Name", autoCar.GarazhId);
            return View(autoCar);
        }

        // POST: AutoCars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,busy,GarazhId")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarazhId = new SelectList(db.Garazh, "Id", "Name", autoCar.GarazhId);
            return View(autoCar);
        }

        // GET: AutoCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // POST: AutoCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoCar autoCar = db.AutoCar.Find(id);
            db.AutoCar.Remove(autoCar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
