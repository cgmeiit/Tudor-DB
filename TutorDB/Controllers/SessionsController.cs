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
    public class SessionsController : Controller
    {
        private TutorDBContext db = new TutorDBContext();

        // GET: Sessions
        public ActionResult Index()
        {
            var sessions = db.Sessions.Include(s => s.Curriculum).Include(s => s.Tutor);
            return View(sessions.ToList());
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            ViewBag.CurricId = new SelectList(db.Curriculums, "CurricId", "CurricName");
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "FirstName");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionsId,SessionTopic,Date,CurricId,TutorId")] Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(sessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurricId = new SelectList(db.Curriculums, "CurricId", "CurricName", sessions.CurricId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "FirstName", sessions.TutorId);
            return View(sessions);
        }

        // GET: Sessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurricId = new SelectList(db.Curriculums, "CurricId", "CurricName", sessions.CurricId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "FirstName", sessions.TutorId);
            return View(sessions);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionsId,SessionTopic,Date,CurricId,TutorId")] Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurricId = new SelectList(db.Curriculums, "CurricId", "CurricName", sessions.CurricId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "FirstName", sessions.TutorId);
            return View(sessions);
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessions sessions = db.Sessions.Find(id);
            db.Sessions.Remove(sessions);
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
