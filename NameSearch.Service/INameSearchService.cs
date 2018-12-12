using NameSearch.Service.Models;
using System.Collections.Generic;

namespace NameSearch.Service
{
    public interface INameSearchService
    {
        bool AddNameToSearch(string firstName, string middleName, string lastName);


        List<NameSearchModel> GetNamesToSearch();
        List<NameSearchModel> SearchTextForAllSavedNames();
        List<SearchResult> SearchArticleText(string firstName, string middleName, string lastName);
    }
}
