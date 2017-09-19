using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Text_Name_Search
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<NameOccurrences> results = new List<NameOccurrences> {
            new NameOccurrences("Connor Gary Smith", 0),
            new NameOccurrences("Seth David Greenly", 0),
            new NameOccurrences("David Warren Black", 0)
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                refreshResults();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string[] lines = txtSearch.Text.Split('\n');
            foreach (NameOccurrences name in results)
            {
                string[] subNames = name.name.Split(' ');
                string firstName = subNames[0];
                string middleName = subNames[1];
                string middleInitial = middleName.Substring(0, 1);
                string lastName = subNames[2];
                foreach (string line in lines)
                {
                    string[] words = line.Split(' ');
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (
                            (words[i] == firstName && words[i + 1] == lastName)
                            || (words[i] == firstName && words[i + 1] == middleInitial && words[i + 2] == lastName)
                            || (words[i] == firstName && words[i + 1] == middleInitial + '.' && words[i + 2] == lastName)
                            || (words[i] == firstName && words[i + 1] == middleName && words[i + 2] == lastName)
                        ) { name.occurrences++; }
                    }
                }
            }
            refreshResults();
            pnlResults.Visible = true;
        }

        public void refreshResults()
        {
            rptResults.DataSource = results;
            rptResults.DataBind();
        }
    }

    public class NameOccurrences
    {
        public string name { get; set; }
        public int occurrences { get; set; }
        public NameOccurrences(string name, int occurrences)
        {
            this.name = name;
            this.occurrences = occurrences;
        }
    }
}