using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeSearch.Dal
{
    public class EmployeeDal
    {
    	private List<string> EmployeeList;
    	private List<string> ValidSearchPatterns;
    	private string SearchText;
    	private int employeeResultsCount;
    	//constructor
        private EmployeeDal()
        {
            // Call getUpdatedEmployeeList: Data Access layer to retrieve list of employee search names
        	getUpdatedEmployeeList();
            // Call getUpdatedSearchScenarios: Data Access layer to retrieve list of Valid Search RegExpPatterns
        	getUpdatedSearchScenarios();
		}
		private getUpdatedEmployeeList()
		{
            /*TODO: 
            * call the database and get the newest list of employees to search
            * copy results to EmployeeList
            */
		}
		private getUpdatedSearchScenarios()
		{
            /*TODO: 
            * call the database and get a list of search possibities (regExp Search Patterns)
            * copy results to ValidSearchPatterns
            */
		}
    }
}