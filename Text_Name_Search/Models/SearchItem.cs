using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Text_Name_Search.Models
{
    public class SearchItem
    {
        public int ID { get; set; }

        // regex to get first, middle, last names (min. 2 chars long) separated by spaces
        [RegularExpression(@"[a-zA-z]{2,}\s[a-zA-z]{2,}\s[a-zA-z]{2,}", ErrorMessage = "Please enter first name, middle name, last name separated by spaces.  Each name must be at least 2 chars long.")]
        [Required]
        public string Text { get; set; }
    }
}
