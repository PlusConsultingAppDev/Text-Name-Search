using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string CGarySmith = "Connor Gary Smith";
            string SDavidGreenly = "Seth David Greenly";
            string DWarrenBlack = "David Warren Black";
            string Count1 = TextFileSearch(CGarySmith);
            string Count2 = TextFileSearch(SDavidGreenly);
            string Count3 = TextFileSearch(DWarrenBlack);
            string FullText = File.ReadAllText("C://Users//amorrow//Desktop//NameSearch.txt");
            Console.WriteLine(FullText + "\n\n\n");
            Console.WriteLine(Count1 + "\n" + Count2 + "\n" + Count3);
        }
        private static string TextFileSearch(string Name)
        {
            int amount = 0;
            char delimitingChar = ' ';
            string[] SeperateName = Name.Split(delimitingChar);
            string FirstName = SeperateName[0];
            string MiddleName = SeperateName[1];
            string LastName = SeperateName[2];
            foreach (string line in File.ReadAllLines("C://Users//amorrow//Desktop//NameSearch.txt"))
            {
                if (line.Contains(FirstName) && line.Contains(LastName))
                {
                    amount++;
                }
            }
            string NameAndAmount = Name + " (" + amount + ")";
            return NameAndAmount;
        }
    }
}
