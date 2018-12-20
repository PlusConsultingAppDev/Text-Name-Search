using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Text_Name_Search.Data;
using Text_Name_Search.Models;

namespace Text_Name_Search.Pages.SearchItems
{
    public class EditModel : PageModel
    {
        private readonly TextNameSearchContext _context;

        public EditModel(TextNameSearchContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SearchItem SearchItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SearchItem = await _context.SearchItem.FirstOrDefaultAsync(m => m.ID == id);

            if (SearchItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SearchItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchItemExists(SearchItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SearchItemExists(int id)
        {
            return _context.SearchItem.Any(e => e.ID == id);
        }
    }
}
