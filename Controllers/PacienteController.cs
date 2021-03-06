﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHospital.Models;
using Rotativa;

namespace NHospital.Controllers
{
    public class PacienteController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Paciente

         
        public ActionResult Index()
        {

           
            ViewBag.radio = "";


            List<Paciente> listaPacientes = db.Paciente.ToList();



            string radio = Request.Form["radio"];


            if (radio == null)
            {

                return (View(listaPacientes));
            }

            ViewBag.radio = radio;


            if (radio == "Nombre")
            {
                string nombre = Request.Form["nombre"];
                ViewBag.nombrePaciente = nombre;


                var listaPorNombre = from paciente in listaPacientes
                                     where paciente.Nombre == nombre
                                     select paciente;


                return View(listaPorNombre);
            }
            else if (radio == "Asegurado")
            {


                string value = Request.Form["asegurado"];
                ViewBag.asegurado = value;


                bool esAsegurado = value == "true,false";






                var listaPorAsegurado = from paciente in listaPacientes
                                        where paciente.Asegurado == esAsegurado
                                        select paciente;


                return View(listaPorAsegurado);


            }
            else if (radio == "Cedula")

            {

                string cedula = Request.Form["cedula"];

                ViewBag.cedulaPaciente = cedula;



                var listaPorCedula = from paciente in listaPacientes
                                     where paciente.Cedula == cedula
                                     select paciente;

                return View(listaPorCedula);

            }


            return (View(listaPacientes));


        }

        
      


       






        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.CedulaDuplicada = false;

            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,Nombre,Cedula,Asegurado")] Paciente paciente)
        {

            ViewBag.CedulaDuplicada = false;

            if (ModelState.IsValid)
            {
                

               

                try
                {
                    db.Paciente.Add(paciente);
                    db.SaveChanges();

                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    ViewBag.CedulaDuplicada = true;
                    return View(paciente);

                }

            
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.CedulaDuplicada = false;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,Nombre,Cedula,Asegurado")] Paciente paciente)
        {
            ViewBag.CedulaDuplicada = false; 

            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;


                try
                {
               
                    db.SaveChanges();

                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    ViewBag.CedulaDuplicada = true;
                    return View(paciente);

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
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
