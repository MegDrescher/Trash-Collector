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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var day = DateTime.Today.DayOfWeek;
            string stringDay = day.ToString();
            var employees = db.Employees.Include(e => e.ApplicationUser);
            //var CustomerList = db.Customers.Where(c => c. CustomerZip == Employee.EmployeeZip && (d.DayOfWeek == stringDay || d.CustomPickup));
            //var employee = (CustomerList);
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer = null;
            if (id == null)
            {
                var FoundUserId = User.Identity.GetUserId();
                customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(customer);
            }

            else
            {
                customer = db.Customers.Find(id);
            }
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,AppUserID,ZipCode")] Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", employee.ApplicationUserId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Name,CustomerZip,Address,PickupStartDate,PickupEndDate,DayOfWeek,ApplicationUserId")] Customer customer)       
        {
            if (customer.PickupComplete == true)
            {
                customer.BillAmount = customer.BillAmount + 30;
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                var customerInDb = db.Customers.Where(x => x.CustomerId == customer.CustomerId).Single();

                //db.Entry(customer).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);
        }

        public ActionResult Map(int? id)
        {
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
                ViewBag.CustomerAddress = customer.Address;
                ViewBag.CustomerZip = customer.CustomerZip;

                return View(customer);
            }
        }
        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee Employee = db.Employees.Find(id);
            db.Employees.Remove(Employee);
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

    

