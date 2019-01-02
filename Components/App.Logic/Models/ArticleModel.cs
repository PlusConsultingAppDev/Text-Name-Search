using System;

namespace App.Logic.Models
{
    public class ArticleModel
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }

        public int SourceType { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
