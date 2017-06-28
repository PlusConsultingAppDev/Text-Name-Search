using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NameSearch
{
    public class Article
    {
        public string filepath;

        public Article(string _filepath)
        {
            filepath = _filepath;
        }
        
        public void ParseArticle(out List<string> words)
        {
            string text;
            var fileStream = new FileStream(@filepath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            words = text.Split(' ').ToList();
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            string first, middle, last;
            Name.ParseName(out first, out middle, out last);

            List<string> words;
            Article A = new Article("file.txt");
            A.ParseArticle(out words);

            int count = 0;

            if (middle == "")
            {
                for (int i = 0; i < words.Count; i++)
                    if ((words[i] == first) && (words[i + 1] == last))
                        count++;
            }
            else
            {
                for (int i = 0; i < words.Count; i++)
                    if ((words[i] == first) && (words[i + 1] == middle) && (words[i + 2] == last))
                        count++;
            }

            Console.WriteLine(count);

            Console.ReadLine();
        }


        public static void ParseName(this string Name, out string first, out string middle, out string last)
        {
            string[] allnames;
            first = "";
            middle = "";
            last = "";

            Name = Name.Trim();

            allnames = Name.Split(' ');

            if (allnames.Length > 0)
                first = allnames[0];
            if (allnames.Length > 1)
                last = allnames[allnames.Length - 1];
            if (allnames.Length > 2)
                middle = string.Join(" ", allnames, 1, allnames.Length - 2);
        }
    }       
} //end