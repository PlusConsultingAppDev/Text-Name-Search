using System.Collections.Generic;
using System.Linq;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.SearchCritera
{
    public class SearchResults : ISearchResults
    {
        private readonly Dictionary<string, int> _searchHits;
        
        public string ContentUrl { get; }

        public SearchResults(string contentUrl)
        {
            ContentUrl = contentUrl;
            _searchHits = new Dictionary<string, int>();
        }

        public void AddItemFound(string key, int count)
        {
            if (_searchHits.ContainsKey(key))
                _searchHits[key] += count;
            else
                _searchHits[key] = count;
        }

        public int GetCountForItem(string key)
        {
            return _searchHits.ContainsKey(key)
                ? _searchHits[key]
                : 0;
        }

        public string[] Keys => _searchHits.Keys.ToArray();
    }
}
