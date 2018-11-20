using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DateExample.DataModel;

namespace DateLocalisationExample.Controllers
{
    public class LocalDatesController : Controller
    {
        private Week11Context db = new Week11Context();

        // GET: LocalDates
        public ActionResult Index()
        {
            return View(db.Dates.ToList());
        }

        // GET: LocalDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDate localDate = db.Dates.Find(id);
            if (localDate == null)
            {
                return HttpNotFound();
            }
            return View(localDate);
        }

        // GET: LocalDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartDate,EndDate")] LocalDate localDate)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(localDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localDate);
        }

        // GET: LocalDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDate localDate = db.Dates.Find(id);
            if (localDate == null)
            {
                return HttpNotFound();
            }
            return View(localDate);
        }

        // POST: LocalDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StartDate,EndDate")] LocalDate localDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localDate);
        }

        // GET: LocalDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDate localDate = db.Dates.Find(id);
            if (localDate == null)
            {
                return HttpNotFound();
            }
            return View(localDate);
        }

        // POST: LocalDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalDate localDate = db.Dates.Find(id);
            db.Dates.Remove(localDate);
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
