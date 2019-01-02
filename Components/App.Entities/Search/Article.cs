using System;
using App.Core.Contracts;

namespace App.Entities.Search
{
    public class Article : IAuditable
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }

        public int SourceType { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
