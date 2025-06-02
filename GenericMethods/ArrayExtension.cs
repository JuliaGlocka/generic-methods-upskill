using GenericMethods.Interfaces;

namespace GenericMethods
{
    /// <summary>
    /// Provides generic extension methods for arrays.
    /// </summary>
    public static class ArrayExtension
    {
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, Func<TSource, TResult> transformer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(transformer);

            TResult[] result = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = transformer(source[i]);
            }

            return result;
        }

        public static T[] Filter<T>(this T[] source, Predicate<T> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            return source.Where(item => predicate(item)).ToArray();
        }

        // Overload for IPredicate<T> (for tests)
        public static T[] Filter<T>(this T[] source, IPredicate<T> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            return source.Where(item => predicate.IsMatch(item)).ToArray();
        }

        // Now returns the sorted array for test compatibility!
        public static T[] SortBy<T>(this T[] source, IComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(comparer);
            Array.Sort(source, comparer);
            return source;
        }

        public static void Swap<T>(this T[] array, int indexA, int indexB)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (indexA < 0 || indexA >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(indexA));
            }

            if (indexB < 0 || indexB >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(indexB));
            }

            if (indexA == indexB)
            {
                return;
            }

            (array[indexA], array[indexB]) = (array[indexB], array[indexA]);
        }

        // For ref-based Swap (used in tests)
        public static void Swap<T>(ref T left, ref T right)
        {
            (left, right) = (right, left);
        }
    }
}
