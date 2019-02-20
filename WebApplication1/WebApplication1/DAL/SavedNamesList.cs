using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.DAL
{
    public class SavedNamesList 
    {

        const string connectionString = @"Data Source=REBORN\SQLEXPRESS;Initial"
+ " Catalog=FullNameTable;User ID = whatnoaaa;Password=P@ssword13";
 

        const string GetNamesLisStringt = "SELECT * FROM SavedNames";
        const string AddNamesListString = "INSERT INTO SavedNames (FirstName, MiddleName, LastName) VALUES (@FirstName, @MiddleName, @LastName)";
        const string ClearListString = "DELETE  SavedNames";
        public string connection;

        public List<SearchClass> getNamesList (SearchClass results)
        {
            List<SearchClass> ResultsList = new List<SearchClass>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ResultsList = connection.Query<SearchClass>(GetNamesLisStringt).ToList();

                return ResultsList;
            }



           
        }

        public List<SearchClass> AddNamesList (SearchClass userEntry)
        {
            List<SearchClass> ResultsList = new List<SearchClass>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Dictionary<string, object> dynamicParameterArgsAddNamesList = new Dictionary<string, object>();
                dynamicParameterArgsAddNamesList.Add("@FirstName", userEntry.FirstName);
                dynamicParameterArgsAddNamesList.Add("@MiddleName", userEntry.MiddleName);
                dynamicParameterArgsAddNamesList.Add("@LastName", userEntry.LastName);


                ResultsList = connection.Query<SearchClass>(AddNamesListString, new DynamicParameters(dynamicParameterArgsAddNamesList)).ToList();


            }




            return ResultsList;
        }

        public void ClearNamesList()
        {
            List<SearchClass> ResultsList = new List<SearchClass>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query<SearchClass>(ClearListString);


            }




            return;
        }


























    }
}
