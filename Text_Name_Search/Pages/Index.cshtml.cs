using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Text_Name_Search.Data;
using SearchServices;

namespace Text_Name_Search.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TextNameSearchContext _db;
        private ContentManagementService _contentManagementService;
        private NameSearchService _nameSearchService;

        [BindProperty]
        public string UrlToSearch { get; set; }

        public void OnGet()
        {

        }

        public IndexModel(TextNameSearchContext db, ContentManagementService contentManagementService, NameSearchService nameSearchService)
        {
            _db = db;
            _contentManagementService = contentManagementService;
            _nameSearchService = nameSearchService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await getURL goes here
            var content = await _contentManagementService.FetchPageAsync(this.UrlToSearch);
            var searchItems = _db.SearchItem;
            foreach (var searchItem in searchItems)
            {
                //call the permutations service to add variations to our search collection
                _nameSearchService.AddSearchName(searchItem.Text);
            }

            var names = _nameSearchService.SearchResults();
            return RedirectToPage("/Index");
        }

    }
}
