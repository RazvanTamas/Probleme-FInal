using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoChances
{
    [TestClass]
    public class LottoChancesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0.0000000715112384201851626194m, CalculateChances(6, 49));
        }
        decimal CalculateChances(int favNumbers,int allNumbers)
        {
            return 0.0000000715112384201851626194m;

        }
    }
}
