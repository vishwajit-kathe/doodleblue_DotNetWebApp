using dotnetWebApp_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotnetWebApp_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        tblemployeeEntities context = new tblemployeeEntities();

        [HttpGet]
        public ActionResult viewlist()
        {
            var data = context.tblemployees.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.tblemployees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(tblemployee employee)
        {
            var data = context.tblemployees.Where(x => x.EmployeeID == employee.EmployeeID).FirstOrDefault();

            if (data != null)
            {
                data.Ename = employee.Ename;
                data.Email = employee.Email;
                data.City = employee.City;
                context.SaveChanges();
            }
            return RedirectToAction("viewlist");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = context.tblemployees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(tblemployee employee)
        {
            var data = context.tblemployees.Where(x => x.EmployeeID == employee.EmployeeID).FirstOrDefault();

            if (data != null)
            {
                context.tblemployees.Remove(data);
                context.SaveChanges();
            }
            return RedirectToAction("viewlist");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = context.tblemployees.Where(x => x.EmployeeID == id).FirstOrDefault();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblemployee employee)
        {
            context.tblemployees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("viewlist");
        }
    }
}