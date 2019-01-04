using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.SearchCritera
{
    [DataContract]
    public class Name : ISearchItem
    {
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string MiddleName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public Name[] Aliases;

        public Name(string firstName, string lastName) : this(firstName, null, lastName) { }
        
        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string Key => string.IsNullOrEmpty(MiddleName)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";

        public int Search(string content)
        {
            Validate();
            int hits = 0;
            var patterns = GetPatterns();
            foreach (var pattern in patterns)
            {
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                hits += regex.Matches(content).Count;
            }

            if (Aliases != null)
            {
                foreach (var pattern in Aliases.SelectMany(alias => alias.GetPatterns()))
                {
                    var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    hits += regex.Matches(content).Count;
                }
            }

            return hits;
        }

        private List<string> GetPatterns()
        {
            var patterns = new List<string> {$"{FirstName} {LastName}"};

            if (!string.IsNullOrEmpty(MiddleName))
            {
                patterns.Add($"{FirstName} {MiddleName} {LastName}");

                var middleInitial = MiddleName[0];
                patterns.Add($"{FirstName} {middleInitial}\\.? {LastName}");
            }

            return patterns;
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                throw new SearchException("Name is invalid");

            if(!string.IsNullOrEmpty(MiddleName) && MiddleName.StartsWith("."))
                throw new SearchException("Name is invalid");
        }
    }
}