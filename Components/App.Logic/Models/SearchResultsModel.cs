using System;
using System.Collections.Generic;

namespace App.Logic.Models
{
    public class SearchResultsModel
    {
        public Guid ArticleIdentifier { get; set; }

        public string ArticleName { get; set; }

        public IEnumerable<SearchDataModel> Data { get; set; }
    }
}
