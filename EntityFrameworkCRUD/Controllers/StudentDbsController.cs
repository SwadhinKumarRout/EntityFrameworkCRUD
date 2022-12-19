using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCRUD.Models;

namespace EntityFrameworkCRUD.Controllers
{
    public class StudentDbsController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: StudentDbs
        public ActionResult Index()
        {
            return View(db.StudentDbs.ToList());
        }

        // GET: StudentDbs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDb studentDb = db.StudentDbs.Find(id);
            if (studentDb == null)
            {
                return HttpNotFound();
            }
            return View(studentDb);
        }

        // GET: StudentDbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StdentId,StudentName,StudentBranch")] StudentDb studentDb)
        {
            if (ModelState.IsValid)
            {
                db.StudentDbs.Add(studentDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentDb);
        }

        // GET: StudentDbs/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDb studentDb = db.StudentDbs.Find(id);
            if (studentDb == null)
            {
                return HttpNotFound();
            }
            return View(studentDb);
        }

        // POST: StudentDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StdentId,StudentName,StudentBranch")] StudentDb studentDb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentDb);
        }

        // GET: StudentDbs/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDb studentDb = db.StudentDbs.Find(id);
            if (studentDb == null)
            {
                return HttpNotFound();
            }
            return View(studentDb);
        }

        // POST: StudentDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            StudentDb studentDb = db.StudentDbs.Find(id);
            db.StudentDbs.Remove(studentDb);
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
