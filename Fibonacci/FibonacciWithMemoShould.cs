using System;
using NFluent;
using NUnit.Framework;

namespace Fibonacci
{
    [TestFixture]
    public class FibonacciWithMemoShould
    {
        [Test]
        public void Recursion_with_memo_is_faster()
        {
            var memo = new ulong[36];
            memo[1] = 1;
            memo[2] = 1;

            var fiboOf35 = FibonacciWithMemo.IndexOf(35, memo); //16 ms
            Check.That(fiboOf35).IsEqualTo(9227465);
        }

        [TestCase(80, 23416728348467685ul)]
        [TestCase(90,    2880067194370816120ul)]
        [TestCase(93, 12200160415121876738ul)]
        public void With_large_number_can_stackoverflow(long index, ulong expected)
        {
            //ulong l = 18_446_744_073_709_551_615;    ulong
                       //9_223_372_036_854_775_807     long
                       //            4_294_967_295     uint

            var memo = new ulong[index+1];
            memo[1] = 1;
            memo[2] = 1;

            ulong fiboOf35 = FibonacciWithMemo.IndexOf(index, memo); //16 ms
      
            Check.That(fiboOf35).IsEqualTo(expected);
        }
    }

    public class FibonacciWithMemo
    {
        public static ulong IndexOf(long index, ulong[] memo)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }

            var result = IndexOf(index - 1, memo) + IndexOf(index - 2, memo);
            memo[index] = result;

            return result;
        }
    }
}