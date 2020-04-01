using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHospital.Models;

namespace NHospital.Controllers
{
    public class AltaController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Alta
        public ActionResult Index()
        {
            var altas = db.Alta.Include(a => a.Ingreso);
            return View(altas.ToList());
        }

        // GET: Alta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alta alta = db.Alta.Find(id);
            if (alta == null)
            {
                return HttpNotFound();
            }
            return View(alta);
        }

        // GET: Alta/Create
        public ActionResult Create()
        {
            ViewBag.IdIngreso = new SelectList(db.Ingreso, "IdIngreso", "IdIngreso");
            return View();
        }

        // POST: Alta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlta,IdIngreso,FechaSalida,MontoTotal")] Alta alta)
        {
            if (ModelState.IsValid)
            {
                db.Alta.Add(alta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIngreso = new SelectList(db.Ingreso, "IdIngreso", "IdIngreso", alta.IdIngreso);
            return View(alta);
        }

        // GET: Alta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alta alta = db.Alta.Find(id);
            if (alta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIngreso = new SelectList(db.Ingreso, "IdIngreso", "IdIngreso", alta.IdIngreso);
            return View(alta);
        }

        // POST: Alta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlta,IdIngreso,FechaSalida,MontoTotal")] Alta alta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIngreso = new SelectList(db.Ingreso, "IdIngreso", "IdIngreso", alta.IdIngreso);
            return View(alta);
        }

        // GET: Alta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alta alta = db.Alta.Find(id);
            if (alta == null)
            {
                return HttpNotFound();
            }
            return View(alta);
        }

        // POST: Alta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alta alta = db.Alta.Find(id);
            db.Alta.Remove(alta);
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
