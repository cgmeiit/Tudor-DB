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
    public class CurriculumsController : Controller
    {
        private TutorDBContext db = new TutorDBContext();

        // GET: Curriculums
        public ActionResult Index()
        {
            return View(db.Curriculums.ToList());
        }

        // GET: Curriculums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculums curriculums = db.Curriculums.Find(id);
            if (curriculums == null)
            {
                return HttpNotFound();
            }
            return View(curriculums);
        }

        // GET: Curriculums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curriculums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurricId,CurricName,CurricAuthor")] Curriculums curriculums)
        {
            if (ModelState.IsValid)
            {
                db.Curriculums.Add(curriculums);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curriculums);
        }

        // GET: Curriculums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculums curriculums = db.Curriculums.Find(id);
            if (curriculums == null)
            {
                return HttpNotFound();
            }
            return View(curriculums);
        }

        // POST: Curriculums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurricId,CurricName,CurricAuthor")] Curriculums curriculums)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curriculums).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curriculums);
        }

        // GET: Curriculums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculums curriculums = db.Curriculums.Find(id);
            if (curriculums == null)
            {
                return HttpNotFound();
            }
            return View(curriculums);
        }

        // POST: Curriculums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curriculums curriculums = db.Curriculums.Find(id);
            db.Curriculums.Remove(curriculums);
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
