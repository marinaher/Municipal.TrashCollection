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
    public class PayPalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayPal
        public ActionResult Index()
        {
            return View(db.payPal.ToList());
        }

        // GET: PayPal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPal payPal = db.payPal.Find(id);
            if (payPal == null)
            {
                return HttpNotFound();
            }
            return View(payPal);
        }

        // GET: PayPal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayPal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] PayPal payPal)
        {
            if (ModelState.IsValid)
            {
                db.payPal.Add(payPal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payPal);
        }

        // GET: PayPal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPal payPal = db.payPal.Find(id);
            if (payPal == null)
            {
                return HttpNotFound();
            }
            return View(payPal);
        }

        // POST: PayPal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] PayPal payPal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payPal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payPal);
        }

        // GET: PayPal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPal payPal = db.payPal.Find(id);
            if (payPal == null)
            {
                return HttpNotFound();
            }
            return View(payPal);
        }

        // POST: PayPal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayPal payPal = db.payPal.Find(id);
            db.payPal.Remove(payPal);
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
