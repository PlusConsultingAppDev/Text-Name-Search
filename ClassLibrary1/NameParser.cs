using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TextNameSearchEngine
{
    public class NameParser
    {
        public List<Employee> FindNamesInArticle(List<Employee> EmployeeList, string Article)
        {
            List<Employee> eList = new List<Employee>();

            foreach (Employee emp in EmployeeList)
            {
                eList.Add(FindNameInArticle(emp, Article));
            }

            return eList;
        }

        public Employee FindNameInArticle(Employee Emp, string Article)
        {
            int FirstLast = NameInArticleCount(Emp.FirstName + " " + Emp.LastName, Article);
            int FirstMLast = NameInArticleCount(Emp.FirstName + " " + Emp.MiddleInitial + " " + Emp.LastName, Article);
            int FirstMDotLast = NameInArticleCount(Emp.FirstName + " " + Emp.MiddleInitial + "." + Emp.LastName, Article);
            int FirstMiddleLast = NameInArticleCount(Emp.FirstName + " " + Emp.MiddleName + " " + Emp.LastName, Article);

            Emp.Count = FirstLast + FirstMLast + FirstMDotLast + FirstMiddleLast;

            return Emp;
        }

        public int NameInArticleCount(string Name, string Article)
        {
            return Regex.Matches(Article.ToLower(), Name.ToLower()).Count;
        }
    }
}
