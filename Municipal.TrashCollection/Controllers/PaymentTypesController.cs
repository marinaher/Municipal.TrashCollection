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
    public class PaymentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentTypes
        public ActionResult Index()
        {
            var paymentType = db.paymentType.Include(p => p.CreditCard).Include(p => p.PayPal);
            return View(paymentType.ToList());
        }

        // GET: PaymentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.paymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public ActionResult Create()
        {
            ViewBag.CreditCard_ID = new SelectList(db.creditCard, "ID", "CardHolderName");
            ViewBag.PayPal_ID = new SelectList(db.payPal, "ID", "ID");
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreditCard_ID,PayPal_ID,TotalAmount")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                db.paymentType.Add(paymentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreditCard_ID = new SelectList(db.creditCard, "ID", "CardHolderName", paymentType.CreditCard_ID);
            ViewBag.PayPal_ID = new SelectList(db.payPal, "ID", "ID", paymentType.PayPal_ID);
            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.paymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreditCard_ID = new SelectList(db.creditCard, "ID", "CardHolderName", paymentType.CreditCard_ID);
            ViewBag.PayPal_ID = new SelectList(db.payPal, "ID", "ID", paymentType.PayPal_ID);
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreditCard_ID,PayPal_ID,TotalAmount")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreditCard_ID = new SelectList(db.creditCard, "ID", "CardHolderName", paymentType.CreditCard_ID);
            ViewBag.PayPal_ID = new SelectList(db.payPal, "ID", "ID", paymentType.PayPal_ID);
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.paymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentType paymentType = db.paymentType.Find(id);
            db.paymentType.Remove(paymentType);
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
