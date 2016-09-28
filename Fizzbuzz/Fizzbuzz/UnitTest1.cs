using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fizzbuzz
{
    [TestClass]
    public class FizzbuzzTest
    {
        [TestMethod]
        public void FizzOrBuzzTest1()
        {
            Assert.AreEqual("Fizz", CalculateFizzBuzz(3));
        }
        [TestMethod]
        public void FizzOrBuzzTest2()
        {
            Assert.AreEqual("FizzBuzz", CalculateFizzBuzz(15));
        }
        [TestMethod]
        public void FizzOrBuzzTest3()
        {
            Assert.AreEqual("Buzz", CalculateFizzBuzz(100));
        }
        string CalculateFizzBuzz(double n)
        {
            if (FizzBuzzIdentifier(n))
                return "FizzBuzz";
            else if (FizzIdendifier(n))
                return "Fizz";
            else if (BuzzIdentifier(n))
                return "Buzz";
            else return "";
        }

        private static bool FizzBuzzIdentifier(double n)
        {
            return n / 3 == Math.Round(n / 3) && n / 5 == Math.Round(n / 5);
        }

        private static bool BuzzIdentifier(double n)
        {
            return n / 5 == Math.Round(n / 5);
        }

        private static bool FizzIdendifier(double n)
        {
            return n / 3 == Math.Round(n / 3);
        }
    }
}
