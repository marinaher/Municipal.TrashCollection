using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Municipal.TrashCollection.Models;

namespace Municipal.TrashCollection.Controllers
{
    public class Collection_CalendarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Collection_Calendar
        public ActionResult Index()
        {
            var collection_Calendar = db.collection_Calendar.Include(c => c.Calendar).Include(c => c.Collection);
            return View(collection_Calendar.ToList());
        }

        // GET: Collection_Calendar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Calendar collection_Calendar = db.collection_Calendar.Find(id);
            if (collection_Calendar == null)
            {
                return HttpNotFound();
            }
            return View(collection_Calendar);
        }

        // GET: Collection_Calendar/Create
        public ActionResult Create()
        {
            ViewBag.CalendarID = new SelectList(db.calendar, "ID", "ID");
            ViewBag.CollectionID = new SelectList(db.collection, "ID", "ID");
            return View();
        }

        // POST: Collection_Calendar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CollectionID,CalendarID")] Collection_Calendar collection_Calendar)
        {
            if (ModelState.IsValid)
            {
                db.collection_Calendar.Add(collection_Calendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CalendarID = new SelectList(db.calendar, "ID", "ID", collection_Calendar.CalendarID);
            ViewBag.CollectionID = new SelectList(db.collection, "ID", "ID", collection_Calendar.CollectionID);
            return View(collection_Calendar);
        }

        // GET: Collection_Calendar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Calendar collection_Calendar = db.collection_Calendar.Find(id);
            if (collection_Calendar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalendarID = new SelectList(db.calendar, "ID", "ID", collection_Calendar.CalendarID);
            ViewBag.CollectionID = new SelectList(db.collection, "ID", "ID", collection_Calendar.CollectionID);
            return View(collection_Calendar);
        }

        // POST: Collection_Calendar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CollectionID,CalendarID")] Collection_Calendar collection_Calendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collection_Calendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CalendarID = new SelectList(db.calendar, "ID", "ID", collection_Calendar.CalendarID);
            ViewBag.CollectionID = new SelectList(db.collection, "ID", "ID", collection_Calendar.CollectionID);
            return View(collection_Calendar);
        }

        // GET: Collection_Calendar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Calendar collection_Calendar = db.collection_Calendar.Find(id);
            if (collection_Calendar == null)
            {
                return HttpNotFound();
            }
            return View(collection_Calendar);
        }

        // POST: Collection_Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collection_Calendar collection_Calendar = db.collection_Calendar.Find(id);
            db.collection_Calendar.Remove(collection_Calendar);
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
