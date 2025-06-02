using System;
using System.Collections.Generic;

namespace GenericMethods
{
    /// <summary>
    /// Provides generic extension methods for arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Transforms each element in the source array using the provided transformer.
        /// </summary>
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

        /// <summary>
        /// Filters elements by predicate.
        /// </summary>
        public static T[] Filter<T>(this T[] source, Predicate<T> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            List<T> result = [];
            result.AddRange(source.Where(item => predicate(item)));

            return result.ToArray();
        }

        /// <summary>
        /// Sorts an array in-place using the provided comparer.
        /// </summary>
        public static void SortBy<T>(this T[] source, IComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(comparer);

            Array.Sort(source, comparer);
        }

        /// <summary>
        /// Swaps two elements in an array.
        /// </summary>
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
    }
}
