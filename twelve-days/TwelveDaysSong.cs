using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace exercism
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal enum Ordinals
    {
        first = 1,
        second,
        third,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth,
        ninth,
        tenth,
        eleventh,
        twelfth
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal enum Counts
    {
        a,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        eleven,
        twelve
    }

    public class TwelveDaysSong
    {
        private static readonly string[] Gifts =
        {
            "Partridge in a Pear Tree",
            "Turtle Doves",
            "French Hens",
            "Calling Birds",
            "Gold Rings",
            "Geese-a-Laying",
            "Swans-a-Swimming",
            "Maids-a-Milking",
            "Ladies Dancing",
            "Lords-a-Leaping",
            "Pipers Piping",
            "Drummers Drumming"
        };

        public string Verse(int line)
        {
            var prefix = $"On the {GetOrdinal(line)} day of Christmas my true love gave to me,";
            var giftList = BuildGiftList(line);
            var gifts = string.Join(", ", giftList);
            return $"{prefix} {gifts}.\n";
        }

        private static IEnumerable<string> BuildGiftList(int highestLine)
        {
            var giftList = new List<string>();
            for (var i = highestLine - 1; i >= 0; i--)
            {
                var and = highestLine > 1 && i == 0
                    ? "and "
                    : string.Empty;
                giftList.Add($"{and}{GetCount(i)} {Gifts[i]}");
            }
            return giftList;
        }

        private static string GetOrdinal(int num)
        {
            return Enum.GetName(typeof(Ordinals), num);
        }

        private static string GetCount(int num)
        {
            return Enum.GetName(typeof(Counts), num);
        }

        public string Verses(int start, int end)
        {
            var output = "";
            for (var c = start; c <= end; c++)
            {
                output += Verse(c) + "\n";
            }
            return output;
        }

        public string Sing()
        {
            return Verses(1, 12);
        }
    }
}