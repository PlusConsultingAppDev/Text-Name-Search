using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SearchServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Text_Name_Search.Data;

namespace Text_Name_Search.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TextNameSearchContext _db;
        private readonly ContentManagementService _contentManagementService;
        private readonly NameSearchService _nameSearchService;

        [BindProperty]
        public string UrlToSearch { get; set; }

        [BindProperty]
        public IList<KeyValuePair<string, int>> NamesFound { get; set; }

        public void OnGet()
        {
            // cheap trickery to get the page bind logic to work on initial load
            // since our page model isn't populated yet
            if (NamesFound is null)
                 NamesFound = _nameSearchService.SearchResults("");
        }

        // the ctor - the arguments get passed in via the magic of dependency injection built into ASP.NET Core
        public IndexModel(TextNameSearchContext db, ContentManagementService contentManagementService, NameSearchService nameSearchService)
        {
            _db = db;
            _contentManagementService = contentManagementService;
            _nameSearchService = nameSearchService;
        }

        // this method gets called when the user submits the URL to fetch
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // get our URL asynchronously
            var content = await _contentManagementService.FetchPageAsync(this.UrlToSearch);
            
            // grab the search items from the database
            var searchItems = _db.SearchItem;

            foreach (var searchItem in searchItems)
            {
                //call the permutations service to add variations to our search collection
                _nameSearchService.AddSearchName(searchItem.Text);
            }

            // assign to search results to our property fso the page can bind to the values
            NamesFound = _nameSearchService.SearchResults(content);

            return Page();
        }

    }
}
