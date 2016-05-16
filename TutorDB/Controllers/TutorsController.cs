using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorDB.Models;

namespace TutorDB.Controllers
{
    public class TutorsController : Controller
    {
        private TutorDBContext db = new TutorDBContext();

        // GET: Tutors
        public ActionResult Index()
        {
            return View(db.Tutors.ToList());
        }

        // GET: Tutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TutorId,FirstName,LastName")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                db.Tutors.Add(tutors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutors);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TutorId,FirstName,LastName")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutors);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutors tutors = db.Tutors.Find(id);
            db.Tutors.Remove(tutors);
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
