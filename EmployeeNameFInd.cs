using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NameSearch
{
    public class EmployeeNameFind
    {
        public void FindNameInText(List<string> EmployeeNameList, string Text)
        {
            List<EmployeeName> employeeList = new List<EmployeeName>();


            foreach (var employee in EmployeeNameList)
            {
                var em = employee.Split(' ','.');
                switch (em.Length)
                {
                    case 1:
                        employeeList.Add(new EmployeeName(){FirstName = em[0]});
                        break;
                    case 2:
                        employeeList.Add(new EmployeeName(){FirstName = em[0], LastName = em[2]});
                        break;
                    case 3:
                        employeeList.Add(new EmployeeName(){FirstName = em[0],MiddleName = em[1],LastName = em[2]});
                        break;
                }
            }
            Console.WriteLine("List of Names with occurrences");
            foreach (var employ in employeeList)
            {
                Console.WriteLine("{0}({1})", employ.FullName, FindTextCount(employ, Text));
            }
            Console.ReadLine();
        }

        public int FindTextCount(EmployeeName employeeName, string Text)
        {
            int firstLast = Regex.Matches(Text.ToLower(), $"{employeeName.FirstName} {employeeName.LastName}".ToLower()).Count;
            int firstMiddleInitialLast = Regex.Matches(Text.ToLower(), $"{employeeName.FirstName} {employeeName.Initial} {employeeName.LastName}".ToLower()).Count;
            int firstMiddleDotLast = Regex.Matches(Text.ToLower(), $"{employeeName.FirstName} {employeeName.Initial}. {employeeName.LastName}".ToLower()).Count;
            int firstMiddleLast = Regex.Matches(Text.ToLower(), $"{employeeName.FirstName} {employeeName.MiddleName} {employeeName.LastName}".ToLower()).Count;

            return firstLast + firstMiddleInitialLast + firstMiddleDotLast + firstMiddleLast;
        }

    }
}
