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
    public class CitaController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Cita
        public ActionResult Index()
        {

            ViewBag.DateError = false;
            ViewBag.CodigoPacienteError = false;
            ViewBag.CodigoMedicoError = false;

            var citas = db.Cita.Include(c => c.Medico).Include(c => c.Paciente);

            string radio = Request.Form["radio"];



            if (radio == null)
            {
                return View(citas.ToList());
            }


            ViewBag.radio = radio;

            if (radio == "Paciente")
            {

                try
                {
                    int codigoPaciente = int.Parse(Request.Form["paciente"]);



                    ViewBag.codigoPaciente = codigoPaciente;

                    var citasPorPacientes = from cita in citas
                                            where cita.IdPaciente == codigoPaciente
                                            select cita;

                    return (View(citasPorPacientes));
                }
                catch (System.FormatException)
                {
                    ViewBag.CodigoPacienteError = true;
                    return View(citas);
                }

               
            }

            if (radio == "Medico")
            {
                try
                {
                    int codigoMedico = int.Parse(Request.Form["medico"]);

                    ViewBag.codigoMedico = codigoMedico;

                    var citasPorMedico = from cita in citas
                                         where cita.IdMedico == codigoMedico
                                         select cita;

                    return (View(citasPorMedico));

                }
                catch (System.FormatException)
                {
                    ViewBag.CodigoMedicoError = true;
                    return View(citas);
                }

             

            }

            if (radio == "Fecha")
            {
                try
                {
                    DateTime fechaCita = Convert.ToDateTime(Request.Form["fecha"]);

                    ViewBag.fechaCita = fechaCita;

                    var citaPorFecha = from cita in citas
                                       where cita.Fecha == fechaCita
                                       select cita;

                    return (View(citaPorFecha));

                } catch(System.FormatException ex)
                {
                    ViewBag.DateError = true;

                    return View(citas);
                }

            }






            return View(citas.ToList());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre");
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre");
            ViewBag.PacienteNoExiste = false;

            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,Fecha,IdPaciente,IdMedico")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);

                try
                {
                 
                    db.SaveChanges();
                }
                catch(System.Data.Entity.Infrastructure.DbUpdateException){
                    ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre", cita.IdMedico);
                    ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", cita.IdPaciente);
                    ViewBag.PacienteNoExiste = true;
                    return View(cita);
                }
               
                return RedirectToAction("Index");
            }
            ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre", cita.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", cita.IdPaciente);
            return View(cita);

        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.PacienteNoExiste = false;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre", cita.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", cita.IdPaciente);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,Fecha,IdPaciente,IdMedico")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    ViewBag.PacienteNoExiste = true;
                    ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre", cita.IdMedico);
                    ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", cita.IdPaciente);
                    return View(cita);

                }

                
                return RedirectToAction("Index");
            }
            ViewBag.IdMedico = new SelectList(db.Medico, "IdMedico", "Nombre", cita.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Nombre", cita.IdPaciente);
            return View(cita);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
