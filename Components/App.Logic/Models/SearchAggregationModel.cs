using System;
using System.Collections.Generic;

namespace App.Logic.Models
{
    public class SearchAggregationModel
    {
        public DateTime SearchDate { get; set; }

        public Guid SearchIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int TotalOccurrences { get; set; }

        public IEnumerable<SearchResultsModel> Results { get; set; }
    }
}
