using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumbers
{
    [TestClass]
    public class RomanNumbersTest
    {
        [TestMethod]
        public void RomanNumberConverterTest1()
        {
            Assert.AreEqual("XLVI", RomanNumberConverter(46));
        }
        [TestMethod]
        public void RomanNumberConverterTest2()
        {
            Assert.AreEqual("C", RomanNumberConverter(100));
        }
        string RomanNumberConverter(decimal n)
        {
            string[] RomanSingleDigits = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
            string[] RomanMultiplesOf10 = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC", "C" };
            int firstDigit =decimal.ToInt32(Math.Truncate(n / 10));
            int secondDigit = decimal.ToInt32(((n / 10) - Math.Truncate(n / 10))*10);
            string RomanNumber = string.Concat(RomanMultiplesOf10[firstDigit], RomanSingleDigits[secondDigit]);
            return RomanNumber;
        }
    }
}
