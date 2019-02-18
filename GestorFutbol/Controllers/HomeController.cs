using GestorFutbol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;





namespace GestorFutbol.Controllers
{
    public class HomeController : Controller
    {
        private GestorFutbolEntities db = new GestorFutbolEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult _CalendarioPartial()
        {
            var partido = db.Partido.Include(p => p.Equipo).Include(p => p.Equipo3);
            

            return PartialView(partido.ToList().Take(3));
        }
        public PartialViewResult _PosicionesPartial()
        {
            List<Equipo> equipos = db.Equipo.ToList();
            equipos.Sort(delegate (Equipo x, Equipo y)
            {
                return y.Puntos.CompareTo(x.Puntos);
            });
            return PartialView(equipos.Take(3));
        }
    }
}