using System;
using System.Collections.Generic;
using System.Linq;
using SupportServices;

namespace SearchServices
{
    public class NameSearchService
    {
        // so this beast with have the search string as a key to the outer dictionary
        // the inner dictionary will keep the permutations (variants) of the search string
        // with an integer counter.  Every time we encounter a variant, we'll increment
        // the counter.  

        private readonly Dictionary<string, IList<string>> _dictionary;
        private PermutationService _permService;

        // fetch the text from the website
        private string _stringToSearch;

        public NameSearchService()
        {
            _dictionary = new Dictionary<string, IList<string>>();
        }

        public void AddSearchName(string name)
        {
            _permService = new PermutationService(name);
            _dictionary.Add(name, _permService.GeneratePermutations());
        }

        // SearchResults takes the string to be searched and builds a list of strings
        // found in our dictionary of string variants.  The resultant list of key/value 
        // pairs indicates how many times the string occurred in the stringToSearch
        public List<KeyValuePair<string, int>> SearchResults(string stringToSearch)
        {
           _stringToSearch = stringToSearch;

           // fire up an instance
            var svc = new ContentManagementService();

            var resultsList = new List<KeyValuePair<string, int>>();

            // total count for each search name (not variants)
            int totalFinds = 0;

            // because modification of a dict during the loop invalidates the iterator
            // we'll use a list of keys
            foreach (var key in _dictionary.Keys.ToList())
            {
                // get the name to find from the Key
                var searchList = _dictionary[key];
                
                for (int x = 0; x < searchList.Count; x++)
                {
                    // get the variant nto search for
                    string searchName = searchList[x];

                    // get the variant and the number of times it occurs
                    var result = SearchForSpecificName(searchName);

                    // add it to the list
                    resultsList.Add(result);

                    // increment the total
                    totalFinds += result.Value;
                }

                // add that total to the list
                resultsList.Add(new KeyValuePair<string, int>(key+ " total", totalFinds));

                // reset the number of instances for a give name/variant
                totalFinds = 0;
            }

            // return a List of key/value pairs
            return resultsList;
        }

        // this method performs the searching by finding each occurence of a string
        // starting with the beginning of the content and then advancing one character to 
        // search again for the string until we don't find any additional occurrences
        private KeyValuePair<string, int> SearchForSpecificName(string searchString)
        {
            int count = 0;

            for (int y = 0; y < _stringToSearch.Length; y++)
            {
                // find the position/index of the search string in the string to search and ignore case
                int indexOf = _stringToSearch.IndexOf(searchString, y, StringComparison.OrdinalIgnoreCase);

                // for clarity, let's set a flag: true if indexOf is not equal to -1 (-1 being not found)
                var found = (indexOf != -1);

                // if the search was found...
                if (found)
                {
                    // increment our count
                    count++;

                    // advance to the the position of the first character of the search string
                    // the loop will then advance to the next chracter in the string and search again from there
                    y = indexOf;
                }
                else
                    break;
            }

            return new KeyValuePair<string, int>(searchString, count);
        }
    }
}
