using Microsoft.EntityFrameworkCore;

namespace Text_Name_Search.Data
{
    public class TextNameSearchContext : DbContext
    {
        public TextNameSearchContext (DbContextOptions<TextNameSearchContext> options)
            : base(options)
        {
        }

        public DbSet<Text_Name_Search.Models.SearchItem> SearchItem { get; set; }
    }
}
