using GenericMethods.Interfaces;

namespace DoubleTransformer
{
    public class GetIeee754Format : ITransformer<double, string>
    {
        public string Transform(double obj)
        {
            unsafe
            {
                ulong bits = *(ulong*)&obj;
                char[] chars = new char[64];
                for (int i = 63; i >= 0; i--)
                {
                    chars[63 - i] = ((bits & (1UL << i)) != 0) ? '1' : '0';
                }

                return new string(chars);
            }
        }
    }
}
