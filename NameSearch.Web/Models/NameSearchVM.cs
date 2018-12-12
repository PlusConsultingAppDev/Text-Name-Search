using NameSearch.Service.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NameSearch.Web.Models
{
    public class NameSearchVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Action { get; set; }

        public List<NameSearchModel> SavedNames { get; set; }

        public bool HasSearchCompleted { get; set; }

        public List<NameSearchModel> SearchResults { get; set; }
    }
}