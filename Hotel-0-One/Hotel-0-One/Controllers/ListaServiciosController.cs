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
    public class ListaServiciosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListaServicios
        public ActionResult Index()
        {
            return View(db.ListaServicios.ToList());
        }

        // GET: ListaServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaServicios listaServicios = db.ListaServicios.Find(id);
            if (listaServicios == null)
            {
                return HttpNotFound();
            }
            return View(listaServicios);
        }

        // GET: ListaServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo,PrecioXdia,Descripcion")] ListaServicios listaServicios)
        {
            if (ModelState.IsValid)
            {
                db.ListaServicios.Add(listaServicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaServicios);
        }

        // GET: ListaServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaServicios listaServicios = db.ListaServicios.Find(id);
            if (listaServicios == null)
            {
                return HttpNotFound();
            }
            return View(listaServicios);
        }

        // POST: ListaServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo,PrecioXdia,Descripcion")] ListaServicios listaServicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaServicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaServicios);
        }

        // GET: ListaServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaServicios listaServicios = db.ListaServicios.Find(id);
            if (listaServicios == null)
            {
                return HttpNotFound();
            }
            return View(listaServicios);
        }

        // POST: ListaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaServicios listaServicios = db.ListaServicios.Find(id);
            db.ListaServicios.Remove(listaServicios);
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
