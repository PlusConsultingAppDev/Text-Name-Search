using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLib
{
    /// <summary>
    /// Human Being Class
    /// </summary>
    public class HumanBeing
    {
        /// <summary>
        ///  First Name Property
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name Property
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name Property
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Constructor overload
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        public HumanBeing(string fName = "", string mName = "", string lName = "")
        {
            FirstName = fName;
            MiddleName = mName;
            LastName = lName;
        }
    }
}
