using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmployeeSearch.Models
{
    public class Employee
    {
        public string EmployeeFName { get; set; }
        public string EmployeeMName { get; set; }
        public string EmployeeMi { get; set; }
        public string EmployeeLName { get; set; }
        public List<string> EmployeeResultsList { get; set; }

        public Employee(string txtEmployeeFullName)
        {
            parseEmployeeNameParts(); //populate employee object
            //  Combine the two in an active RegExp search of inputText
        }
        private void parseEmployeeNameParts()
        {
            /*TODO:
            * parse/extract the following from txtEmployeeFullName:
            *   EmployeeFName
            *   EmployeeMName
            *   EmployeeMi
            *   EmployeeLName
            *   
            */
        }
    }
    public class EmployeeSearch 
    {
        public string SearchText { get; set; }
        public EmployeeSearch(string inputSearchText)
        {
            SearchText = inputSearchText;
            mineInputTextUsingRegExpPatterns();
            /*TODO:
            * get fresh employee list Data Access Layer
            * get fresh search pattern list Data Access Layer
            * call mineInputTextUsingRegExpPatterns to populate and accumulate Employee Objects with the match count using regExp functionality
            */

        }
        private void mineInputTextUsingRegExpPatterns()
        {
            /*TODO
            * traverse the EmployeeList
                * for each employee name in the list,
                    * for each possible search combination, 
                        - dynamically construct the RegExp Pattern and apply to the input SearchText
                        - new up an Employee object
                        - add current result count from Match results to employeeResultsCount
                        - add current employee object to EmployeeResultsList collection
            */
        }

    }

}