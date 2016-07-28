using System;
using System.Collections.Generic;
using System.Linq;

namespace exercism.anagram
{
    internal class Anagram
    {
        private readonly string _input;
        private readonly string _orderedInput;

        public Anagram(string input)
        {
            _input = input;
            _orderedInput = GetOrderedVersion(input);
        }

        public IEnumerable<string> Match(string[] words)
        {
            return words.Where(IsAnagram);
        }

        private bool IsAnagram(string word)
        {
            if (word.Equals(_input, StringComparison.InvariantCultureIgnoreCase))
                return false;

            var orderedPotentialAnagram = GetOrderedVersion(word);
            return _orderedInput == orderedPotentialAnagram;
        }

        private static string GetOrderedVersion(string word)
        {
            var orderedPotentialAnagramArray = word.ToUpper().OrderBy(letter => letter);
            return string.Join("", orderedPotentialAnagramArray);
        }
    }
}