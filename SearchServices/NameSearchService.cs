using System;
using System.Collections.Generic;
using System.Text;

namespace SearchServices
{
    class NameSearchService
    {
        // so this beast with have the search string as a key to the outer dictionary
        // the inner dictionary will keep the permutations of the search string
        // with an integer counter.  Every time we encounter a variant, we'll increment
        // the counter.  
        private Dictionary<string, Dictionary<string, int>> _dictionary;
        public NameSearchService()
        {
            _dictionary = new Dictionary<string, Dictionary<string, int>>();
        }


    }
}
