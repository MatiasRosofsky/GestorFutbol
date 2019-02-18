using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorFutbol.Models;

namespace GestorFutbol.Controllers
{
    public class Torneo_EquipoController : Controller
    {
        private GestorFutbolEntities db = new GestorFutbolEntities();

        // GET: Torneo_Equipo
        public ActionResult Index()
        {
            var torneo_Equipo = db.Torneo_Equipo.Include(t => t.Equipo).Include(t => t.Torneo);
            return View(torneo_Equipo.ToList());
        }

        // GET: Torneo_Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Equipo torneo_Equipo = db.Torneo_Equipo.Find(id);
            if (torneo_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(torneo_Equipo);
        }

        // GET: Torneo_Equipo/Create
        public ActionResult Create()
        {
            ViewBag.Equipo_ID = new SelectList(db.Equipo, "ID", "Nombre");
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre");
            return View();
        }

        // POST: Torneo_Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Equipo_ID,Torneo_ID")] Torneo_Equipo torneo_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Torneo_Equipo.Add(torneo_Equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Equipo_ID = new SelectList(db.Equipo, "ID", "Nombre", torneo_Equipo.Equipo_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Equipo.Torneo_ID);
            return View(torneo_Equipo);
        }

        // GET: Torneo_Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Equipo torneo_Equipo = db.Torneo_Equipo.Find(id);
            if (torneo_Equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Equipo_ID = new SelectList(db.Equipo, "ID", "Nombre", torneo_Equipo.Equipo_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Equipo.Torneo_ID);
            return View(torneo_Equipo);
        }

        // POST: Torneo_Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Equipo_ID,Torneo_ID")] Torneo_Equipo torneo_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo_Equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Equipo_ID = new SelectList(db.Equipo, "ID", "Nombre", torneo_Equipo.Equipo_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Equipo.Torneo_ID);
            return View(torneo_Equipo);
        }

        // GET: Torneo_Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Equipo torneo_Equipo = db.Torneo_Equipo.Find(id);
            if (torneo_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(torneo_Equipo);
        }

        // POST: Torneo_Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Torneo_Equipo torneo_Equipo = db.Torneo_Equipo.Find(id);
            db.Torneo_Equipo.Remove(torneo_Equipo);
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
