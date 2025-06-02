using NUnit.Framework;
using GenericMethods; // Ensure the namespace containing ArrayExtension is imported

namespace GenericMethods.Tests.NUnitTests;

[TestFixture(12, 13, TypeArgs = [typeof(int)])]
[TestFixture("12", "2", TypeArgs = [typeof(string)])]
[TestFixture(-123.543, 13.56, TypeArgs = [typeof(double)])]
[TestFixture(true, false, TypeArgs = [typeof(bool)])]
[TestFixture('a', 'A', TypeArgs = [typeof(char)])]
internal class ArrayExtensionSwapTestFixture<T>(T left, T right)
{
    [Test]
    public void SwapTest()
    {
            T expectedLeft = right;
        T expectedRight = left;
        ArrayExtension.Swap(ref left, ref right); // Fully qualify the method call
        Assert.That(left!.Equals(expectedLeft) && right!.Equals(expectedRight));
    }
}
