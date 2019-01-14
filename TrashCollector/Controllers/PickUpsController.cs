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
            string customer = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(c => c.AppUserID == customer).Single();
            List<Models.PickupDayViewModel> pickupsInZipCode = db.Pickups.Where((object p) => p.CustomerID == pickupcustomer.CustomerID).ToList();
            return View(pickupsInZipCode);
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PickupDayViewModel pickup = db.pickups.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
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
        public ActionResult Create([Bind(Include = "PickupId,PickupDay,VacationStart,VacationEnd,ExtraPickUpDay")] Models.PickupDayViewModel pickup)
        {
            string AppCutID = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(s => s.AppUserID == AppCutID).Single();
            pickup.CustomerID = pickupcustomer.CustomerID;

            if (ModelState.IsValid)
            {
                db.PickupDays.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("Idex");
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
            Models.PickupDayViewModel pickup = db.pickups.Find(id);
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
        public ActionResult Edit([Bind(Include = "PickupId,PickupDay, VacationStart,VacationEnd,ExtraPickup")] Models.PickupDayViewModel pickup)
        {
            string AppCutID = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(s => s.AppUserID == AppCutID).Single();
            Models.PickupDayViewModel pickupToEdit = db.pickups.Where((object p) => p.CustomerID == pickupcustomer.CustomerID).Single();
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
            Models.PickupDayViewModel pickup = db.pickups.Find(id);
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
            Models.PickupDayViewModel pickup = db.pickups.Find(id);
            db.pickups.Remove(pickup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult PickupsByDay()
        {
            if (User.IsInRole("Customer"))
            {
                return HttpNotFound();
            }

            string employeeId = User.Identity.GetUserId();
            var employee = db.Employee.Where(e => e.AppUserID == employeeId).FirstOrDefault();

            PickupDayViewModel pvdm = new PickupDayViewModel();
            var pickups = db.pickups;

            var daything = pickups.ToList();
            foreach (var item in daything)
            {
                item.Customer = db.Customers.Where(c => c.CustomerID == item.CustomerID).Single();
            }

            List<string> days = new List<string>();
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");

            ViewBag.Days = days;

            return View(daything);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PickupsByDay(PickupDayViewModel model)
        {
            List<string> days = new List<string>();
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");

            ViewBag.Days = days;

            if(model.DaySearch = null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                string employeeId = User.Identity.GetUserId();
                var employer = db.Employee.Where(e => e.AppUserID == employeeId).FirstOrDefault();
                List<int> customerIds = db.Customers.Where(c => c.ZipCode == employer.ZipCode).Select(c => c.CustomerID).ToList();
                List<Models.PickupDayViewModel> pickupsInZipCode = db.Pickups.Where((object p) => customerIds.Contains(p.CustomerID)).Include((object p) => p.Customer).ToList();
                List<Models.PickupDayViewModel> pickupsInZipCodeNoVacation = pickupsInZipCode.Where(p => !((p.VacationStart < DateTime.Now) && (p.VacationEnd > DateTime.Now))).ToList();
                var PickupSameDay = pickupsInZipCodeNoVacation.Where(p => (p.PickUpDay == model.DaySearch) || (p.ExtraPickUp == DateTime.Today));

                PickupDayViewModel pdvm = new PickupDayViewModel();

                List<Pickup> Listdaything = PickupDayViewModel.ToList();
                return View(Listdaything);
            }
        }
        public ActionResult AdjustBalance(int? id)
            //Adjust and Update the customer's balance
        {
            Customer customer = db.Customers.Find(id);
            customer.PickupStatus = true;
            customer.BalanceDue += 30;
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



