using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.String;

namespace PlusTest.Models
{
    public class ResultsViewModel
    {
        public Dictionary<Employee, int> Results { get; set; }
        public string Text { get; set; }
        public string Message { get; set; }

        public ResultsViewModel()
        {
            this.Results = new Dictionary<Employee, int>();
            this.Message = Empty;
            this.Text = Empty;
        }
    }
}