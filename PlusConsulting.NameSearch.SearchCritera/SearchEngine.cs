using System.Collections.Generic;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.SearchCritera
{
    public class SearchEngine
    {
        public ISearchResults Search(ISearchItem searchItem, ISearchContent content)
        {
            return Search(new[] {searchItem}, content);
        }

        public ISearchResults Search(ISearchItem[] searchItems, ISearchContent content)
        {
            ISearchResults results = new SearchResults(content.Url);

            foreach (var item in searchItems)
            {
                results.AddItemFound(item.Key, item.Search(content.Content));
            }

            return results;
        }

        public IEnumerable<ISearchResults> Search(ISearchItem[] searchItems, ISearchContent[] searchContents)
        {
            var resultsList = new List<ISearchResults>();

            foreach (var searchContent in searchContents)
            {
                resultsList.Add(Search(searchItems, searchContent));
            }

            return resultsList;
        }

        //TODO: Add SearchAsync method(s). Probably can refactor the above method to search async when searching multiple contents (aka web pages).
    }
}
