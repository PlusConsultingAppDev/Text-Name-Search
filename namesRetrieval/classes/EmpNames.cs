using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namesRetrieval.classes
{
    public class EmpNames
    {
        private string _lname;
        private string _fname;
        private string _mname;
        private string _minit;
        public EmpNames (string fname, string mname, string lname)
        {
            _lname = lname;
            _fname = fname;
            _mname = mname;
            _minit = mname.Substring(0, 1);
        }
        
        public string retrieveFname()
        {
            return _fname;
        }

         

        
        public List<string> namesCollection()
        {
            var nameList = new List<string>();
            nameList.Add(GetFirstLastName());
            nameList.Add(GetFirstMidInitLastName());
            nameList.Add(GetFirstMidInitPtLastName());
            nameList.Add(GetFirstMiddleLastName());
            return nameList;
        }
        public string GetFirstLastName()
        {
            return _fname + " " + _lname;
        }

        public string GetFirstMidInitLastName()
        {
            return _fname + " " + _minit + " " + _lname;
        }

        public string GetFirstMidInitPtLastName()
        {
            return _fname + " " + _minit + ". " + _lname;
        }

        public string GetFirstMiddleLastName()
        {
            return _fname + " " + _mname + " " + _lname;
        }
    }
}
