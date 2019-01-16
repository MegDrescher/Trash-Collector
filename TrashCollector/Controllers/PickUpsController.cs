using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickUpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: PickUps
        public ActionResult Index()
        {
            return View();
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: PickUps/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Address");
            return View();
        }

        // POST: PickUps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickupId,PickupDay,VacationStart,VacationEnd,ExtraPickUpDay")] Pickup pickup)
        {
            
            string AppCutID = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(s => s.ApplicationUserId == AppCutID).Single();
            pickup.CustomerID = pickupcustomer.CustomerId;

            if (ModelState.IsValid)
            {
                db.Pickup.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Address", pickup.CustomerID);
            return View(pickup);
        }

        // GET: PickUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "PickupDay", pickup.CustomerID);
            return View(pickup);
        }

        // POST: PickUps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickupId,PickupDay, VacationStart,VacationEnd,ExtraPickup")] Models.Pickup pickup)
        {
            string AppCutID = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(s => s.ApplicationUserId == AppCutID).Single();
            Models.Pickup pickupToEdit = db.Pickup.Where(p => p.CustomerID == pickupcustomer.CustomerId).Single();
            db.SaveChanges();
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "PickupDay", pickup.CustomerID);
            return View(pickup);
        }


        // GET: PickUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
        }

        // POST: PickUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Pickup = db.Pickup.Where(x => x.PickupId == id).Select(x => x).FirstOrDefault();
            db.Pickup.Remove(Pickup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PickupByDay()
        {
            return View();
        }
        public ActionResult AdjustBalance(int? id)
            //Adjust and Update the customer's balance
           {
            Customer customer = db.Customers.Find(id);
            customer.PickupStatus = true;          
            customer.BalanceDue = 30;
            db.SaveChanges();
            return RedirectToAction("PickupsByDay", "Pickups");   
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public class PickupDayViewModel
        {
            public object DaySearch { get; internal set; }

            internal static List<Pickup> ToList()
            {
                throw new NotImplementedException();
            }
        }
    }  
}



