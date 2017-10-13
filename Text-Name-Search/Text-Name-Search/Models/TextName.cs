using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Name_Search.Models
{
    class TextName
    {
        #region Properties
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public string InitialPeriod
        {
            get
            {
                return string.IsNullOrEmpty(Middle)
                    ? ""
                    : string.Format("{0}.", Middle.Substring(0, 1));
            }
        }

        public string Initial
        {
            get
            {
                return string.IsNullOrEmpty(Middle)
                    ? ""
                    : string.Format("{0}", Middle.Substring(0, 1));
            }
        }
        #endregion

        public TextName(string line)
        {
            var data = Regex.Split(line, @"\s+").ToList();
            First = data.First();
            Last = data.Last();
            Middle = data.Count == 3 ? data.ElementAt(1) : "";
            FML = string.Format($"{First} {Middle} {Last}");
            FL = string.Format($"{First} {Last}");
            FMIL = string.Format($"{First} {Initial} {Last}");
            FMIPL = string.Format($"{First} {InitialPeriod} {Last}");
        }

        private int _count = 0;
        public string FML { get; set; }
        public string FL { get; set; }
        public string FMIL { get; set; }
        public string FMIPL { get; set; }

        public bool Contains(string line)
        {
            return (line.Contains(FML)
                || line.Contains(FMIPL)
                || line.Contains(FMIL)
                || line.Contains(FL));
        }

        public int Count(string line)
        {
            if (!Contains(line)) return _count;
            _count += Regex.Matches(line, FML).Count
                + Regex.Matches(line, FL).Count
                + Regex.Matches(line, FMIL).Count
                + Regex.Matches(line, FMIPL).Count;
            return _count;
        }

        public int Count()
        {
            return _count;
        }
    }
}
