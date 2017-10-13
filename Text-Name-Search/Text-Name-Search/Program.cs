using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Text_Name_Search.Models;

namespace Text_Name_Search
{
    class Program
    {

        #region Error Logging
        private static Logger _mLogger;
        public static Logger MLogger
        {
            get
            {
                if (_mLogger == null)
                {
                    _mLogger = LogManager.GetCurrentClassLogger();
                }
                return _mLogger;
            }
            set { _mLogger = value; }
        }
        #endregion

        static void Main(string[] args)
        {
            var banner = string.Format("{0}\r\nText Name Search\r\n{0}", "".PadLeft(80, '-'));
            MLogger.Info($"{banner}");
            try
            {
                if (args == null || !args.Any() || args.Count() != 2)
                {
                    throw new ArgumentNullException("args", "Filename(s) not specified");
                }
                foreach (var arg in args)
                {
                    if (!File.Exists(arg))
                        throw new FileNotFoundException("Specified file is missing", arg);
                }
                List<TextName> names = new List<TextName>();
                if (File.Exists(args[0]))
                {
                    names = File.ReadAllLines(args[0]).ToList()
                        .ConvertAll(line => new TextName(line));
                }
                using (var reader = new StreamReader(args[1]))
                {
                    var line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Trim() == "") continue;
                        names.ForEach(name => name.Count(line));
                    }
                }
                var results = names.Aggregate(new StringBuilder(), (a, b) =>
                a.AppendFormat("{0}\t({1})\r\n", b.FML, b.Count()));
                MLogger.Info($"{results}");
            }
            catch (Exception ex)
            {
                MLogger.Error(ex, ex.Message);
            }
            Console.ReadLine();
        }
    }
}
