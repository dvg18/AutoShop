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
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            var autoCars = db.AutoCars.Include(a => a.InfoVisit);
            return View(autoCars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCars.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.InfoVisitId = new SelectList(db.Infovisits, "Id", "ApplicationUserId");
            return View();
        }

        // POST: Cars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,busy,InfoVisitId")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.AutoCars.Add(autoCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InfoVisitId = new SelectList(db.Infovisits, "Id", "ApplicationUserId", autoCar.InfoVisitId);
            return View(autoCar);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCars.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.InfoVisitId = new SelectList(db.Infovisits, "Id", "ApplicationUserId", autoCar.InfoVisitId);
            return View(autoCar);
        }

        // POST: Cars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,busy,InfoVisitId")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InfoVisitId = new SelectList(db.Infovisits, "Id", "ApplicationUserId", autoCar.InfoVisitId);
            return View(autoCar);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCars.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoCar autoCar = db.AutoCars.Find(id);
            db.AutoCars.Remove(autoCar);
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
