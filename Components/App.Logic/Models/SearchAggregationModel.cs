using System;
using System.Collections.Generic;

namespace App.Logic.Models
{
    public class SearchAggregationModel
    {
        public DateTime SearchDate { get; set; }

        public Guid SearchIdentifier { get; set; }

        public string FullFirstName { get; set; }

        public string FullLastName { get; set; }

        public string FullMiddleName { get; set; }

        public int TotalOccurrences { get; set; }

        public IEnumerable<SearchResultsModel> Results { get; set; }
    }
}
