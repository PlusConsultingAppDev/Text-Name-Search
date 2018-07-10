using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeeSearch_CommonUtility.Article;
using EmployeeSearch_CommonUtility.General;
using EmployeeSearch_CommonUtility.MiddleNames;

namespace EmployeeNameSearchApp
{
    /// <summary>
    /// frm class for input the employee names and display the results in Employee listview 
    /// </summary>
    public partial class frmEmployeeNameSearch : Form
    {

        public frmEmployeeNameSearch()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Search method is for retrive the EmployeeNames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String sEmpNames = "";
                lstEmployeeNamesList.Clear();
                List<EmployeeNameSerachFilters> empNameFilter = new List<EmployeeNameSerachFilters>();
                sEmpNames = txtMulEmployeeNames.Text.Trim().Replace("\r\n", ",");
                //  string sEmployeeName = sEmpNames.Replace("\r","").Trim();
                List<string> sEmployeeList = sEmpNames.Trim().Split(',').ToList();

                for (int i = 0; i < sEmployeeList.Count; i++)
                {
                    var EmpNames = sEmployeeList[i].Split(' ');

                    if (EmpNames.Length > 2)
                    {
                        for (int j = 0; j < EmpNames.Length; j++)
                        {

                            empNameFilter.Add(new EmployeeNameSerachFilters(EmpNames[j], EmpNames[j + 1], EmpNames[j + 2]));
                            break;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < EmpNames.Length; j++)
                        {
                            EnumEmployeeFirstNames CFirstname = EnumEmployeeFirstNames.Connor;

                            EnumEmployeeFirstNames DFirstName = EnumEmployeeFirstNames.David;

                            EnumEmployeeFirstNames SFirstName = EnumEmployeeFirstNames.Seth;


                            EnumEmployeeLastNames BLastname = EnumEmployeeLastNames.Black;

                            EnumEmployeeLastNames GLastName = EnumEmployeeLastNames.Greenly;

                            EnumEmployeeLastNames SLatName = EnumEmployeeLastNames.Smith;

                            if (EmpNames[j].ToString() == CFirstname.ToString() && EmpNames[j + 1].ToString() == SLatName.ToString())
                            {
                                EnumEmployeeMiddleNames GMiddle = EnumEmployeeMiddleNames.Gary;
                                var csMiddle = GMiddle.ToString();
                                empNameFilter.Add(new EmployeeNameSerachFilters(EmpNames[j], csMiddle, EmpNames[j + 1]));
                                break;
                            }
                            else if (EmpNames[j].ToString() == SFirstName.ToString() && EmpNames[j + 1].ToString() == GLastName.ToString())
                            {
                                EnumEmployeeMiddleNames DMiddle = EnumEmployeeMiddleNames.David;
                                var sgMiddle = DMiddle.ToString();
                                empNameFilter.Add(new EmployeeNameSerachFilters(EmpNames[j], sgMiddle, EmpNames[j + 1]));
                                break;
                            }
                            else if (EmpNames[j].ToString() == DFirstName.ToString() && EmpNames[j + 1].ToString() == BLastname.ToString())
                            {
                                EnumEmployeeMiddleNames wMiddle = EnumEmployeeMiddleNames.Warren;
                                var dbMiddle = wMiddle.ToString();
                                empNameFilter.Add(new EmployeeNameSerachFilters(EmpNames[j], dbMiddle, EmpNames[j + 1]));
                                break;
                            }


                        }

                    }




                }
                List<string> emplistItems = ArticleOperations.GetEmpNamesFromArticleContent(empNameFilter);

                foreach (var item in emplistItems)
                {
                    lstEmployeeNamesList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void lstEmployeeNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEmployeeNameSearch_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
