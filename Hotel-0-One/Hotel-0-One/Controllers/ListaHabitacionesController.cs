using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_0_One.Models;

namespace Hotel_0_One.Controllers
{
    public class ListaHabitacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListaHabitaciones
        public ActionResult Index()
        {
            return View(db.ListaHabitaciones.ToList());
        }

        // GET: ListaHabitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaHabitaciones listaHabitaciones = db.ListaHabitaciones.Find(id);
            if (listaHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaHabitaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo,Descripción,PrecioXdía")] ListaHabitaciones listaHabitaciones)
        {
            if (ModelState.IsValid)
            {
                db.ListaHabitaciones.Add(listaHabitaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaHabitaciones listaHabitaciones = db.ListaHabitaciones.Find(id);
            if (listaHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(listaHabitaciones);
        }

        // POST: ListaHabitaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo,Descripción,PrecioXdía")] ListaHabitaciones listaHabitaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaHabitaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaHabitaciones listaHabitaciones = db.ListaHabitaciones.Find(id);
            if (listaHabitaciones == null)
            {
                return HttpNotFound();
            }
            return View(listaHabitaciones);
        }

        // POST: ListaHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaHabitaciones listaHabitaciones = db.ListaHabitaciones.Find(id);
            db.ListaHabitaciones.Remove(listaHabitaciones);
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
