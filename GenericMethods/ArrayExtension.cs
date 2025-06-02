using System;
using System.Collections.Generic;
using GenericMethods.Interfaces;

namespace GenericMethods
{
    public static class ArrayExtension
    {
        // 1. TypeOf<T> extension for object[]
        public static T[] TypeOf<T>(this object[] source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var list = new List<T>();
            foreach (var obj in source)
            {
                if (obj is T t)
                {
                    list.Add(t);
                }
            }

            return list.ToArray();
        }

        // 2. Transform<TSource, TResult>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(transformer);

            var result = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = transformer.Transform(source[i]);
            }

            return result;
        }

        // 3. Filter<T>
        public static T[] Filter<T>(this T[] source, IPredicate<T> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            var list = new List<T>();
            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
        }

        // 4. SortBy<T>
        public static T[] SortBy<T>(this T[] source, IComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(comparer);

            var copy = (T[])source.Clone();
            Array.Sort(copy, comparer);
            return copy;
        }

        // 5. Reverse<T>
        public static T[] Reverse<T>(this T[] source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var copy = (T[])source.Clone();
            Array.Reverse(copy);
            return copy;
        }

        // 6. Swap<T>
        public static void Swap<T>(ref T left, ref T right)
        {
            (left, right) = (right, left);
        }
    }
}
