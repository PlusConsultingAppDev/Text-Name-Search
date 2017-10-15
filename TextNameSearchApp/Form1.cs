using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextNameSearchEngine;

namespace TextNameSearchApp
{
    public partial class Form1 : Form
    {
        private List<Employee> Employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            //add an employee to the employee list
            Employee emp = new Employee();
            emp.FirstName = txtBxFirstName.Text.Trim();
            emp.MiddleName = txtBxMiddleName.Text.Trim();
            emp.LastName = txtBxLastName.Text.Trim();
            Employees.Add(emp);

            //update the employee list and clear the form
            UpdateEmployeeList();
            EmployeeFormClear();
        }

        private void btnSearchArticle_Click(object sender, EventArgs e)
        {
            try
            {
                //search through the article for the employees from the employe list
                NameParser npe = new NameParser();
                Employees = npe.FindNamesInArticle(Employees, txtBxArticleText.Text);

                //now display the search results 
                lblSearchResults.Text = "";
                foreach (Employee employee in Employees)
                {
                    lblSearchResults.Text = lblSearchResults.Text + employee.FullName + Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                //To Do: add error handling code
                MessageBox.Show("Sorry an error has occured.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /********************************************
             * Prepopulated the list of employees.  In a production application this list 
             * would be pulled from a database, web service or possibly from active directory.
             *******************************************/
            Employee emp = new Employee();
            emp.FirstName = "Connor";
            emp.MiddleName = "Gary";
            emp.LastName = "Smith";
            Employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "Seth";
            emp.MiddleName = "David";
            emp.LastName = "Greenly";
            Employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "David";
            emp.MiddleName = "Warren";
            emp.LastName = "Black";
            Employees.Add(emp);

            //update the employee list box with the employee list
            UpdateEmployeeList();
        }

        private void UpdateEmployeeList()
        {
            //clear the employee list control before repopulating
            lstBxEmployees.Items.Clear();

            //loop through the employees and add them to employee list box
            foreach(Employee employee in Employees)
            {
                lstBxEmployees.Items.Add(employee.FirstName + " " + employee.MiddleName + " " + employee.LastName);
            }
        }

        private void EmployeeFormClear()
        {
            //clears the employee form
            txtBxFirstName.Text = "";
            txtBxMiddleName.Text = "";
            txtBxLastName.Text = "";
        }
    }
}
