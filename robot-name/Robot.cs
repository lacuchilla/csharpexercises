using System;

namespace exercism
{
    public class Robot
    {
        private static readonly Random Random = new Random();

        private string _name;

        public string Name => _name ?? (_name = SetName());

        public void Reset()
        {
            _name = null;
        }

        private static string SetName()
        {
            const string alphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numberChars = "0123456789";
            var stringChars = new char[2];
            var numChars = new char[3];

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = alphaChars[Random.Next(alphaChars.Length)];
            }
            var firstPart = new string(stringChars);
            for (var j = 0; j < numChars.Length; j++)
            {
                numChars[j] = numberChars[Random.Next(numberChars.Length)];
            }
            var secondPart = new string(numChars);

            return firstPart + secondPart;
        }
    }
}