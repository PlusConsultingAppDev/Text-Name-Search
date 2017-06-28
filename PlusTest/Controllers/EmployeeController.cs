using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using PlusTest.Models;

namespace PlusTest.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(Employee.GeAll());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newEmployee.Insert();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Employee(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employeeToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeToUpdate.Update();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Employee(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee empToDelete)
        {
            try
            {
                empToDelete.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
