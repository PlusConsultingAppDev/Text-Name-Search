using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers;
using WebApplication1.DAL;
using Microsoft.AspNetCore.Http;

using System.Data;
using System.Configuration;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller  
    {


       public NameSearcher ASearch = new NameSearcher();





        SavedNamesList dal = new SavedNamesList();


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
        public IActionResult SearchAgain(SearchClass userEntry)
        {
            userEntry.SavedNames = dal.getNamesList(userEntry);

            return View(userEntry);
        }

        /// <summary>
        /// Creates a searchclass and goes to the name entry view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NameSearch()
        {
            SearchClass userEntry = new SearchClass();

      
                //userEntry.SavedNames = new List<SearchClass>();
            

            return View(userEntry);
        }


        /// <summary>
        /// takes in the name, Verifies required with validation from the class
        /// Adds to the database
        /// </summary>
        /// <param name="userEntryAddedToList"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddToList(SearchClass userEntryAddedToList)
        {
            if (!ModelState.IsValid)
            {
                return View("SearchAgain", userEntryAddedToList);
            }       
            if (userEntryAddedToList.SavedNames == null)
            {
                userEntryAddedToList.SavedNames = new List<SearchClass>();
            }

            
            userEntryAddedToList.SavedNames =  dal.AddNamesList(userEntryAddedToList);



            return RedirectToAction("SearchAgain", userEntryAddedToList);
        }

        /// <summary>
        /// Pulls the data from the database, add to the searchclass object list
        /// add the amounts to a new searchclass list that then adds it in to the returned object.
        /// </summary>
        /// <param name="userEntrySearched"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchResults(SearchClass userEntrySearched)
        {
      
                userEntrySearched.SavedNames = dal.getNamesList(userEntrySearched);
           List<SearchClass> userEntrySearchedComplete = new List<SearchClass>();
            foreach (SearchClass item in userEntrySearched.SavedNames)
            {
                userEntrySearchedComplete.Add(ASearch.DoSearch(item));
            }
            userEntrySearched.SavedNames = userEntrySearchedComplete;
            return View(userEntrySearched);
        }
        [HttpPost]
        public IActionResult ClearList()
        {
            dal.ClearNamesList();

            return RedirectToAction("NameSearch");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
