using EmployeeSearch.Data.Repository;
using EmployeeSearch.Models;
using EmployeeSearch.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSearch.Controllers
{
    public class HomeController : Controller
    {

        private Repository _repo = new Repository();
        // enter user
        public ActionResult Index()
        {
            EmployeeInArticleVM vm = new EmployeeInArticleVM();
            return View(vm);
        }

        [AcceptVerbs("POST")]
        public ActionResult EmployeeCount(EmployeeInArticleVM model)
        {
            Employee employee = new Employee();
                employee.FirstName = model.Employee.FirstName.ToUpper();
                employee.MiddleName = model.Employee.MiddleName.ToUpper();
                employee.LastName = model.Employee.LastName.ToUpper();


            Article article = new Article();
            article.Body = model.Article.Body.ToUpper();

            var count = _repo.EmployeeNameCount(employee, article);
            
            return View(count);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}