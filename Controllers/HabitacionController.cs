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
    public class HabitacionController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Habitacion
        public ActionResult Index()
        {
            var habitacions = db.Habitacion.Include(h => h.TipoHabitacion);
            return View(habitacions.ToList());
        }

        // GET: Habitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // GET: Habitacion/Create
        public ActionResult Create()
        {
            ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre");

            ViewBag.HabitacionRepetida = false;  // Condiciones para validacion
        

            return View();
        }

        // POST: Habitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHabitacion,Numero,IdTipo,Precio")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {

                if (habitacion.Numero < 1)
                {
                    ViewBag.NumeroEsMenorQueUno = true;
                    ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
                    return View(habitacion);

                }




                db.Habitacion.Add(habitacion);


                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)  // Validando que el numero de habitacion no sea el mismo
                {

                    ViewBag.HabitacionRepetida = true;
                    ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
                    return View(habitacion);

                }






                return RedirectToAction("Index");
            }

            ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
            return View(habitacion);
        }

        // GET: Habitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.HabitacionRepetida = false;  // Condiciones para validacion

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
            return View(habitacion);
        }

        // POST: Habitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHabitacion,Numero,IdTipo,Precio")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habitacion).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)  // Validando que el numero de habitacion no sea el mismo
                {

                    ViewBag.HabitacionRepetida = true;
                    ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
                    return View(habitacion);

                }


                return RedirectToAction("Index");
            }
            ViewBag.IdTipo = new SelectList(db.TipoHabitacion, "IdTipo", "Nombre", habitacion.IdTipo);
            return View(habitacion);
        }

        // GET: Habitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacion.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Habitacion habitacion = db.Habitacion.Find(id);
            db.Habitacion.Remove(habitacion);
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
