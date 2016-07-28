using System;
using System.Collections.Generic;
using exercism.meetup;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace exercism
{
    public class PrimeFactors
    {
        public static int[] For(long number)
        {
            var numberToDivide = number;
            var divisor = 2;
            var primeFactors = new List<int>();
            if (number == 0 || number == 1)
            {
                return new int[0];
            }
            do
            {
                var check = numberToDivide%divisor;
                if (check == 0)

                {
                    primeFactors.Add(divisor);
                    numberToDivide = numberToDivide/divisor;
                }

                if (check == 1)
                {
                    divisor += 1;
                    check = numberToDivide%divisor;
                    if (check == 1)
                    {
                        divisor += 2;
                        numberToDivide = numberToDivide/divisor;
                        primeFactors.Add(divisor);
                    }
                    numberToDivide = numberToDivide/divisor;
                    primeFactors.Add(divisor);
                    
                }

            } while (numberToDivide > 1);

            var result = primeFactors.ToArray();

            return result;
            //if (number == 0 || number == 1)
            //    return new int[0];
            //if (number == 2 || number == 3)
            //    return new int[1] { Convert.ToInt32(number) };
            //if (number == 5 || number == 7)
            //    return new int[1] { Convert.ToInt32(number)};
            //var numberToCheck = number;
            //var divisor = 2;
            //var newValue = 0;

            //var comparison = numberToCheck%divisor;
            //if (comparison == 0)
            //    newValue = Convert.ToInt32(numberToCheck)/divisor;
            //    if (newValue == 2)
            //        return new int[2] { divisor, divisor};
            //    else if (newValue == 3)
            //        return new int[2] {divisor, newValue};
            //    else if (newValue == 4)
            //        return new int[3] {divisor, divisor, divisor};
            //if (comparison == 1)
            //    divisor += 1;
            //    newValue = Convert.ToInt32(numberToCheck)/divisor;
            //    if (newValue == 3)
            //        return new int[2] { divisor, divisor};
            //    if (newValue == 9)
            //        return new int[3] {divisor, divisor, divisor};
            //    divisor += 2;
            //    newValue = Convert.ToInt32(numberToCheck)/divisor;
            //        return new int[4] { divisor, divisor, divisor, divisor};
            

            //return new int[1] { Convert.ToInt32(number) };
            //if (comparison == 1)
            //    divisor += 1;
            //    comparison = numberToCheck%divisor;
            //    if (comparison == 0)
            //        return new int[] { Convert.ToInt32(number) };

            //return new int[0];
            //list of prime factors to add
            //    var primeFactors = new List<int>();
            //    //variable of number that we can divide without altering original number
            //    var input = Convert.ToInt32(number);
            //    //prime number we're dividing by currently to extract prime factors
            //    var divisor = 2;
            //    //check to determine if the current number is evenly divisible by the current prime divisor
            //    var moduloTheInput = input%divisor;

            //    //if the current subtractablenumber is evenly divisible by the current prime divisor
            //    if (moduloTheInput == 0)
            //    {
            //        //add the value of the current divisor to the list of prime factors to add
            //        primeFactors.Add(divisor);
            //        //divide the subtractable number by the current divisor
            //        var newValue = input/divisor;

            //        if (newValue == 1)
            //        {
            //            //var count = factorsToAdd.Count;
            //            primeFactors.Add(divisor);
            //            divisor += 1;
            //            var nextCheck = newValue%0;
            //            if (nextCheck == 1)
            //            {
            //                primeFactors.Add(divisor);
            //                return primeFactors.ToArray();
            //            }
            //            return primeFactors.ToArray();
            //        }
            //        else if (newValue == 0)
            //        {
            //            int[] result = { divisor, divisor };
            //            return result;
            //        }
            //        else
            //        {
            //            primeFactors.Add(divisor);
            //            var answer = new int[] { 2, 2 };
            //            return answer;
            //        }

            //    }
            //    else if (moduloTheInput == 1)
            //    {
            //        divisor += 1;
            //        int[] result = {divisor};
            //        return result;
            //    }

            //return new int[0];
        }
    }
}