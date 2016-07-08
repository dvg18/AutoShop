﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoShop.Models;

namespace AutoShop.Controllers
{
    public class ActiasController : Controller
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: Actias
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
                ViewBag.Administration = true;
            else ViewBag.Administration = false;
            return View(db.Action.ToList());
        }

        // GET: Actias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Action.Find(id);
            if (actia == null)
            {
                return HttpNotFound();
            }
            return View(actia);
        }

        // GET: Actias/Create
        [Authorize(Roles = "admin")]
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
                db.Action.Add(actia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actia);
        }

        // GET: Actias/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Action.Find(id);
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actia actia = db.Action.Find(id);
            if (actia == null)
            {
                return HttpNotFound();
            }
            return View(actia);
        }

        // POST: Actias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Actia actia = db.Action.Find(id);
            db.Action.Remove(actia);
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
