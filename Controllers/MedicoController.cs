﻿using System;
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
    public class MedicoController : Controller
    {
        private Models.NHospital db = new Models.NHospital();

        // GET: Medico
        public ActionResult Index()
        {
            return View(db.Medico.ToList());
        }

        // GET: Medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMedico,Nombre,Exequatur,Especialidad")] Medico medico,HttpPostedFileBase exequatur)
        {



          

            if (ModelState.IsValid && exequatur!=null)
            {
  
                GuardarExecuatur(exequatur,medico);
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMedico,Nombre,Exequatur,Especialidad")] Medico medico, HttpPostedFileBase exequatur)
        {
            if (ModelState.IsValid && exequatur!=null)
            {
                GuardarExecuatur(exequatur, medico);
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medico.Find(id);
            db.Medico.Remove(medico);
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

        private void GuardarExecuatur(HttpPostedFileBase file,Medico medico)
        {
         
    
           medico.Exequatur = "Exequatur" + Guid.NewGuid().ToString() + ".pdf";
        
           

            file.SaveAs(Server.MapPath("/Exequatur/" + medico.Exequatur));
        }

    }
}
