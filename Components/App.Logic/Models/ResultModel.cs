using System;

namespace App.Logic.Models
{
    public class ResultModel
    {
        public Guid Identifier { get; set; }

        public Guid ArticleIdentifier { get; set; }

        public Guid SearchIdentifier { get; set; }

        public string SearchText { get; set; }

        public int Occurrences { get; set; }
    }
}
