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

        public bool IsMatch(int value)
        {
            int digit = Math.Abs(this.Digit);

            // Special case: digit == 0 and value == 0
            if (digit == 0 && value == 0)
            {
                return true;
            }

            // Use string-based approach to avoid Math.Abs(int.MinValue) overflow
            string digitStr = digit.ToString(CultureInfo.InvariantCulture);
            string valueStr = value.ToString(CultureInfo.InvariantCulture);

            if (valueStr.StartsWith('-'))
            {
                valueStr = valueStr.Substring(1);
            }

            return valueStr.Contains(digitStr, StringComparison.Ordinal);
        }
    }
}
