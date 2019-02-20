using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class NameSearcher 
    {






        public SearchClass DoSearch (SearchClass userEntry)
           ////Searches the text file for the names
        {
            using (StreamReader sr = new StreamReader(@"D:\workspace\TNS\WebApplication1\WebApplication1\Text.txt"))
            {
                userEntry.FirstAndLastAmount = 0;
                userEntry.FullNameAmount = 0;
                userEntry.MiddleInitalDotLastNameAmount = 0;
                userEntry.MiddleInitialLastNameAmount = 0;
                
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().ToLower();
                    if (line.Contains(userEntry.FirstAndLastName.ToLower().Trim()))
                    {
                        userEntry.FirstAndLastAmount = userEntry.FirstAndLastAmount + 1;
                    }
                    if (line.Contains(userEntry.FullName.ToLower().Trim()))
                    {
                        userEntry.FullNameAmount = userEntry.FullNameAmount + 1;
                    }
                    if (line.Contains(userEntry.MidileInitialDotLastName.ToLower().Trim()))
                    {
                        userEntry.MiddleInitalDotLastNameAmount = userEntry.MiddleInitalDotLastNameAmount + 1;
                    }
                    if (line.Contains(userEntry.MiddleInitialLastName.ToLower().Trim()))
                    {
                        userEntry.MiddleInitialLastNameAmount = userEntry.MiddleInitialLastNameAmount + 1; 
                    }
                }
            }

            return userEntry;
        }
    }
}
