using System.Text;
using System.Text.RegularExpressions;

namespace exercism
{
    public class PhoneNumber
    {
        private readonly string _numbers;

        public PhoneNumber(string numbers)
        {
            _numbers = numbers;
        }

        public string Number()
        {
            var validPhoneNumber = new StringBuilder();
            var filter = new Regex("[0-9]");
            foreach (var number in _numbers)
            {
                if (!filter.IsMatch(number.ToString())) continue;
                validPhoneNumber.Append(number);
            }
            if (validPhoneNumber[0] != '1' || validPhoneNumber.Length != 11)
            {
                return (validPhoneNumber.Length == 11 && validPhoneNumber[0] != 1) || validPhoneNumber.Length == 9
                    ? "0000000000"
                    : validPhoneNumber.ToString();
            }
            validPhoneNumber.Remove(0, 1);
            return validPhoneNumber.ToString();
        }

        public string AreaCode()
        {
            var getAreaCode = _numbers;

            return getAreaCode.Substring(0, 3);
        }

        public override string ToString()
        {
            var cleanedNumber = _numbers;
            var firstPart = cleanedNumber.Substring(0, 3);
            var secondPart = cleanedNumber.Substring(3, 3);
            var thirdPart = cleanedNumber.Substring(6, 4);
            return "(" + firstPart + ") " + secondPart + "-" +
                   thirdPart;
        }
    }
}