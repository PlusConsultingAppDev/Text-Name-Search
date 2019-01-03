using System;
using System.Collections.Generic;

namespace App.Logic.Models
{
    public class SearchModel
    {
        public Guid Identifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public List<ResultModel> Results { get; set; }
    }
}
