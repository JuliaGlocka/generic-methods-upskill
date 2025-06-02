using System;

namespace IntegerPredicate
{
    /// <summary>
    /// Predicate that checks if an integer contains a specific digit.
    /// </summary>
    public class ContainsDigitPredicate
    {
        public ContainsDigitPredicate(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be between 0 and 9.");
            }

            this.Digit = digit;
        }

        public int Digit { get; set; }

        public bool IsMatch(int number)
        {
            int absNumber = Math.Abs(number);

            if (absNumber == 0 && this.Digit == 0)
            {
                return true;
            }

            while (absNumber > 0)
            {
                if (absNumber % 10 == this.Digit)
                {
                    return true;
                }

                absNumber /= 10;
            }

            return false;
        }
    }
}
