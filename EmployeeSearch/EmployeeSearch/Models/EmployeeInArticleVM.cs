using EmployeeSearch.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeSearch.Models
{
    public class EmployeeInArticleVM
    {
        public Employee Employee { get; set; }
        public Article Article { get; set; }
        public List<NameCount> NameCounts { get; set; }
    }
}