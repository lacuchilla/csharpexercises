using System;

namespace exercism.hamming
{
    internal class Hamming
    {
        public static int Compute(string dnaStringOne, string dnaStringTwo)
        {
            //added extra behavior for different length strings counting as increased difference for fun
            var counter = 0;
            var shortestDnaString = Math.Min(dnaStringOne.Length, dnaStringTwo.Length);
            for (var index = 0; index < shortestDnaString; index++)
            {
                if (dnaStringOne[index] != dnaStringTwo[index])
                    counter += 1;
            }
            return counter + Math.Abs(dnaStringTwo.Length - dnaStringOne.Length);
        }
    }
}