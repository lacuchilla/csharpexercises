using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace exercism.etl
{
    public class ETL
    {
        public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> old)
        {
            var result = new Dictionary<string, int>();
            var points = old.Keys; //1, 2

            //p will be 1 then 2 ...
            foreach (var p in points)
            {
                //get letters with point value p from old format
                var letters = old[p];
                //get each key
                foreach (var letter in letters)
                {
                    result[letter.ToLower()] = p;
                    //for each value in the key
                    //make the value a key in the new dictionary
                    //assign the old key as a value for each key in the new directory until we've done all letters in the old key
                    //do this for each of the old keys
                }
            }
            return result;
        }
    }
}