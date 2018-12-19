using System;
using System.Collections;
using System.Collections.Generic;

namespace SearchServices
{
    public class PermutationService
    {
        private readonly List<string> permutationsList;

        public PermutationService(string name)
        {
            permutationsList = new List<string>();
        }

        public IList GeneratePermutations(string Name)
        {
            return permutationsList;
        }
    }
}
