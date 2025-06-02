namespace GenericMethods.Tests.NUnitTests
{
    public static class TypeOfExtensions
    {
        public static T[] TypeOf<T>(this object[] source)
        {
            return source == null ? throw new ArgumentNullException(nameof(source)) : source.OfType<T>().ToArray();
        }
    }
}
