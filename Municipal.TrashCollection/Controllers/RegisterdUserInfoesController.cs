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
    public class RegisterdUserInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterdUserInfoes
        public ActionResult Index()
        {
            //ViewBag. = db.calendar.Select(x => x.StartDate).Distinct().ToList();
            return View(db.RegisterdUserInfoes.ToList());
        }

        // GET: RegisterdUserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterdUserInfo registerdUserInfo = db.RegisterdUserInfoes.Find(id);
            if (registerdUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerdUserInfo);
        }

        // GET: RegisterdUserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterdUserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PickupDay,MonthlyBill")] RegisterdUserInfo registerdUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.RegisterdUserInfoes.Add(registerdUserInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerdUserInfo);
        }

        // GET: RegisterdUserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterdUserInfo registerdUserInfo = db.RegisterdUserInfoes.Find(id);
            if (registerdUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerdUserInfo);
        }

        // POST: RegisterdUserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PickupDay,MonthlyBill")] RegisterdUserInfo registerdUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerdUserInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerdUserInfo);
        }

        // GET: RegisterdUserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterdUserInfo registerdUserInfo = db.RegisterdUserInfoes.Find(id);
            if (registerdUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerdUserInfo);
        }

        // POST: RegisterdUserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterdUserInfo registerdUserInfo = db.RegisterdUserInfoes.Find(id);
            db.RegisterdUserInfoes.Remove(registerdUserInfo);
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
