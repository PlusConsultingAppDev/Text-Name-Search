using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNameSearchEngine
{
    public class Employee
    {
        public Employee()
        {

        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int Count { get; set; }

        public string MiddleInitial
        {
            get
            {
                if (MiddleName.Length > 1)
                {
                    return MiddleName.Substring(0, 1);
                }
                else
                {
                    return " ";
                }
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName + " (" + Count.ToString() + ")";
            }
        }
    }
}
