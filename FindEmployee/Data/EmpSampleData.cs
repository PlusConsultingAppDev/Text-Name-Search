using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FindEmployee.Models;

namespace FindEmployee.Data
{
    public static class EmpSampleData
    {
        public static List<GetEmpoyeeModel> GetEmployeesList()
        {
            var employees = new List<GetEmpoyeeModel>
            {
               new GetEmpoyeeModel() { Id = 1, Name = "Connor Gary Smith" },
               new GetEmpoyeeModel() { Id = 2, Name = "Seth David Greenl" },
               new GetEmpoyeeModel() { Id = 3, Name = "David Warren Black" },
               new GetEmpoyeeModel() { Id = 4, Name = "Connor Gary Smith"},
               new GetEmpoyeeModel() { Id = 5, Name = "Seth David Greenl" },
               new GetEmpoyeeModel() { Id = 6, Name = "David Warren Black" },
               new GetEmpoyeeModel() { Id = 7, Name = "David Warren Black" },
               new GetEmpoyeeModel() { Id = 8, Name = "David Warren Black" }
            };
  
            return employees;
        }
    }
}