using System;
using System.Linq;

namespace exercism.binary
{
    public class Binary
    {
        public static int ToDecimal(string binary)
        {
            var filter = "10";
            foreach (var letter in binary)
            {
                if (!filter.Contains(letter.ToString()))
                {
                    return 0;
                }
            }
            var result = Convert.ToInt32(binary, 2);
            return result;
        }
    }
}
