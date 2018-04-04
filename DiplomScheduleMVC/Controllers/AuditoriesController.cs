using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomScheduleMVC.Models;

namespace DiplomScheduleMVC.Controllers
{
    public class AuditoriesController : Controller
    {
        private student05Entities db = new student05Entities();

        // GET: Auditories
        public ActionResult Index()
        {
            return View(db.Auditory.ToList());
        }

        // GET: Auditories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditory.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // GET: Auditories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditoryID,AuditoryNumber")] Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                db.Auditory.Add(auditory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditory);
        }

        // GET: Auditories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditory.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // POST: Auditories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditoryID,AuditoryNumber")] Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditory);
        }

        // GET: Auditories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditory auditory = db.Auditory.Find(id);
            if (auditory == null)
            {
                return HttpNotFound();
            }
            return View(auditory);
        }

        // POST: Auditories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditory auditory = db.Auditory.Find(id);
            db.Auditory.Remove(auditory);
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
