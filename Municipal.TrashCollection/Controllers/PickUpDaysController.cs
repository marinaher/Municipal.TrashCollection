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
    public class PickUpDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUpDays
        public ActionResult Index()
        {
            List <PickUpDay> pickUpDays = new List<PickUpDay>();

            var pickUpDay = db.PickUpDays.Include(p => p.Address).Include(p => p.Employee);
            return View(pickUpDays.ToList());
        }

        private IEnumerable<string> GetAllDays()
        {
            return new List<string>
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday"
            };
        }

        public ActionResult ChangePickupDay(PickUpDay model)
        {
            var days = GetAllDays();
            model.Days = GetSelectListItems(days);
            if (ModelState.IsValid)
            {
                Session["PickupDayModel"] = model;
                return RedirectToAction("Done");
            }
            return View("ChangeDay", model);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }
        public ActionResult Done()
        {
            var model = Session["PickupDayModel"] as PickUpDay;
            return View(model);
        }
        // GET: PickUpDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDays.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            return View(pickUpDay);
        }

        // GET: PickUpDays/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.address, "ID", "Street");
            ViewBag.EmployeeID = new SelectList(db.employee, "ID", "ID");
            return View();
        }

        // POST: PickUpDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,Status,EmployeeID,AddressID")] PickUpDay pickUpDay)
        {
            if (ModelState.IsValid)
            {
                db.PickUpDays.Add(pickUpDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AddressID = new SelectList(db.address, "ID", "Street", pickUpDay.AddressID);
            //ViewBag.EmployeeID = new SelectList(db.employee, "ID", "ID", pickUpDay.Employee_ID);
            return View(pickUpDay);
        }

        // GET: PickUpDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDays.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressID = new SelectList(db.address, "ID", "Street", pickUpDay.AddressID);
            //ViewBag.EmployeeID = new SelectList(db.employee, "ID", "ID", pickUpDay.Employee_ID);
            return View(pickUpDay);
        }

        // POST: PickUpDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,Status,EmployeeID,AddressID")] PickUpDay pickUpDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickUpDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AddressID = new SelectList(db.address, "ID", "Street", pickUpDay.AddressID);
            //ViewBag.EmployeeID = new SelectList(db.employee, "ID", "ID", pickUpDay.Employee_ID);
            return View(pickUpDay);
        }

        // GET: PickUpDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDays.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            return View(pickUpDay);
        }

        // POST: PickUpDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickUpDay pickUpDay = db.PickUpDays.Find(id);
            db.PickUpDays.Remove(pickUpDay);
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
