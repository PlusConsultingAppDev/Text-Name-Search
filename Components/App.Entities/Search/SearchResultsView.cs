using System;
using App.Core.Contracts;

namespace App.Entities.Search
{
    public class SearchResultsView : IAuditable
    {
        public Guid ResultIdentifier { get; set; }

        public Guid SearchIdentifier { get; set; }

        public Guid ArticleIdentifier { get; set; }

        public string ArticleName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime SearchDate { get; set; }

        public string SearchText { get; set; }

        public int Occurrences { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
