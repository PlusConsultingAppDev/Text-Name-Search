using System;
using App.Core.Contracts;

namespace App.Entities.Search
{
    public class Search : IAuditable
    {
        public Guid Identifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public int? ModifiedBy { get; set; }
    }
}