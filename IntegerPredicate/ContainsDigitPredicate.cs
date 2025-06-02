using System;
using System.Globalization;
using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    public class ContainsDigitPredicate : IPredicate<int>
    {
        public ContainsDigitPredicate()
        {
        }

        public ContainsDigitPredicate(int digit)
        {
            this.Digit = digit;
        }

        public int Digit { get; set; }

        public bool IsMatch(int obj)
        {
            int digit = Math.Abs(this.Digit);

            // Special case: digit == 0 and obj == 0
            if (digit == 0 && obj == 0)
            {
                return true;
            }

            string digitStr = digit.ToString(CultureInfo.InvariantCulture);
            string objStr = obj.ToString(CultureInfo.InvariantCulture);

            if (objStr.StartsWith('-'))
            {
                objStr = objStr.Substring(1);
            }

            return objStr.Contains(digitStr, StringComparison.Ordinal);
        }
    }
}
