using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    public class ContainsDigitPredicate : IPredicate<int>
    {
        public int Digit { get; set; }

        // Parameterless constructor for object initializer compatibility
        public ContainsDigitPredicate() { }

        // Optionally, keep the original constructor for direct usage
        public ContainsDigitPredicate(int digit)
        {
            this.Digit = digit;
        }

        public bool IsMatch(int value)
        {
            int digit = System.Math.Abs(Digit);
            int val = System.Math.Abs(value);

            // Special case: digit == 0
            if (digit == 0 && value == 0)
            {
                return true;
            }

            while (val > 0)
            {
                if (val % 10 == digit)
                {
                    return true;
                }
                val /= 10;
            }
            return false;
        }
    }
}
