/*
 * Write a program that, given a number, can find the sum of all the multiples of particular numbers up to but not including that number.

If we list all the natural numbers up to but not including 20 that are
multiples of either 3 or 5, we get 3, 5, 6 and 9, 10, 12, 15, and 18.

The sum of these multiples is 78.
 */

using System.Collections.Generic;
using System.Globalization;

namespace exercism
{
    public static class IntHelpers
    {
        public static ICollection<int> MultiplesUnder(this int integer, int limit)
        {
            var multiples = new HashSet<int>();
            var counter = 1;
            int currentMult;
            while ((currentMult = counter * integer) < limit)
            {
                multiples.Add(currentMult);
                counter++;
            }

            return multiples;
        }
    }
    public class SumOfMultiples
    {
        public static int To(int[] ints, int limit)
        {
            //multiples of 3, 5 up to 10(count should be 23)
            var multiples = new HashSet<int>();
            var total = 0;

            foreach (var integer in ints)
            {
                var counter = 1;
                int currentMult;
                while ((currentMult = counter*integer) < limit)
                {
                    multiples.Add(currentMult);
                    counter++;
                }
            }

            foreach (var number in multiples)
            {
                total += number;
            }

            return total;
        }
    }
}