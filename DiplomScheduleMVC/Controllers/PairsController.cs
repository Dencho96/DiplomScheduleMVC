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
    public class PairsController : Controller
    {
        private Diplom_VovkEntities db = new Diplom_VovkEntities();

        // GET: Pairs
        public ActionResult Index()
        {
            return View(db.Pair.ToList());
        }

        // GET: Pairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pair pair = db.Pair.Find(id);
            if (pair == null)
            {
                return HttpNotFound();
            }
            return View(pair);
        }

        // GET: Pairs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PairID,PairNumber")] Pair pair)
        {
            if (ModelState.IsValid)
            {
                db.Pair.Add(pair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pair);
        }

        // GET: Pairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pair pair = db.Pair.Find(id);
            if (pair == null)
            {
                return HttpNotFound();
            }
            return View(pair);
        }

        // POST: Pairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PairID,PairNumber")] Pair pair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pair);
        }

        // GET: Pairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pair pair = db.Pair.Find(id);
            if (pair == null)
            {
                return HttpNotFound();
            }
            return View(pair);
        }

        // POST: Pairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pair pair = db.Pair.Find(id);
            db.Pair.Remove(pair);
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
