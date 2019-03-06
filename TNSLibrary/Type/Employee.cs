using System.Collections.Generic;
using System.Text;

namespace TNSLibrary.Type {

    public class Employee {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public HashSet<string> NameVariationsFounds { get; }

        public Employee(string firstName, string middleName, string lastName) {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NameVariationsFounds = new HashSet<string>();
        }

        /// <summary>
        /// Overriden ToString() method to get an employees full name.
        /// </summary>
        /// <returns>The full name</returns>
        public override string ToString() {
            return FirstName + " " + MiddleName + " " + LastName;
        }

        /// <summary>
        /// Returns a comma delimited string of all name variations found.
        /// </summary>
        /// <returns>String of name variations</returns>
        public string GetVariations() {
            StringBuilder sb = new StringBuilder();
            foreach (string name in NameVariationsFounds) {
                sb.Append(name + ", ");
            }

            string variations;
            if (sb.Length > 0) {
                variations = sb.ToString().Substring(0, sb.Length - 2);
            } else {
                variations = "";
            }

            return variations;
        }
    }
}
