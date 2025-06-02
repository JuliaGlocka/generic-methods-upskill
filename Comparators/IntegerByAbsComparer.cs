namespace Comparators
{
    /// <summary>
    /// Compares integers by their absolute values.
    /// </summary>
    public class IntegerByAbsComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return Math.Abs(x).CompareTo(Math.Abs(y));
        }
    }
}
