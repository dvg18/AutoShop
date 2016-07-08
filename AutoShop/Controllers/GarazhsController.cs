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
    public class GarazhsController : Controller
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: Garazhs
        public ActionResult Index()
        {
            return View(db.Garazh.ToList());
        }

        // GET: Garazhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garazh garazh = db.Garazh.Find(id);
            if (garazh == null)
            {
                return HttpNotFound();
            }
            return View(garazh);
        }

        // GET: Garazhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garazhs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,busy")] Garazh garazh)
        {
            if (ModelState.IsValid)
            {
                db.Garazh.Add(garazh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garazh);
        }

        // GET: Garazhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garazh garazh = db.Garazh.Find(id);
            if (garazh == null)
            {
                return HttpNotFound();
            }
            return View(garazh);
        }

        // POST: Garazhs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,busy")] Garazh garazh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garazh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garazh);
        }

        // GET: Garazhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garazh garazh = db.Garazh.Find(id);
            if (garazh == null)
            {
                return HttpNotFound();
            }
            return View(garazh);
        }

        // POST: Garazhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garazh garazh = db.Garazh.Find(id);
            db.Garazh.Remove(garazh);
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
