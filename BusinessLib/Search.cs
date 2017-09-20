using System;
using System.Text.RegularExpressions;

namespace BusinessLib
{
    /// <summary>
    /// Search Class Implementation
    /// </summary>
    public class Search
    {
        /// <summary>
        /// GetNameCount Overload that accepts Human Being Objects
        /// </summary>
        /// <param name="humanBeing"></param>
        /// <returns></returns>
        public static Tuple<string, int> GetNameCount(string sourceString, HumanBeing humanBeing)
        {
            return GetNameCount(sourceString, humanBeing.FirstName, humanBeing.MiddleName, humanBeing.LastName);
        }

        /// <summary>
        /// Get count of name in source string using indicated policy rules.
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public static Tuple<string, int> GetNameCount(string sourceString, string fName, string mName, string lName)
        {
            // Very basic argument checking, esp. checking for explosive nulls.
            if (String.IsNullOrEmpty(fName)) fName = "";
            if (String.IsNullOrEmpty(mName)) mName = "";
            if (String.IsNullOrEmpty(lName)) lName = "";

            // Case: [First Name] [Last Name]  e.g. Connor Smith
            int cnt = Regex.Matches(sourceString, string.Format("{0} {1}", fName, lName), RegexOptions.IgnoreCase).Count;

            // Do we even have a middle name indicated in arguments?
            if (mName.Length > 0)
            {
                // Case: [First Name] [Middle Initial] [Last Name] e.g. Connor Gary Smith
                cnt += Regex.Matches(sourceString, string.Format("{0} {1} {2}", fName, mName, lName), RegexOptions.IgnoreCase).Count;

                // Case: [First Name] [Middle Initial]. [Last Name]  e.g. Case Connor G. Smith
                cnt += Regex.Matches(sourceString, string.Format("{0} {1}. {2}", fName, mName.Substring(0, 1), lName), RegexOptions.IgnoreCase).Count;

                // Case: [First Name] [Middle Initial] [Last Name]  e.g. Case Connor G Smith (this is the case they missed in the question and got 2 instead of 3)
                cnt += Regex.Matches(sourceString, string.Format("{0} {1} {2}", fName, mName.Substring(0, 1), lName), RegexOptions.IgnoreCase).Count;
            }

            return new Tuple<string, int>(String.Format("{0} {1} {2}", fName, mName, lName), cnt);
        }
    }
}
