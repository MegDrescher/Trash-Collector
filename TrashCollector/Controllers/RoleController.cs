using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }

                if (isEmployeeUser())
                {
                    return RedirectToAction("Index", "Employees");
                }

                if (isCustomerUser())
                {
                    return RedirectToAction("Index", "Customers");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var Roles = context.Roles.ToList();
            return View();

        }

        public bool isEmployeeUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Employee")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool isCustomerUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Customer")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Boolean isAdminUser()
        {
            var user = User.Identity;
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(user.GetUserId());
            if (s[0].ToString() == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            //return false;                        
    }
}

//// GET: Role/Details/5
//public ActionResult Details(int id)
//{
//    return View();
//}

//// GET: Role/Create
//public ActionResult Create()
//{
//    return View();
//}

//// POST: Role/Create
//[HttpPost]
//public ActionResult Create(FormCollection collection)
//{
//    try
//    {
//        // TODO: Add insert logic here

//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: Role/Edit/5
//public ActionResult Edit(int id)
//{
//    return View();
//}

//// POST: Role/Edit/5
//[HttpPost]
//public ActionResult Edit(int id, FormCollection collection)
//{
//    try
//    {
//        // TODO: Add update logic here

//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: Role/Delete/5
//public ActionResult Delete(int id)
//{
//    return View();
//}

//// POST: Role/Delete/5
//[HttpPost]
//public ActionResult Delete(int id, FormCollection collection)
//{
//    try
//    {
//        // TODO: Add delete logic here

//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}
//    }
//}
