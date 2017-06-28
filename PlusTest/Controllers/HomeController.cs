using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PlusTest.Models;

namespace PlusTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new ResultsViewModel());
        }

        [HttpPost]
        public ActionResult Index(string text)
        {
            var allEmployees = Employee.GeAll();
            Dictionary<Employee, int> results = new Dictionary<Employee, int>();

            foreach (var employee in allEmployees)
            {
                foreach (var name in employee.NamePermutations)
                {
                    int count = Regex.Matches(text.ToLower(), name.ToLower()).Count;
                    if (results.ContainsKey(employee))
                    {
                        results[employee] = results[employee] + count;
                    }
                    else if(count > 0)
                    {
                        results.Add(employee, count);
                    }
                }
            }

            ResultsViewModel returnObject = new ResultsViewModel();
            returnObject.Results = results;
            returnObject.Text = text;

            if (results.Count < 1)
            {
                returnObject.Message = "No employees found.";
            }

            return View(returnObject);
        }
    }
}