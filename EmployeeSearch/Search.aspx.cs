using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeSearch
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            var emp = new EmployeeRepository();

            var dtAllEmployees = emp.GetAllEmployees();

            DataTable dt = GetFilterData(dtAllEmployees);

            gvResultData.DataSource = dt;

            gvResultData.DataBind();
        }

        private DataTable GetFilterData(DataTable dtAllEmployees)
        {
            DataTable dtTemp = new DataTable();
            DataColumn dtColumn;
            DataRow myDataRow;

            string FirstName = TextBox1.Text;
            string MiddleName = TextBox2.Text;
            string LastName = TextBox3.Text;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.Caption = "FirstName";

            dtTemp.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "MiddleName";
            dtColumn.Caption = "MiddleName";

            dtTemp.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "LastName";

            dtTemp.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Count";
            dtColumn.Caption = "Count";

            dtTemp.Columns.Add(dtColumn);

            int FinalMatchCount = 0;

            foreach (DataRow row in dtAllEmployees.Rows)
            {
                int count = Convert.ToInt32(row["Count"]);
                string fName = row["FirstName"].ToString();
                string mName = row["MiddleName"].ToString();
                string lName = row["LastName"].ToString();
                string middleInitialDot = String.Empty;
                string middleInitial = String.Empty;

                if (!String.IsNullOrEmpty(MiddleName))
                    middleInitial = String.IsNullOrEmpty(MiddleName) ? MiddleName.Substring(0, 1) : String.Empty;

                if (!String.IsNullOrEmpty(middleInitial))
                    middleInitialDot = middleInitial + ".";

                //[First Name] [Last Name]
                //[First Name] [Middle Initial] [Last Name]
                //[First Name] [Middle Initial]. [Last Name]
                //[First Name] [Middle Name] [Last Name]

                if (!(String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName)))
                {
                    if (FirstName.Equals(fName, StringComparison.OrdinalIgnoreCase) && LastName.Equals(lName, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                        FinalMatchCount++;
                        //1st Match found, add to the reult data
                        myDataRow = dtTemp.NewRow();
                        myDataRow["FirstName"] = fName;
                        myDataRow["MiddleName"] = mName;
                        myDataRow["LastName"] = lName;
                        myDataRow["Count"] = FinalMatchCount;
                        dtTemp.Rows.Add(myDataRow);
                        continue;
                    }
                }

                if (!(String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(LastName)))
                {
                    if (FirstName.Equals(fName, StringComparison.OrdinalIgnoreCase) && MiddleName.Equals(mName, StringComparison.OrdinalIgnoreCase)
                        && LastName.Equals(lName, StringComparison.OrdinalIgnoreCase))
                    {
                        //Fourth condition match
                        count++;
                        FinalMatchCount++;
                        //1st Match found, add to the reult data
                        myDataRow = dtTemp.NewRow();
                        myDataRow["FirstName"] = fName;
                        myDataRow["MiddleName"] = mName;
                        myDataRow["LastName"] = lName;
                        myDataRow["Count"] = FinalMatchCount;
                        dtTemp.Rows.Add(myDataRow);
                        continue;
                    }
                }

                if (!(String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(LastName)))
                {
                    if (FirstName.Equals(fName, StringComparison.OrdinalIgnoreCase) && middleInitial.Equals(mName.Substring(0,1), StringComparison.OrdinalIgnoreCase)
                        && LastName.Equals(lName, StringComparison.OrdinalIgnoreCase))
                    {
                        //second condition match
                        count++;
                        FinalMatchCount++;
                        //1st Match found, add to the reult data
                        myDataRow = dtTemp.NewRow();
                        myDataRow["FirstName"] = fName;
                        myDataRow["MiddleName"] = mName;
                        myDataRow["LastName"] = lName;
                        myDataRow["Count"] = FinalMatchCount;
                        dtTemp.Rows.Add(myDataRow);
                        continue;
                    }
                }

                if (!(String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(LastName)))
                {
                    if (FirstName.Equals(fName, StringComparison.OrdinalIgnoreCase) && middleInitialDot.Equals(mName.Substring(0, 1) + ".", StringComparison.OrdinalIgnoreCase)
                        && LastName.Equals(lName, StringComparison.OrdinalIgnoreCase))
                    {
                        //second condition match
                        count++;
                        FinalMatchCount++;
                        //1st Match found, add to the reult data
                        myDataRow = dtTemp.NewRow();
                        myDataRow["FirstName"] = fName;
                        myDataRow["MiddleName"] = mName;
                        myDataRow["LastName"] = lName;
                        myDataRow["Count"] = FinalMatchCount;
                        dtTemp.Rows.Add(myDataRow);
                        continue;
                    }
                }

            }

            return dtTemp;
        }
    }
}