using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var FoundUserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            var customers = db.Customers.Include(c => c.ApplicationUser);
            return View(customer);         
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer = null;
            if(id == null)
            {
                var FoundUserId = User.Identity.GetUserId();
                customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(customer);
            }

            else
            {
                customer = db.Customers.Find(id);
            }
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole");
            return View();
            //return View(pickup)
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="CustomerID,Address,ZipCode,AppUserID")]Customer customer)
        {
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();
           
            if (ModelState.IsValid)
            {
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole",customer.ApplicationUserId);
            return View(customer);
        }
        
        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Address,ZipCode,AppUserID")]Customer customer)
        {
            if(ModelState.IsValid)
            
            {
                // TODO: Add update logic here
               db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");             
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);        
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find();
            db.Customers.Remove(customer);
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
