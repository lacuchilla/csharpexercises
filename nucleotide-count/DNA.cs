using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace exercism
{
    public class Dna
    {
        private readonly Dictionary<char, int> _allDnaCount = new Dictionary<char, int>
        {
            {'A', 0},
            {'T', 0},
            {'C', 0},
            {'G', 0}
        };

        public Dna(string letters)
        {
            foreach (var letter in letters)
            {
                _allDnaCount[letter] += 1;
            }
        }

        public Dictionary<char, int> NucleotideCounts()
        {
            return _allDnaCount;
        }

        public int Count(char letter)
        {
            var filter = new Regex("[ACGT]");

            if (filter.IsMatch(letter.ToString()))
            {
                return _allDnaCount[letter];
            }
            throw new InvalidNucleotideException();
        }

    }

    public class InvalidNucleotideException : Exception
        {
        }
    }
