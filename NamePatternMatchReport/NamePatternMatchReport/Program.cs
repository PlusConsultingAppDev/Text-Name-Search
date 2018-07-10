using System;

namespace NamePatternMatchReport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                INameSearchUtil nameSearchUtil = new NameSearchUtil();
                nameSearchUtil.CreateNameCountReport(args);

            }
            catch (System.Exception exp)
            {
                Console.WriteLine($"Exception Occurred : {exp.Message}");
                
            }
        }
    }
}
