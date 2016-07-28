using System;
using System.Collections.Generic;

namespace exercism
{
    public class Scrabble
    {
        private static Dictionary<string, int> _letterPointValues =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"a", 1},
                {"b", 3},
                {"c", 3},
                {"d", 4},
                {"e", 1},
                {"f", 4},
                {"g", 2},
                {"h", 4},
                {"i", 1},
                {"j", 8},
                {"k", 5},
                {"l", 1},
                {"m", 3},
                {"n", 1},
                {"o", 1},
                {"p", 3},
                {"q", 10},
                {"r", 1},
                {"s", 1},
                {"t", 1},
                {"u", 1},
                {"v", 4},
                {"w", 4},
                {"x", 8},
                {"y", 4},
                {"z", 10},
                {" ", 0}
            };

        public Scrabble(Dictionary<string, int> letterPointValues)
        {
            _letterPointValues = letterPointValues;
        }

        public static int Score(string cat)
        {
            var total = 0;

            int score;
            if (NullAndWhitespaceChecker(cat, total, out score)) return score;

            foreach (var letter in cat)
            {
                total = CalculatePointTotal(letter, total);
            }
            return total;
        }

        private static bool NullAndWhitespaceChecker(string cat, int total, out int score)
        {
            if (cat == null || cat == " \t\n")
            {
                score = total;
                return true;
            }
            score = 0;
            return false;
        }

        private static int CalculatePointTotal(char letter, int total)
        {
            var letterToCompare = letter.ToString();
            var whatToAdd = _letterPointValues[letterToCompare];
            total += whatToAdd;
            return total;
        }
    }
}