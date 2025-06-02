using GenericMethods.Interfaces;
namespace IntegerPredicate
{
    public class ContainsDigitPredicate : IPredicate<int>
    {
        public int Digit { get; set; }

        public ContainsDigitPredicate()
        {
        }

        public ContainsDigitPredicate(int digit)
        {
            this.Digit = digit;
        }

        public bool IsMatch(int value)
        {
            int digit = System.Math.Abs(Digit);

            // Special case: digit == 0 and value == 0
            if (digit == 0 && value == 0)
            {
                return true;
            }

            // Use string-based approach to avoid Math.Abs(int.MinValue) overflow
            string s = System.Math.Abs(digit).ToString();
            string v = value.ToString();
            // Remove leading '-' if present
            if (v.StartsWith("-"))
            {
                v = v.Substring(1);
            }

            return v.Contains(s);
        }
    }
}
