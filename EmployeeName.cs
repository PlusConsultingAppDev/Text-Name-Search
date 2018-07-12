using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSearch
{
    public class EmployeeName
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + MiddleName + " " + LastName;

        public string Initial
        {
            get
            {
                if (MiddleName != null && MiddleName.Length > 1) return MiddleName.Substring(0, 1);
                else return " ";
            } 
        }

    }
}
