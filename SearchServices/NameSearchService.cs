using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchServices
{
    public class NameSearchService
    {
        // so this beast with have the search string as a key to the outer dictionary
        // the inner dictionary will keep the permutations of the search string
        // with an integer counter.  Every time we encounter a variant, we'll increment
        // the counter.  
        //private Dictionary<string, Dictionary<string, int>> _dictionary;

        private readonly Dictionary<string, IList<string>> _dictionary;
        private PermutationService _permService;
        // fetch the text from the website
        private readonly string _contentToSearch;

        public NameSearchService(string content)
        {
            _contentToSearch = content;

            //_dictionary = new Dictionary<string, Dictionary<string, int>>();
            _dictionary = new Dictionary<string, IList<string>>();
        }

        public void AddSearchName(string name)
        {
            _permService = new PermutationService(name);
            _dictionary.Add(name, _permService.GeneratePermutations());
        }

        public List<string> SearchResults()
        {
            // fire up an instance
            var svc = new ContentManagementService();

            var resultsList = new List<string>();

            //var contentToSearch = content.ToString();
            //bool contains = contentToSearch.Contains("david black", StringComparison.OrdinalIgnoreCase);
            int totalFinds = 0;

            // because modification of a dict during the loop invalidates the iterator
            // we'll use a list of keys
            foreach (var key in _dictionary.Keys.ToList())
            {
                // get the name to find from the Key
                string searchName = key;

                for (int i = 0; i < _contentToSearch.Length; i++)
                {
                    int pos = _contentToSearch.IndexOf(searchName, i, StringComparison.OrdinalIgnoreCase);
                    var found = (pos != -1);

                    if (found != false)
                    {
                        //_dictionary[key]. = totalFinds++;
                        totalFinds++;
                        i = pos;
                    }
                    else
                        break;
                }

                resultsList.Add($"The search parameter {key} was found {totalFinds} times.");
                totalFinds = 0;

            }

            return resultsList;
        }
    }
}
