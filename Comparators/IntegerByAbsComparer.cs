namespace Comparators
{
    /// <summary>
    /// Compares integers by their absolute values.
    /// </summary>
    public class IntegerByAbsComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            long absX = x == int.MinValue ? (long)int.MaxValue + 1 : Math.Abs(x);
            long absY = y == int.MinValue ? (long)int.MaxValue + 1 : Math.Abs(y);
            return absX.CompareTo(absY);
        }
    }
}
