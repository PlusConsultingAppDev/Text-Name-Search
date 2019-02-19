using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {


        INameSearcher ASearch = new NameSearcher();
        public SearchClass userEntry = new SearchClass();




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NameSearch()
        {
            if (userEntry.SavedNames == null)
            {
                userEntry.SavedNames = new List<SearchClass>();
            }
            return View(userEntry);
        }

        [HttpPost]
        public IActionResult AddToList(SearchClass userEntry)
        {
            if (!ModelState.IsValid)
            {
                return View("NameSearch", userEntry);
            }

            userEntry.SavedNames.Add(userEntry);
            return View(userEntry);
        }

        [HttpPost]
        public IActionResult SearchResults(SearchClass userEntry)
        {
            if (!ModelState.IsValid)
            {
                return View("NameSearch", userEntry);
            }

            userEntry = ASearch.DoSearch(userEntry);
            return View(userEntry);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
