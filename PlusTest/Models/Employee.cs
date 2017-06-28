using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace PlusTest.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        [StringLength(100, ErrorMessage = "Middle name cannot be longer than 100 characters.")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        public List<string> NamePermutations {
            get
            {
                return new List<string>() { this.FirstName + " " + this.LastName,
                    this.FirstName + " " + this.MiddleName + " " + this.LastName,
                    this.FirstName + " " + this.MiddleName.Substring(0,1) + " " + this.LastName,
                    this.FirstName + " " + this.MiddleName.Substring(0,1) + ". " + this.LastName};
            }
        }

        public Employee()
        {
        }

        public Employee(int id)
        {
            Employee tmp = new Employee();
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                tmp = conn.Query<Employee>("SELECT [ID],[FirstName],[MiddleName],[LastName] FROM [alakhani].[Employees] WHERE ID = @id", new { id = id}).FirstOrDefault();
                conn.Close();
            }

            this.ID = tmp.ID;
            this.FirstName = tmp.FirstName;
            this.MiddleName = tmp.MiddleName;
            this.LastName = tmp.LastName;
        }

        public static List<Employee> GeAll()
        {
            var listOfAllEmployees = new List<Employee>();
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                listOfAllEmployees = conn.Query<Employee>("SELECT [ID],[FirstName],[MiddleName],[LastName] FROM [alakhani].[Employees]").ToList();
                conn.Close();
            }

            return listOfAllEmployees;

        }

        public void Insert()
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                conn.Query<Employee>("INSERT INTO [alakhani].[Employees] ([FirstName],[MiddleName],[LastName]) VALUES (@first, @middle, @last)", new { first = this.FirstName, middle = this.MiddleName, last = this.LastName });
                conn.Close();
            }

        }

        public void Update()
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                conn.Query<Employee>("UPDATE [alakhani].[Employees] SET [FirstName] = @first,[MiddleName] = @middle,[LastName] = @last WHERE ID = @id", new { id = this.ID, first = this.FirstName, middle = this.MiddleName, last = this.LastName });
                conn.Close();
            }

        }

        public void Delete()
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                conn.Query<Employee>("DELETE [alakhani].[Employees] WHERE ID = @id", new { id = this.ID });
                conn.Close();
            }

        }

    }
}