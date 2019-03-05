using System;
using System.Text.RegularExpressions;
using TNSLibrary.Type;

namespace TNSLibrary.Pattern {

    public class NamePatternChecker : IPatternChecker {

        /**
         * Finds matches of the following variations:
         * [First Name][Last Name]
         * [First Name][Middle Initial][Last Name]
         * [First Name][Middle Initial].[Last Name]
         * [First Name][Middle Name][Last Name]
         */
        public int MatchPatterns(Employee employee, string input) {
            string fName = employee.FirstName.ToLowerInvariant();
            string mName = employee.MiddleName.ToLowerInvariant();
            string lName = employee.LastName.ToLowerInvariant();
            string mInitial = mName.Substring(0, 1);
            string mInitialDot = mInitial + ".";

            // Regular expressions to match
            string fl = $"{fName} {lName}";
            string fmil = $"{fName} {mInitial} {lName}";
            string fmidl = $"{fName} {mInitialDot} {lName}";
            string fml = $"{fName} {mName} {lName}";

            int count = GetNumRegexMatches(employee, input, fl, fmil, fmidl, fml);

            return count;
        }

        public int MatchPatterns(Email email, string input) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loops through all the regex patterns and checks the number of occurences against
        /// the input string.
        /// </summary>
        /// <param name="employee">The employee to add variations of their found names</param>
        /// <param name="input">The input string to match against</param>
        /// <param name="patterns">The array of regex strings</param>
        /// <returns></returns>
        private int GetNumRegexMatches(Employee employee, string input, params string[] patterns) {
            int totalMatches = 0;
            for (int i = 0; i < patterns.Length; i++) {
                int regexMatches = Regex.Matches(input, patterns[i], RegexOptions.IgnoreCase).Count;
                if (regexMatches > 0) {
                    totalMatches += regexMatches;
                    employee.NameVariationsFounds.Add(patterns[i]);
                }
            }

            return totalMatches;
        }
    }
}
