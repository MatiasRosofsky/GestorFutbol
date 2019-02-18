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
    public class PartidosController : Controller
    {
        private GestorFutbolEntities db = new GestorFutbolEntities();

        // GET: Partidos
        public ActionResult Index()
        {
            var partido = db.Partido.Include(p => p.Equipo).Include(p => p.Equipo3);
            return View(partido.ToList());
        }

        // GET: Partidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partidos/Create
        public ActionResult Create()
        {
            ViewBag.Equipo1 = new SelectList(db.Equipo, "ID", "Nombre");
            ViewBag.Equipo2 = new SelectList(db.Equipo, "ID", "Nombre");
            return View();
        }

        // POST: Partidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fecha,Equipo1,Equipo2,Direccion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Partido.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Equipo1 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo1);
            ViewBag.Equipo2 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo2);
            return View(partido);
        }

        // GET: Partidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Equipo1 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo1);
            ViewBag.Equipo2 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo2);
            return View(partido);
        }

        // POST: Partidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fecha,Equipo1,Equipo2,Direccion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Equipo1 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo1);
            ViewBag.Equipo2 = new SelectList(db.Equipo, "ID", "Nombre", partido.Equipo2);
            return View(partido);
        }

        // GET: Partidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partido partido = db.Partido.Find(id);
            db.Partido.Remove(partido);
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
