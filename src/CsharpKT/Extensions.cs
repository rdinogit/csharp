using CsharpKT.v1;

namespace CsharpKT
{
    public static class Extensions
    {
        public static int DivideByTwo(this int value)
        {
            return value / 2;
        }

        public static void Times(this int value, Action<int> action)
        {
            for (int i = 0; i < value; i++)
            {
                action(i);
            }
        }
    }
}
