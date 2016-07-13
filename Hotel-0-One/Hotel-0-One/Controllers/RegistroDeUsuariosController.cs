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
    public class RegistroDeUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegistroDeUsuarios
        public ActionResult Index()
        {
            return View(db.RegistroDeUsuarios.ToList());
        }

        // GET: RegistroDeUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeUsuarios registroDeUsuarios = db.RegistroDeUsuarios.Find(id);
            if (registroDeUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(registroDeUsuarios);
        }

        // GET: RegistroDeUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroDeUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Usuario,Contraseña,RUN,Email")] RegistroDeUsuarios registroDeUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.RegistroDeUsuarios.Add(registroDeUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registroDeUsuarios);
        }

        // GET: RegistroDeUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeUsuarios registroDeUsuarios = db.RegistroDeUsuarios.Find(id);
            if (registroDeUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(registroDeUsuarios);
        }

        // POST: RegistroDeUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Usuario,Contraseña,RUN,Email")] RegistroDeUsuarios registroDeUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroDeUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registroDeUsuarios);
        }

        // GET: RegistroDeUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeUsuarios registroDeUsuarios = db.RegistroDeUsuarios.Find(id);
            if (registroDeUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(registroDeUsuarios);
        }

        // POST: RegistroDeUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroDeUsuarios registroDeUsuarios = db.RegistroDeUsuarios.Find(id);
            db.RegistroDeUsuarios.Remove(registroDeUsuarios);
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
