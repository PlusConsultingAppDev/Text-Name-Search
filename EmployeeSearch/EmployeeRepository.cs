using EmployeeSearch.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeSearch
{
    public class EmployeeRepository
    {
        public DataTable GetAllEmployees()
        {
            //List<Employee> employeesTemp = new List<Employee>();

            //Employee employee1 = new Employee() { FirstName = "Connor", MiddleName= "Gary",LastName= "Smith" };
            //Employee employee2 = new Employee() { FirstName = "Seth", MiddleName = "David", LastName = "Greenly" };
            //Employee employee3 = new Employee() { FirstName = "David", MiddleName = "Warren", LastName = "Black" };

            //employeesTemp.Add(employee1);
            //employeesTemp.Add(employee2);
            //employeesTemp.Add(employee3);

            //return employeesTemp;

            DataTable empTable = new DataTable("Employees");
            DataColumn dtColumn;
            DataRow myDataRow;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.Caption = "FirstName";
             
            empTable.Columns.Add(dtColumn);
   
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "MiddleName";
            dtColumn.Caption = "MiddleName";
              
            empTable.Columns.Add(dtColumn);
    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "LastName";
     
            empTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Count";
            dtColumn.Caption = "Count";

            empTable.Columns.Add(dtColumn);


            myDataRow = empTable.NewRow();
            myDataRow["FirstName"] = "Connor";
            myDataRow["MiddleName"] = "Gary";
            myDataRow["LastName"] = "Smith";
            myDataRow["Count"] = 0;
            empTable.Rows.Add(myDataRow);

            myDataRow = empTable.NewRow();
            myDataRow["FirstName"] = "Seth";
            myDataRow["MiddleName"] = "David";
            myDataRow["LastName"] = "Greenly";
            myDataRow["Count"] = 0;
            empTable.Rows.Add(myDataRow);

            myDataRow = empTable.NewRow();
            myDataRow["FirstName"] = "David";
            myDataRow["MiddleName"] = "Warren";
            myDataRow["LastName"] = "Black";
            myDataRow["Count"] = 0;
            empTable.Rows.Add(myDataRow);


            return empTable;
        }
    }
}