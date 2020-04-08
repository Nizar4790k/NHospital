using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using NHospital.Models;
using Rotativa;

namespace NHospital.Controllers
{
    public class AltaController : Controller
    {

        private static Alta alta;

        private Models.NHospital db = new Models.NHospital();

        // GET: Alta
        public ActionResult Index()
        {

            ViewBag.DateError = false;
            ViewBag.CodigoPacienteError = false;


            var altas = db.Alta.Include(a => a.Ingreso);
          

            string radio = Request.Form["radio"];


            if (radio == null)
            {
                return View(altas.ToList());
            }

            ViewBag.radio = radio;

            if (radio == "Fecha")
            {
                try
                {
                    DateTime fechaSalida = Convert.ToDateTime(Request.Form["fecha"]);
                    ViewBag.fechaSalida = fechaSalida;

                    var listaPorFecha = from alta in altas
                                        where alta.FechaSalida == fechaSalida
                                        select alta;

                    return (View(listaPorFecha));
                }
                catch(System.FormatException ex)
                {
                    ViewBag.DateError = true;

                    return View(altas);
                }
               
            }


            if (radio == "Paciente")
            {

                try
                {
                    int codigoPaciente = Convert.ToInt32(Request.Form["paciente"]);
                    ViewBag.codigoPaciente = codigoPaciente;

                    var listaPorPaciente = from alta in altas
                                           where alta.Ingreso.IdPaciente == codigoPaciente
                                           select alta;

                    return (View(listaPorPaciente));
                }
                catch (System.FormatException)
                {
                    ViewBag.CodigoPacienteError = true;
                    return View(altas);
                }
               
            }

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
            
            ViewBag.NoExisteIngreso = false;
            ViewBag.IngresoYaDespachado = false;
            ViewBag.FechaMenorQueIngreso = false;

            return View();
        }

        // POST: Alta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlta,IdIngreso,FechaSalida,MontoTotal")] Alta alta)
        {

            ViewBag.IdIngreso = new SelectList(db.Ingreso, "IdIngreso", "IdIngreso", alta.IdIngreso);


            ViewBag.NoExisteIngreso = false;
            ViewBag.IngresoYaDespachado = false;
            ViewBag.FechaMenorQueIngreso = false;


            if (ModelState.IsValid)

            {

               
            
                 var altasMedicas = db.Alta.ToList(); //Obteniendo la lista de todas las altas medicas



                alta.Ingreso = db.Ingreso.Find(alta.IdIngreso); // Obteniendo el ingreso a partir del codigo.

                if (alta.Ingreso == null)
                {
                    ViewBag.NoExisteIngreso = true;  // Viendo si el ingreso existe
                    return View(alta);

                }

                List<Alta> altaIngreso = (from alta2 in altasMedicas
                                          where alta2.IdIngreso == alta.IdIngreso // Aqui obteniendo la alta que tiene el ingreso especificado
                                          select alta2).ToList();

                foreach (Alta a in altaIngreso)
                {
                    if (a.IdIngreso == alta.IdIngreso)   // Verificando si el ingreso fue despachado
                    {
                        ViewBag.IngresoYaDespachado = true;
                        return View(alta);
                    }

                }




                DateTime fechaInicial = alta.Ingreso.FechaIngreso;   //Obteniendo las fechas iniciales y finales
                DateTime fechaFinal = alta.FechaSalida;

                int result = DateTime.Compare(fechaInicial, fechaFinal);


                if (result > 0)                                                         // Comparando las fechas
                {

                    ViewBag.FechaMenorQueIngreso = true;
                    return View(alta);
                }





                
                   
                alta.MontoTotal = (decimal)GetMontoEntreDosFechas(fechaInicial, fechaFinal, // Calculando el monto final
                   ((double)(alta.Ingreso.Habitacion.Precio))); 




                return RedirectToAction("Create2", alta);

                

               
            }



             return View(alta);

           
    
        }


      
     
        public ActionResult Create2(Alta alta)
        {

            alta.Ingreso = db.Ingreso.Find(alta.IdIngreso);

            AltaController.alta = alta;

          
            return View(alta);
        }

        [HttpPost]
        public ActionResult Create3()
        {

            AltaController.alta.Ingreso=null;



            db.Alta.Add(AltaController.alta);
          
            db.SaveChanges();

          

        

        

            
            return RedirectToAction("Index");
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

        
        private double GetMontoEntreDosFechas(DateTime fechaInicial, DateTime fechaFinal,double precioPorDia)
        {
            double diasFinales = (fechaFinal.Year*365.0)+(fechaFinal.Month*30.417)+ fechaFinal.Day;
            double diasIniciales  = (fechaInicial.Year * 365.0) + (fechaInicial.Month * 30.417) + fechaInicial.Day;

            double diasTotales = diasFinales - diasIniciales;

            return (precioPorDia * diasTotales);



        }
        

    }
}
