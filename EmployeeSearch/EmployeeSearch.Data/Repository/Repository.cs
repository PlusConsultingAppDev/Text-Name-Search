using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSearch.Models.Models;

namespace EmployeeSearch.Data.Repository
{
    public class Repository
    {

		public List<NameCount> EmployeeNameCount(Employee employee, Article article)
        {

            int firstMiddleLast = 0;
            int firstMLast = 0;
            int firstLast = 0;
            int firstMiddleDotLast = 0;
            string middleInitial = "";
            string middleInitialAndPeriod = "";
            if (employee.MiddleName != null)
            {
                middleInitial = employee.MiddleName.Substring(0, 1).ToUpper();
                middleInitialAndPeriod = employee.MiddleName.Substring(0, 1).ToUpper() + '.';
            }

			// split on spaces and periods
            string[] count = article.Body.Split(' ');
			for (int i = 0; i <= count.Length -1; i++)
            {
				// Matthew Steven Wilkinson
				if (count[i] == employee.FirstName && count[i+1] == employee.MiddleName && count[i+2] == employee.LastName)
                {
                    firstMiddleLast++;
                }
				// matthew S wilkinson
				if (count[i] == employee.FirstName && count[i+1] == middleInitial && count[i+2] == employee.LastName)
                {
                    firstMLast++;
                }
				// Matthew s wilkinson
				if (count[i] == employee.FirstName && count[i+1] == employee.LastName)
                {
                    firstLast++;
                }
				// matthew S. Wilkinson
				if (count[i] == employee.FirstName && count[i+1] == middleInitialAndPeriod && count[i+2] == employee.LastName)
                {
                    firstMiddleDotLast++;
                }
            }
			// This list should go after the for loop so it can collect the correct counts
            List<NameCount> nameCount = new List<NameCount>
            {
				// Scott Martin Smith: 4
				new NameCount { Name = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName, Count = firstMiddleLast},
				// Scott Smith: 2
                new NameCount { Name = employee.FirstName + " " + employee.LastName, Count = firstLast},
				// Scott M Smith: 2
                new NameCount { Name = employee.FirstName + " " + middleInitial + " " + employee.LastName, Count = firstMLast},
				// Scott M. Smith: 1
				new NameCount { Name = employee.FirstName + " " + middleInitialAndPeriod + " " +  employee.LastName, Count = firstMiddleDotLast }
            };
            return nameCount;
        }
    }
}
