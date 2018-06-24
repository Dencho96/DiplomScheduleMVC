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
    public class SchedulesController : Controller
    {
        private Diplom_VovkEntities db = new Diplom_VovkEntities();

        // GET: Schedules
        public ActionResult Index()
        {
            var schedule = db.Schedule.Include(s => s.Auditory).Include(s => s.Day).Include(s => s.Group).Include(s => s.Pair).Include(s => s.Subject).Include(s => s.Teacher);
            return View(schedule.OrderBy(x => x.Group.GroupID));
        }
                     
        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create

        public ActionResult Create()
        {
            ViewBag.AuditoryID = new SelectList(db.Auditory, "AuditoryID", "AuditoryID");
            ViewBag.DayID = new SelectList(db.Day, "DayID", "DayName");
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName");
            ViewBag.PairID = new SelectList(db.Pair, "PairID", "PairID");
            ViewBag.SubjectID = new SelectList(db.Subject, "SubjectID", "SubjectName");
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "TeacherName");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "ScheduleID,DayID,AuditoryID,PairID,SubjectID,TeacherID,GroupID")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedule.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuditoryID = new SelectList(db.Auditory, "AuditoryID", "AuditoryID", schedule.AuditoryID);
            ViewBag.DayID = new SelectList(db.Day, "DayID", "DayName", schedule.DayID);
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", schedule.GroupID);
            ViewBag.PairID = new SelectList(db.Pair, "PairID", "PairID", schedule.PairID);
            ViewBag.SubjectID = new SelectList(db.Subject, "SubjectID", "SubjectName", schedule.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "TeacherName", schedule.TeacherID);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuditoryID = new SelectList(db.Auditory, "AuditoryID", "AuditoryID", schedule.AuditoryID);
            ViewBag.DayID = new SelectList(db.Day, "DayID", "DayName", schedule.DayID);
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", schedule.GroupID);
            ViewBag.PairID = new SelectList(db.Pair, "PairID", "PairID", schedule.PairID);
            ViewBag.SubjectID = new SelectList(db.Subject, "SubjectID", "SubjectName", schedule.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "TeacherName", schedule.TeacherID);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ScheduleID,DayID,AuditoryID,PairID,SubjectID,TeacherID,GroupID")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuditoryID = new SelectList(db.Auditory, "AuditoryID", "AuditoryID", schedule.AuditoryID);
            ViewBag.DayID = new SelectList(db.Day, "DayID", "DayName", schedule.DayID);
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", schedule.GroupID);
            ViewBag.PairID = new SelectList(db.Pair, "PairID", "PairID", schedule.PairID);
            ViewBag.SubjectID = new SelectList(db.Subject, "SubjectID", "SubjectName", schedule.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teacher, "TeacherID", "TeacherName", schedule.TeacherID);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedule.Find(id);
            db.Schedule.Remove(schedule);
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
