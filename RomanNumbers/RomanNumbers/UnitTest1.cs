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
        [TestMethod]
        public void RomanNumberConverterTest3()
        {
            Assert.AreEqual("MMMCMXCIX", RomanNumberConverter(3999));
        }
        string RomanNumberConverter(int n)
        {           
            string[] romanSingleDigits = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
            string[] romanMultiplesOf10 = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC", "C" };
            string[] romanMultiplesOf100 = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM", "M" };
            string[] romanMultiplesOf1000 = { "", "M", "MM", "MMM" };
            int thousandsDigit = (int)(n / 1000) %10;
            int hundredsDigit = (int)(n / 100)%10 ;
            int tensDigit = (int)(n / 10)%10 ;
            int digit = (int)(n % 10);
            string romanNumber = string.Concat(string.Concat(romanMultiplesOf1000[thousandsDigit], romanMultiplesOf100[hundredsDigit]), string.Concat(romanMultiplesOf10[tensDigit], romanSingleDigits[digit]));
            return romanNumber;
        }
    }
}
