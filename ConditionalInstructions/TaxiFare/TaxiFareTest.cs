using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxiFare
{
    [TestClass]
    public class TaxiFareTest
    {
        [TestMethod]
        public void DaytimeFareFor2Km()
        {
            Assert.AreEqual(10, CalculateFare(2, 10)); 
        }
        decimal CalculateFare(int distance,int hour)
        {
            return distance*5;
        }
    }
}
