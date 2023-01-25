using HomeBi.Libraries.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        testdbEntities context = new testdbEntities();

        [HttpGet]
        public ActionResult viewlist(String page)
        {
            var pageInt = Convert.ToInt16(page);
            ViewBag.page = pageInt;
            var data = context.employees.OrderBy(x => x.Id).ToPagedList(pageInt, 10);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data = context.employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(employee employee)
        {
            var data = context.employees.Where(x=>x.Id==employee.Id).FirstOrDefault();

            if(data!=null) 
            {
                data.Name = employee.Name;
                data.City= employee.City;
                context.SaveChanges();
            }
            return RedirectToAction("viewlist");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = context.employees.Where(x=>x.Id==id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(employee employee) 
        { 
            var data = context.employees.Where(x=>x.Id==employee.Id).FirstOrDefault();

            if(data!= null) 
            {
                context.employees.Remove(data);
                context.SaveChanges();
            }
            return RedirectToAction("viewlist");
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            var data = context.employees.Where(x=>x.Id==id).FirstOrDefault();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("viewlist");
        }
    }
}