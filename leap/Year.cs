namespace exercism.leap
{
    public class Year
    {
        public static bool IsLeap(int year)
        {
            return DivisibleByFourHundred(year) || DivisibleByFourButNotOneHundred(year);
        }

        private static bool DivisibleByFourButNotOneHundred(int year)
        {
            return year%4 == 0 && year%100 != 0;
        }

        private static bool DivisibleByFourHundred(int year)
        {
            return year%400 == 0;
        }
    }
}