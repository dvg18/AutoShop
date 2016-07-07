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
    public class ActiaController : Controller
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: Actias
        public ActionResult Index()
        {
            return View(db.Actia.ToList());
        }

        // GET: Actias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Actia.Find(id);
            if (actia == null)
            {
                return HttpNotFound();
            }
            return View(actia);
        }

        // GET: Actias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actias/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,date,description")] Actia actia)
        {
            if (ModelState.IsValid)
            {
                db.Actia.Add(actia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actia);
        }

        // GET: Actias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Actia.Find(id);
            if (actia == null)
            {
                return HttpNotFound();
            }
            return View(actia);
        }

        // POST: Actias/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,date,description")] Actia actia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actia);
        }

        // GET: Actias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Actia.Find(id);
            if (actia == null)
            {
                return HttpNotFound();
            }
            return View(actia);
        }

        // POST: Actias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actia actia = db.Actia.Find(id);
            db.Actia.Remove(actia);
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
