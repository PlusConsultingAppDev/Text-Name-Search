using System.Collections.Generic;

namespace NameSearch.Service.Models
{
    public static class NamesForSearch
    {
        public static bool HasSearchCompleted { get; set; }
        public static List<NameSearchModel> NameSearchModels { get; set; }
    }

    public class NameSearchModel
    {
        public string SavedFirstName { get; set; }
        public string SavedMiddleName { get; set; }
        public string SavedLastName { get; set; }
        public List<SearchResult> Occurences { get; set; }
    }
}
