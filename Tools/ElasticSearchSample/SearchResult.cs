using System.Collections.Generic;

namespace ElasticSearchSample
{
    public class SearchResult<T>
    {
        public int Total { get; set; }
        public List<T> Results { get; set; }
    }
}
