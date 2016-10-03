using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoChances
{
    [TestClass]
    public class LottoChancesTest
    {
        [TestMethod]
        public void TestFor6()
        {
            Assert.AreEqual(0.0000000715112384201851626194m, CalculateChances(6, 49));
        }
        [TestMethod]
        public void TestFor5()
        {
            Assert.AreEqual(0.0000005244157484146911925424m, CalculateChances(5, 49));
        }
        decimal CalculateChances(int favNumbers,int allNumbers)
        {
            decimal favNumbersDec = Convert.ToDecimal(favNumbers);            
            decimal probability = 1;
            for(decimal i = 1; i <= favNumbersDec; i++)
            {
                probability = probability * (i / allNumbers);
                allNumbers -= 1;
            }
            return probability;
        }
    }
}
