using System;
using NFluent;
using NUnit.Framework;

namespace Fibonacci
{
    public class FibonacciNaiveRecursionShould
    {
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(10, 55)]
        public void Can_use_native_recursion(int index, int expected)
        {
            int actual = FibonacciNaiveRecursion.IndexOf(index);
            Check.That(actual).IsEqualTo(expected);
        }

        [Test]
        public void Naive_recursion_is_slow()
        {
            int fiboOf35 = FibonacciNaiveRecursion.IndexOf(35); //3.375 sec
            Check.That(fiboOf35).IsEqualTo(9227465);
        }
    }


    public class FibonacciNaiveRecursion
    {
        public static int IndexOf(int index)
        {
            if (index < 1)
            {
                throw new ArgumentException("Fibonacci is 1 base indexed");
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            return IndexOf(index - 1) + IndexOf(index - 2);
        }
    }


}