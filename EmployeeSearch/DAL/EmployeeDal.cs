using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmployeeSearch.Models;
namespace EmployeeSearch.Dal
{
    public class EmployeeDal
    {
        
     public List<string> list = new List<string>();
        //static list (for now)
        public EmployeeDal ()
        {
            list.Add("Connor Gary Smith");
            list.Add("Seth David Greenly");
            list.Add("David Warren Black");
        }
        /*TODO:
         * EF connect to SQL Server to get updated list
         */
        
    }
}