using System;
using App.Core.Contracts;

namespace App.Entities.Search
{
    public class SourceType : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URI { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
