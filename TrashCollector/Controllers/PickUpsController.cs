using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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
            List<PickupDay> pickupsInZipCode = db.Pickups.Where(p => p.CustomerID == pickupscustomer.CustomerID).ToList();
            return View(pickupsInZipCode);
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupDay pickup = db.Pickups.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
        }

        // GET: PickUps/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID","Address");
            return View();
        }

        // POST: PickUps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="PickupId,PickupDay,VacaStart,VacaEnd,ExtraPickUpDay")] PickupDay pickup)
        {
            string AppCutID = User.Identity.GetUserId();
            var pickupcustomer = db.Customers.Where(s => s.AppUserID == AppCutID).Single();
            pickup.CustomerID = pickupcustomer.CustomerID;
        }

        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PickUps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PickUps/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PickUps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PickUps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

