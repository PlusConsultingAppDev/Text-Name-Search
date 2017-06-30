using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeSearch.Models;
using EmployeeSearch.Dal;
using EmployeeSearch.ViewModel;
using System.Threading;
namespace EmployeeSearch.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        /*
         * Apologies for the delay.  My instinct is to solve a problem rather than not. So I started coding the solution this morning only to realize that it's pretty deep given the time constraints. Needless to say I ended up stubbing out the methods with my solution approach.

        1st Solution Approach:
        * make the employee list and search patterns configurable (by GUI) and persist in SQL server
        * have the client pass the content (searchable text) into the browser and submit to WebAPI
        * Action method will be invoked to:
            * call the EmployeeSearcher Class to:
               * get the current emp list and search patterns from the Data Access Layer (repository)
               * traverse and execute each search scenario (pattern) using RegExp
               * accumulate the Match count for each employee
            * the EmployeeSearcher object will return all employee found from the input text and return it to the View..

        * the View will parse the returning objects and display the detailed bulleted list in the browser


        Please see attached.. had not enough time to pushback to GIT, as the solution doesn't compile.
        I have solved the exact same challenge (parsing names) inside a SSIS package for CDC, and can do it again (with more time of course)!
         */

        public ActionResult Load() // connect via browser HTML
        {
        }

        public ActionResult Enter()
        {
            // view model object
            EmployeeViewModel obj = new EmployeeViewModel();
            // // single object is fresh
            obj.Employee = new Employee();
            // dal i have filled the Employees collection
            return View("EnterEmployee", obj);
        }
        public ActionResult EnterSearch()
        {
            EmployeeViewModel obj = new EmployeeViewModel();
            obj.Employees = new List<Employee>();
            return View("SearchEmployee", obj);
        }
        public ActionResult getEmployees() // JSON collection
        {
            EmployeeDal dal = new EmployeeDal();
            List<Employee> Employeescoll = dal.Employees.ToList<Employee>();
            Thread.Sleep(10000);
            return Json(Employeescoll, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchEmployee()
        {
            EmployeeViewModel obj = new EmployeeViewModel();
            EmployeeDal dal = new EmployeeDal();
            string str = Request.Form["txtEmployeeName"].ToString();
            List<Employee> Employeescoll
                = (from x in dal.Employees
                   where x.EmployeeName == str
                   select x).ToList<Employee>();
            obj.Employees = Employeescoll;
            return View("SearchEmployee", obj);
        }
        public ActionResult Submit() // validation runs
        {

            Employee obj = new Employee();
            obj.EmployeeName = Request.Form["Employee.EmployeeName"];
            obj.EmployeeCode = Request.Form["Employee.EmployeeCode"];
            if(ModelState.IsValid)
            {
                // insert the Employee object to database
                // EF DAL
                EmployeeDal Dal = new EmployeeDal();
                Dal.Employees.Add(obj); // in mmemory
                Dal.SaveChanges(); // physical commit
            }

            EmployeeDal dal = new EmployeeDal();
            List<Employee> Employeescoll = dal.Employees.ToList<Employee>();

            return Json(Employeescoll, JsonRequestBehavior.AllowGet);

        }
    }
}