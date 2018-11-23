using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DateExample.DataModel;
using PagedList;

namespace DateLocalisationExample.Controllers
{
    public class StudentsController : Controller
    {
        private Week11Context db = new Week11Context();

        // GET: Students
        public ActionResult Index(string sort, string search, int? page)
        {
            ViewBag.SnameSort = String.IsNullOrEmpty(sort) ? "sname_desc" : string.Empty;
            ViewBag.FnameSort = sort == "fname" ? "fname_desc" : "fname";

            ViewBag.CurrentSearch = search;
            IQueryable<Student> students = db.Students;

            if (!String.IsNullOrEmpty(search))
            {
                students = students.Where(
                    s => s.Firstname.StartsWith(search) || s.Surname.StartsWith(search));
            }
            switch (sort)
            {
                case "sname_desc":
                    students = students.OrderByDescending(s => s.Surname).ThenBy(s => s.Firstname);
                    break;
                case "fname":
                    students = students.OrderBy(s => s.Firstname).ThenBy(s => s.Surname);
                    break;
                case "fname_desc":
                    students = students.OrderByDescending(s => s.Firstname).ThenBy(s => s.Surname);
                    break;
                default:
                    students = students.OrderBy(s => s.Surname).ThenBy(s => s.Firstname);
                    break;
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            return View(students.ToPagedList(pageNumber, pageSize));
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentNumber,Firstname,Surname,DateRegistered")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentNumber,Firstname,Surname,DateRegistered")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
