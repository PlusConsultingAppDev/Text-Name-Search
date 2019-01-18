using System.Collections.Generic;
using System.Threading.Tasks;
using SearchAPI.Models;

namespace SearchAPI
{
    public interface ISearchService
    {
        List<string> AutoComplete(string searchQuery);
        Task<DocumentSearchResult> SearchAsync(SearchParam searchQuery);
    }
}