using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Name_Search
{
    public partial class Form1 : Form
    {
        public List<EmployeeData> employeesData;
        public bool heightSet = false;
        public Form1()
        {
            InitializeComponent();
            dgvNames.Visible = false;
            EmployeesData();
            this.Height = this.Height - dgvNames.Height - 5;
        }

        public void EmployeesData()
        {
            employeesData = new List<EmployeeData>();
            employeesData.Add(new EmployeeData { Id = 1, FirstName = "Connor", MiddleName = "Gary", LastName = "Smith" });
            employeesData.Add(new EmployeeData { Id = 2, FirstName = "Connor", MiddleName = "Gary", LastName = "Smith" });
            employeesData.Add(new EmployeeData { Id = 3, FirstName = "Seth", MiddleName = "David", LastName = "Greenly" });
            employeesData.Add(new EmployeeData { Id = 4, FirstName = "Seth", MiddleName = "David", LastName = "Greenly" });
            employeesData.Add(new EmployeeData { Id = 4, FirstName = "Seth", MiddleName = "Gary", LastName = "Greenly" });
            employeesData.Add(new EmployeeData { Id = 4, FirstName = "Seth", MiddleName = "Warren", LastName = "Greenly" });
            employeesData.Add(new EmployeeData { Id = 5, FirstName = "David", MiddleName = "Gary", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 6, FirstName = "David", MiddleName = "Warren", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 7, FirstName = "David", MiddleName = "Warren", LastName = "Smith" });
            employeesData.Add(new EmployeeData { Id = 8, FirstName = "David", MiddleName = "Smith", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 8, FirstName = "David", MiddleName = "S.", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 8, FirstName = "David", MiddleName = "W.", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 8, FirstName = "David", MiddleName = "S", LastName = "Black" });
            employeesData.Add(new EmployeeData { Id = 8, FirstName = "David", MiddleName = "W", LastName = "Black" });
        }

        public class EmployeeData
        {
            public int Id { get; set; }
            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtMiddleName.Text) && string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("No Data Found!");
            }
            var employeeDataToBind = employeesData.Where(x => ((!string.IsNullOrEmpty(txtFirstName.Text) && x.FirstName.ToLower().Contains(txtFirstName.Text.ToLower())) && (!string.IsNullOrEmpty(txtMiddleName.Text) && x.MiddleName.Replace(".", "").ToLower().Contains(txtMiddleName.Text.Replace(".", "").ToLower())) && (!string.IsNullOrEmpty(txtLastName.Text) && x.LastName.ToLower().Contains(txtLastName.Text.ToLower()))) || (string.IsNullOrEmpty(txtMiddleName.Text) && (!string.IsNullOrEmpty(txtFirstName.Text) && x.FirstName.ToLower().Contains(txtFirstName.Text.ToLower())) && (!string.IsNullOrEmpty(txtLastName.Text) && x.LastName.ToLower().Contains(txtLastName.Text.ToLower())))).ToList();

            var filteredEmpData = new List<FilteredEmployeeData>();
            foreach (var employee in employeeDataToBind)
            {
                var filEmpData = new FilteredEmployeeData();
                filEmpData.FirstName = employee.FirstName;
                filEmpData.MiddleName = employee.MiddleName;
                filEmpData.LastName = employee.LastName;
                filteredEmpData.Add(filEmpData);
            }
            filteredEmpData.Add(new FilteredEmployeeData());
            dgvNames.DataSource = filteredEmpData;

            dgvNames[0, dgvNames.Rows.Count - 1].Value = "Total Sum";
            dgvNames.Rows[dgvNames.Rows.Count - 1].Cells[0].Style.BackColor = Color.Yellow;
            dgvNames.Rows[dgvNames.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;

            dgvNames[1, dgvNames.Rows.Count - 1].Value = (filteredEmpData.Count() - 1).ToString();

            dgvNames.Refresh();
            if (!heightSet)
            {
                this.Height = this.Height + dgvNames.Height + 5;
                heightSet = true;
            }

            this.Refresh();
            dgvNames.Visible = true;
        }

        public class FilteredEmployeeData
        {
            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }
        }
    }
}
