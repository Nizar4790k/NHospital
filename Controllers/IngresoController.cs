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
    public class IngresoController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Ingreso
        public ActionResult Index()
        {
            var ingresoes = db.Ingreso.Include(i => i.Habitacion).Include(i => i.Paciente);
            return View(ingresoes.ToList());
        }

        // GET: Ingreso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            return View(ingreso);
        }

        // GET: Ingreso/Create
        public ActionResult Create()
        {
            ViewBag.IdHabitacion = new SelectList(db.Habitacion, "IdHabitacion", "Numero");
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre");
            return View();
        }

        // POST: Ingreso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIngreso,FechaIngreso,IdHabitacion,IdPaciente")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Ingreso.Add(ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHabitacion = new SelectList(db.Habitacion, "IdHabitacion", "Numero", ingreso.IdHabitacion);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", ingreso.IdPaciente);
            return View(ingreso);
        }

        // GET: Ingreso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHabitacion = new SelectList(db.Habitacion, "IdHabitacion", "Numero", ingreso.IdHabitacion);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", ingreso.IdPaciente);
            return View(ingreso);
        }

        // POST: Ingreso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIngreso,FechaIngreso,IdHabitacion,IdPaciente")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHabitacion = new SelectList(db.Habitacion, "IdHabitacion", "Numero", ingreso.IdHabitacion);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", ingreso.IdPaciente);
            return View(ingreso);
        }

        // GET: Ingreso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            return View(ingreso);
        }

        // POST: Ingreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingreso ingreso = db.Ingreso.Find(id);
            db.Ingreso.Remove(ingreso);
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
