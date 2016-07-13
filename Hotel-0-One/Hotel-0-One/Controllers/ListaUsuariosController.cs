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
    public class ListaUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListaUsuarios
        public ActionResult Index()
        {
            return View(db.ListaUsuarios.ToList());
        }

        // GET: ListaUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaUsuario listaUsuario = db.ListaUsuarios.Find(id);
            if (listaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(listaUsuario);
        }

        // GET: ListaUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Usuario,Contraseña")] ListaUsuario listaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.ListaUsuarios.Add(listaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaUsuario);
        }

        // GET: ListaUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaUsuario listaUsuario = db.ListaUsuarios.Find(id);
            if (listaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(listaUsuario);
        }

        // POST: ListaUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Usuario,Contraseña")] ListaUsuario listaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaUsuario);
        }

        // GET: ListaUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaUsuario listaUsuario = db.ListaUsuarios.Find(id);
            if (listaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(listaUsuario);
        }

        // POST: ListaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaUsuario listaUsuario = db.ListaUsuarios.Find(id);
            db.ListaUsuarios.Remove(listaUsuario);
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
