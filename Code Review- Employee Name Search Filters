using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeSearch_CommonUtility.General
{
    /// <summary>
    /// Class for the Employee Name search Filters 
    /// </summary>
    public class EmployeeNameSerachFilters
    {
        private string FirstName;
        private string MiddleName;
        private string MiddleInitName;
        private string MiddleInitDName;
        private string LastName;

        /// <summary>
        /// Retrives Employee Name search Filters
        /// </summary>
        /// <param name="_FirstName">FirstName</param>
        /// <param name="_MiddleName">MiddleName</param>
        /// <param name="_LastName">LastName</param>
        public EmployeeNameSerachFilters(string _FirstName, string _MiddleName, string _LastName)
        {
            try
            {
                FirstName = _FirstName;
                MiddleName = _MiddleName;

                if (_MiddleName != string.Empty)
                {
                    MiddleInitDName = _MiddleName.Substring(0, 1);
                    MiddleInitName = _MiddleName.Substring(0, 1);
                }
                LastName = _LastName;
            }
            catch (Exception excepion)
            {
                string strerr = excepion.Message;
            }
        }

        /// <summary>
        /// Get FirstName
        /// </summary>
        /// <returns>FirstName</returns>
        public string GetFirstName()
        {
            return FirstName;
        }
        /// <summary>
        /// Get First and Last Name
        /// </summary>
        /// <returns></returns>
        public string GetFirstLastName()
        {
            return FirstName + " " + LastName;
        }
        /// <summary>
        /// Get First Mid Last Name
        /// </summary>
        /// <returns></returns>
        public string GetFstMidLastName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
        /// <summary>
        /// Get First Mid Initial Last Names
        /// </summary>
        /// <returns></returns>
        public string GetFstMidInitLastName()
        {
            return FirstName + " " + MiddleInitName + " " + LastName;
        }
        /// <summary>
        /// Get First Mid Initial D Last Name
        /// </summary>
        /// <returns></returns>
        public string GetFstMidInitDLastName()
        {
            return FirstName + " " + MiddleInitDName + ". " + LastName;
        }

    }
}
