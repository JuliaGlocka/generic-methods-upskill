using System;
using System.Linq;

namespace GenericMethods.Tests.NUnitTests
{
    public static class TypeOfExtensions
    {
        public static T[] TypeOf<T>(this object[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.OfType<T>().ToArray();
        }
    }
}
