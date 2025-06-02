using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    /// <summary>
    /// Predicate that checks if an integer contains a specific digit.
    /// </summary>
    public class ContainsDigitPredicate : IPredicate<int>
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

        public bool IsMatch(int obj)
        {
            // Special handling for int.MinValue
            if (obj == int.MinValue)
            {
                int n = int.MinValue;
                do
                {
                    if (Math.Abs(n % 10) == this.Digit)
                    {
                        return true;
                    }

                    n /= 10;
                }
                while (n != 0);

                return false;
            }

            int absNumber = Math.Abs(obj);

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
