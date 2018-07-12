using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the comma separated Names you want to search(No spaces after comma)");
            string EmployeeNames = Console.ReadLine();
            List<string> employeeFullNames = EmployeeNames.Split(',').ToList();
            Console.WriteLine("Enter the text you want the names to be searched on(No Line gaps)");
            byte[] inputBuffer = new byte[8190];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string text = Console.ReadLine();

            EmployeeNameFind finder = new EmployeeNameFind();
            finder.FindNameInText(employeeFullNames, text);
        }
    }
}
