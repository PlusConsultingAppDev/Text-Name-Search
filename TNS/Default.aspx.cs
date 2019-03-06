using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using TNSLibrary.Pattern;
using TNSLibrary.Type;

public partial class _Default : System.Web.UI.Page {
    static List<Employee> employeeList = new List<Employee>();  // List of all employees to get updated client side
    IPatternChecker patternChecker = new NamePatternChecker();  // Name pattern checker object

    protected void Page_Load(object sender, EventArgs e) {
        
    }

    protected void SubmitButton_Click(object sender, EventArgs e) {
        DataTable dt = new DataTable();
        dt.Columns.Add("Employee Name");
        dt.Columns.Add("Variations Found");
        dt.Columns.Add("Occurrences");

        foreach (Employee employee in employeeList) {
            DataRow row = dt.NewRow();
            int occurences = patternChecker.MatchPatterns(employee, InputText.Value);
            row[0] = employee.ToString();
            row[1] = employee.GetVariations();
            row[2] = occurences;
            dt.Rows.Add(row);
        }

        ResultsGrid.DataSource = dt;
        ResultsGrid.DataBind();
    }

    [WebMethod]
    public static void UpdateEmployees(string[] employees) {
        employeeList.Clear();
        for (int i = 0; i < employees.Length; i++) {
            string[] names = employees[i].Split();
            Employee e = new Employee(names[0], names[1], names[2]);
            employeeList.Add(e);
        }
    }
}