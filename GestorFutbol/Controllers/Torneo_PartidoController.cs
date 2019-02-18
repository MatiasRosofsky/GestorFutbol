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
    public class Torneo_PartidoController : Controller
    {
        private GestorFutbolEntities db = new GestorFutbolEntities();

        // GET: Torneo_Partido
        public ActionResult Index()
        {
            var torneo_Partido = db.Torneo_Partido.Include(t => t.Partido).Include(t => t.Torneo);
            return View(torneo_Partido.ToList());
        }

        // GET: Torneo_Partido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Partido torneo_Partido = db.Torneo_Partido.Find(id);
            if (torneo_Partido == null)
            {
                return HttpNotFound();
            }
            return View(torneo_Partido);
        }

        // GET: Torneo_Partido/Create
        public ActionResult Create()
        {
            ViewBag.Partido_ID = new SelectList(db.Partido, "ID", "Direccion");
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre");
            return View();
        }

        // POST: Torneo_Partido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Torneo_ID,Partido_ID")] Torneo_Partido torneo_Partido)
        {
            if (ModelState.IsValid)
            {
                db.Torneo_Partido.Add(torneo_Partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Partido_ID = new SelectList(db.Partido, "ID", "Direccion", torneo_Partido.Partido_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Partido.Torneo_ID);
            return View(torneo_Partido);
        }

        // GET: Torneo_Partido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Partido torneo_Partido = db.Torneo_Partido.Find(id);
            if (torneo_Partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Partido_ID = new SelectList(db.Partido, "ID", "Direccion", torneo_Partido.Partido_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Partido.Torneo_ID);
            return View(torneo_Partido);
        }

        // POST: Torneo_Partido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Torneo_ID,Partido_ID")] Torneo_Partido torneo_Partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo_Partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Partido_ID = new SelectList(db.Partido, "ID", "Direccion", torneo_Partido.Partido_ID);
            ViewBag.Torneo_ID = new SelectList(db.Torneo, "ID", "Nombre", torneo_Partido.Torneo_ID);
            return View(torneo_Partido);
        }

        // GET: Torneo_Partido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo_Partido torneo_Partido = db.Torneo_Partido.Find(id);
            if (torneo_Partido == null)
            {
                return HttpNotFound();
            }
            return View(torneo_Partido);
        }

        // POST: Torneo_Partido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Torneo_Partido torneo_Partido = db.Torneo_Partido.Find(id);
            db.Torneo_Partido.Remove(torneo_Partido);
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
