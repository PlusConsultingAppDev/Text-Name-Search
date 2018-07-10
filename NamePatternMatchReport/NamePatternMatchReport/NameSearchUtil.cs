using System;
using System.Text.RegularExpressions;

namespace NamePatternMatchReport
{
    public class NameSearchUtil : INameSearchUtil
    {
        public void CreateNameCountReport(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("The string content to be searched for names cannot be empty. Please provide correct value.");
                return;
            }

            if (string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("The name to be searched cannot be empty. Please provide correct .value");
                return;
            }
            string[] nameParts = new string[] { };
            string middleName = string.Empty;
            string firstName = string.Empty;
            string firstCharMiddleName = string.Empty;
            string lastName = string.Empty;
            string content = args[0];
            string name = args[1];

            nameParts = name.Split(new char[] { ' ' });
            middleName = nameParts.Length == 3 ? nameParts[1] : String.Empty;
            firstName = nameParts[0];
            firstCharMiddleName = middleName.Substring(0, 1);
            lastName = nameParts[2];
            MatchCollection collection = Regex.Matches(content, @firstName + " (" + middleName + @"[\s]?|" + firstCharMiddleName + @"\.?\s?)?" + lastName); /*@"[" + firstName + @"[ .]?" + firstMiddleNameChar +  @"|"  + middleName + @"]");*/
            Console.WriteLine($"{name} : {collection.Count}");
        }

    }

}
