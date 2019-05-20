using NFluent;
using NUnit.Framework;

namespace Fibonacci
{
    [TestFixture]
    public class FibonacciBottomUpShould
    {
        [Test]
        public void Will_not_stackoverflow()
        {
            var fibOf93 = FibonacciBottomUp.IndexOf(93);
            Check.That(fibOf93).IsEqualTo(12200160415121876738);
        }
    }

    public class FibonacciBottomUp
    {
        public static ulong IndexOf(long index)
        {
            var array = new ulong[index + 1];
            array[1] = 1;
            array[2] = 1;

            for (int i = 3; i <= index; i++)
            {
                array[i] = array[i-1] + array[i - 2];
            }

            return array[index];
        }
    }
}