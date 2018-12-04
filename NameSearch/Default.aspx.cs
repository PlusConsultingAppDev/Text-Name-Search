using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string InputStr = txtInputstring.Text;
            string name = txtSearchName.Text;
            string[] arrName = name.Split(null);

            if (arrName.Length != 3) { 
                lblName.Text = "*Please enter valid full name!";
                return;
            }

            string fname = arrName[0];
            char mi = (arrName[1])[0];
            string lname = arrName[2];

            string Pattern = @"" + fname + @"\s((" + mi + @"(\.))?\w*\s)?" + lname;

            MatchCollection result = Regex.Matches(InputStr, Pattern);

            lblName.Text = name + " (" + result.Count + ")";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}