using EnterpriseDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseDataApp.API
{
    public class SearchAPI
    {
        private readonly SearchItem _searchItem = null;

        public SearchAPI(SearchItem item)
        {
            _searchItem = new SearchItem
            {
                FirstName = item.FirstName,
                MiddleInitial = item.MiddleInitial,
                LastName = item.LastName
            };
        }

        public IEnumerable<dynamic> SearchNames()
        {
            ICollection<dynamic> searchResults = new List<dynamic>();
            searchResults.Add(GetNames().Where(x => x.FirstName == _searchItem.FirstName && x.LastName == _searchItem.LastName && x.MiddleInitial == _searchItem.MiddleInitial)
                                        .GroupBy(y => (y.FirstName, y.MiddleInitial, y.LastName)).Select(z => (z.Key, z.Count())));
            searchResults.Add(GetNames().Where(x => x.FirstName == _searchItem.FirstName && x.LastName == _searchItem.LastName)
                                        .GroupBy(y => (y.FirstName, y.MiddleInitial, y.LastName)).Select(z => (z.Key, z.Count())));

            return searchResults;
        }

        public static ICollection<SearchItem> GetNames()
        {
            ICollection<SearchItem> items = new List<SearchItem>
            {
                new SearchItem { FirstName = "Connor", MiddleInitial = "Gary", LastName = "Smith" },
                new SearchItem { FirstName = "Connor", MiddleInitial = "Gary", LastName = "Smith" },
                new SearchItem { FirstName = "Seth ", MiddleInitial = "David ", LastName = "Greenly " },
                new SearchItem { FirstName = "Seth ", MiddleInitial = "David ", LastName = "Greenly " },
                new SearchItem { FirstName = "David ", MiddleInitial = "Warren ", LastName = "Black " },
                new SearchItem { FirstName = "David ", MiddleInitial = "Warren ", LastName = "Black " },
                new SearchItem { FirstName = "David ", MiddleInitial = "Warren ", LastName = "Black " },
                new SearchItem { FirstName = "David ", MiddleInitial = "Warren ", LastName = "Black " }
            };
            return items;
        }
    }
}
