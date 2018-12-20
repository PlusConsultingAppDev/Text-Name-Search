using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Text_Name_Search.Data;
using Text_Name_Search.Models;

namespace Text_Name_Search.Pages.SearchItems
{
    public class DetailsModel : PageModel
    {
        private readonly TextNameSearchContext _context;

        public DetailsModel(TextNameSearchContext context)
        {
            _context = context;
        }

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
    }
}
