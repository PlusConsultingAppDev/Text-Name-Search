using System.Collections.Generic;

namespace SearchAPI.Models
{
    public class DocumentSearchResult
    {
        public SearchParam SearchQuery { get; set; }
        public List<string> ContentList { get; set; }
    }
}
