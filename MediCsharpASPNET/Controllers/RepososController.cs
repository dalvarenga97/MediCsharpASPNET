using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediCsharpASPNET.Models;

namespace MediCsharpASPNET.Controllers
{
    public class RepososController : Controller
    {
        private MediCsharp2Entities1 db = new MediCsharp2Entities1();

        // GET: Reposos
        public ActionResult Index()
        {
            var reposo = db.Reposo.Include(r => r.Doctor).Include(r => r.Paciente);
            return View(reposo.ToList());
        }

        // GET: Reposos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reposo reposo = db.Reposo.Find(id);
            if (reposo == null)
            {
                return HttpNotFound();
            }
            return View(reposo);
        }

        // GET: Reposos/Create
        public ActionResult Create()
        {
            ViewBag.Doctor_Id = new SelectList(db.Doctor, "Id", "NombreDoctor");
            ViewBag.Paciente_Id = new SelectList(db.Paciente, "Id", "NombrePaciente");
            return View();
        }

        // POST: Reposos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Reposo,Doctor_Id,Paciente_Id,FechaDesde,FechaHasta")] Reposo reposo)
        {
            if (ModelState.IsValid)
            {
                db.Reposo.Add(reposo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor_Id = new SelectList(db.Doctor, "Id", "NombreDoctor", reposo.Doctor_Id);
            ViewBag.Paciente_Id = new SelectList(db.Paciente, "Id", "NombrePaciente", reposo.Paciente_Id);
            return View(reposo);
        }

        // GET: Reposos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reposo reposo = db.Reposo.Find(id);
            if (reposo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor_Id = new SelectList(db.Doctor, "Id", "NombreDoctor", reposo.Doctor_Id);
            ViewBag.Paciente_Id = new SelectList(db.Paciente, "Id", "NombrePaciente", reposo.Paciente_Id);
            return View(reposo);
        }

        // POST: Reposos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reposo,Doctor_Id,Paciente_Id,FechaDesde,FechaHasta")] Reposo reposo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reposo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor_Id = new SelectList(db.Doctor, "Id", "NombreDoctor", reposo.Doctor_Id);
            ViewBag.Paciente_Id = new SelectList(db.Paciente, "Id", "NombrePaciente", reposo.Paciente_Id);
            return View(reposo);
        }

        // GET: Reposos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reposo reposo = db.Reposo.Find(id);
            if (reposo == null)
            {
                return HttpNotFound();
            }
            return View(reposo);
        }

        // POST: Reposos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reposo reposo = db.Reposo.Find(id);
            db.Reposo.Remove(reposo);
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
