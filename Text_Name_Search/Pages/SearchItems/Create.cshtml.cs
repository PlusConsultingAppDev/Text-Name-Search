using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Text_Name_Search.Data;
using Text_Name_Search.Models;

namespace Text_Name_Search.Pages.SearchItems
{
    public class CreateModel : PageModel
    {
        private readonly TextNameSearchContext _context;

        public CreateModel(TextNameSearchContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SearchItem SearchItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SearchItem.Add(SearchItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
