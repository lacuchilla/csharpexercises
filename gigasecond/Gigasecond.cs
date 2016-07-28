using System;

namespace exercism.gigasecond
{
    public class Gigasecond
    {
        private const int OneBillionSeconds = 1000000000;

        public static DateTime Date(DateTime date)
        {
            return date.AddSeconds(OneBillionSeconds);
        }
    }
}