using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLib;

namespace EchoPlusSample
{
    /// <summary>
    /// Main Form UI Class object 
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search Button click event handler method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string results = "Name - Count\r\n======================\r\n";

            List<HumanBeing> humans = new List<HumanBeing>()
            {
                new HumanBeing("Connor","Gary","Smith"),
                new HumanBeing("Seth","David","Greenly"),
                new HumanBeing("David","Warren","Black")
            };

            string sourceString = SampleSourceData.GetSourceData();

            humans.ForEach(h => Search.GetNameCount(sourceString, h));
            foreach(HumanBeing h in humans)
            {
                var ret = Search.GetNameCount(sourceString, h);
                // Write out results
                results += String.Format("{0} - {1}\r\n", ret.Item1, ret.Item2);  
            }

            tbResults.Text = results;

        }
    }
}
