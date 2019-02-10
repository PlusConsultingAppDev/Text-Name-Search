using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace WebApplication1.Models
{
    public class SearchClass
    {
       // [Required(ErrorMessage = "A first name is required")]
       // [DisplayFormat(ConvertEmptyStringToNull = false)]
       // [StringLength(160, MinimumLength = 1)]
        public string FirstName { get; set; }

       // [Required(ErrorMessage = "A last name is required")]
       // [DisplayFormat(ConvertEmptyStringToNull = false)]
       // [StringLength(160, MinimumLength = 1)]
        public string LastName { get; set; }

       // [Required(ErrorMessage = "A middle name is required")]
       // [DisplayFormat(ConvertEmptyStringToNull = false)]
       // [StringLength(160, MinimumLength = 1)]
        public string MiddleName { get; set; }

        public string MiddleInitial
        {
            get
            { if (MiddleName!=null && MiddleName != "")
                {
                    return MiddleName.Substring(0, 1);
                }
            else return null;
            }
            set
            {
            }
        }

        public string FirstAndLastName {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {

            }
        }
        public int FirstAndLastAmount { get; set; }

        public string MiddleInitialLastName {
            get
            {
                return FirstName + " " + MiddleInitial + " " + LastName;
            }

            set
            {

            }
        }
        public int MiddleInitialLastNameAmount { get; set; }

        public string MidileInitialDotLastName {
            get
            {
                return FirstName + " " + MiddleInitial + ". " + LastName;
            }

            set
            {

            }
        }
        public int MiddleInitalDotLastNameAmount { get; set; }

        public string FullName {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }

            set
            {

            }
        }
        public int FullNameAmount { get; set; }
      
        
    }
}
