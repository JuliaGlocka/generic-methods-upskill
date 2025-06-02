using System;

namespace DoubleTransformer
{
    /// <summary>
    /// Provides a method to get the IEEE 754 binary format of a double.
    /// </summary>
    public static class GetIeee754Format
    {
        public static string Transform(double value)
        {
            ulong bits = BitConverter.ToUInt64(BitConverter.GetBytes(value), 0);
            return Convert.ToString((long)bits, 2).PadLeft(64, '0');
        }
    }
}
