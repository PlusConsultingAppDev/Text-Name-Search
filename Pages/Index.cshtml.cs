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
        private ContentRetrieval _svc;

        [BindProperty]
        public string UrlToSearch { get; set; }

        public void OnGet()
        {

        }

        public IndexModel(TextNameSearchContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await getURL goes here
            var content = _svc.PageContents;

            var searchItems = _db.SearchItem;
            foreach (var searchItem in searchItems)
            {
                //call the permutations service to add variations to our search collection
                //
            }

            return RedirectToPage("/Index");
        }

    }
}
