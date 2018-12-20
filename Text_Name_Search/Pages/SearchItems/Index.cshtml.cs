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
    public class IndexModel : PageModel
    {
        private readonly TextNameSearchContext _context;

        public IndexModel(TextNameSearchContext context)
        {
            _context = context;
        }

        public IList<SearchItem> SearchItem { get;set; }

        public async Task OnGetAsync()
        {
            SearchItem = await _context.SearchItem.ToListAsync();
        }
    }
}
