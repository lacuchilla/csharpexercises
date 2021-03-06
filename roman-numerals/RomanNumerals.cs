﻿using System.Collections.Generic;
using System.Text;
using static System.String;

namespace exercism
{
    public static class IntExtension
    {
        private static readonly Dictionary<int, string> Numerals =
            new Dictionary<int, string>
            {
                {0, ""},
                {1, "I"},
                {2, "II"},
                {3, "III"},
                {4, "IV"},
                {5, "V"},
                {6, "VI"},
                {7, "VII"},
                {8, "VIII"},
                {9, "IX"},
                {10, "X"},
                {20, "XX"},
                {30, "XXX"},
                {40, "XL"},
                {50, "L"},
                {60, "LX"},
                {70, "LXX"},
                {80, "LXXX"},
                {90, "XC"},
                {100, "C"},
                {200, "CC"},
                {300, "CCC"},
                {400, "CD"},
                {500, "D"},
                {600, "DC"},
                {700, "DCC"},
                {800, "DCCC"},
                {900, "CM"},
                {1000, "M"},
                {2000, "MM"},
                {3000, "MMM"}
            };

        public static string ToRoman(this int numbers)
        {
            var remainingNumber = numbers;
            var romanNumeral = new StringBuilder();
            var tensValue = Empty;
            var hundredsValue = Empty;
            var thousandsValue = Empty;

            if (numbers == 0) return Numerals[numbers];
            var onesDigit = remainingNumber%10;
            var onesValue = Numerals[onesDigit];
            remainingNumber -= onesDigit;
            if (remainingNumber > 9)
            {
                var tensDigit = remainingNumber%100;
                tensValue = Numerals[tensDigit];
                remainingNumber -= tensDigit;

                if (remainingNumber > 99)
                {
                    var hundredsDigit = remainingNumber%1000;
                    hundredsValue = Numerals[hundredsDigit];
                    remainingNumber -= hundredsDigit;
                    if (remainingNumber > 999)
                    {
                        thousandsValue = Numerals[remainingNumber];
                    }
                }
            }
            romanNumeral.Append(thousandsValue);
            romanNumeral.Append(hundredsValue);
            romanNumeral.Append(tensValue);
            romanNumeral.Append(onesValue);
            return romanNumeral.ToString();
        }
    }
}