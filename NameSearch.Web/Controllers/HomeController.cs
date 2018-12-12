using NameSearch.Service;
using NameSearch.Service.Models;
using NameSearch.Web.Models;
using System.Web.Mvc;

namespace NameSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameSearchService _service;

        public HomeController(INameSearchService service)
        {
            _service = service;
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(NameSearchVM model)
        {
            NameSearchVM returnModel = new NameSearchVM();

            if (model.Action == "Search Saved Names")
            {
                NamesForSearch.HasSearchCompleted = true;
                returnModel.SearchResults = _service.SearchTextForAllSavedNames();
            }
            else
            {
                _service.AddNameToSearch(model.FirstName, model.MiddleName, model.LastName);
                returnModel.SavedNames = _service.GetNamesToSearch();
            }

            ModelState.Clear();

            return View(returnModel);
        }
    }
}