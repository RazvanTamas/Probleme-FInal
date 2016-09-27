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
            Assert.AreEqual("FizzBuzz", CalculateFizzBuzz(15));
        }
        string CalculateFizzBuzz(double n)
        {
            if (n / 3 == Math.Round(n / 3) && n / 5 == Math.Round(n / 5))
                return "FizzBuzz";
            else if (n / 3 == Math.Round(n / 3))
                return "Fizz";
            else if (n / 5 == Math.Round(n / 5))
                return "Buzz";
            else return "";              
        }
    }
}
