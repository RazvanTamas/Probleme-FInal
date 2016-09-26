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
        [TestMethod]
        public void DaytimeFareFor25Km()
        { 
        
            Assert.AreEqual(200, CalculateFare(25, 12));
        }
        decimal CalculateFare(int distance,int hour)
        {
            decimal pricePerKm = MediumDistance (distance) ? 8 : 5;
            return distance * pricePerKm;
        }

        private static bool MediumDistance(int distance)
        {
            return distance > 20;
        }
    }
}
