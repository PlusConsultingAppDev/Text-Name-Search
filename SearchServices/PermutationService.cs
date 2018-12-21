using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SearchServices
{
    public class PermutationService
    {
        private readonly List<string> _permutationsList;
        private readonly string _name;

        public PermutationService(string name)
        {
            _name = name;
            _permutationsList = new List<string>();
        }

        public IList GeneratePermutations()
        {
            //call name generator
            NameGenerator();

            return _permutationsList;
        }

        private void NameGenerator()
        {
            // we can add the passed in as <FirstName> <Middle Name> <LastName>
            _permutationsList.Add(_name);

            // split the name into component pieces
            string[] fmlNames= _name.Split(' ');

            // build <FirstName> <Middle Initial> <LastName>
            // Since '+' concatenation is frowned upon
            // we'll the string Format method here
            _permutationsList.Add(string.Format("{0} {1} {2}", fmlNames[0], fmlNames[1][0], fmlNames[2]));

            // build <FirstName> <Middle Initial><period> <LastName>
            // we'll the string interpolation technique here - syntactic sugar for the previous
            _permutationsList.Add($"{fmlNames[0]} {fmlNames[1][0]}. {fmlNames[2]}");

            // build <FirstName> <LastName>
            // we'll a StringBuilder here
            StringBuilder sb = new StringBuilder().Append(fmlNames[0]).Append(" ").Append(fmlNames[2]);
            _permutationsList.Add(sb.ToString());
            // cleanup
            sb.Clear();
        }
    }
}
