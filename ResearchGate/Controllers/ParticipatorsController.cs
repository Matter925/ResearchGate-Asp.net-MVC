using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResearchGate.Models;

namespace ResearchGate.Controllers
{
    public class ParticipatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Participators
        public ActionResult Index()
        {
            var participators = db.Participators.Include(p => p.Post);
            return View(participators.ToList());
        }

        // GET: Participators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participators participators = db.Participators.Find(id);
            if (participators == null)
            {
                return HttpNotFound();
            }
            return View(participators);
        }

        // GET: Participators/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.Papers, "ID", "Title");
            return View();
        }

        // POST: Participators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,userId,PostID")] Participators participators)
        {
            if (ModelState.IsValid)
            {
                db.Participators.Add(participators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.Papers, "ID", "Title", participators.PostID);
            return View(participators);
        }

        // GET: Participators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participators participators = db.Participators.Find(id);
            if (participators == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.Papers, "ID", "Title", participators.PostID);
            return View(participators);
        }

        // POST: Participators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,userId,PostID")] Participators participators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.Papers, "ID", "Title", participators.PostID);
            return View(participators);
        }

        // GET: Participators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participators participators = db.Participators.Find(id);
            if (participators == null)
            {
                return HttpNotFound();
            }
            return View(participators);
        }

        // POST: Participators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participators participators = db.Participators.Find(id);
            db.Participators.Remove(participators);
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
