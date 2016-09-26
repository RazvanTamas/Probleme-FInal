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
        [TestMethod]
        public void DaytimeFareFor60km()
        {
            Assert.AreEqual(420, CalculateFare(70, 10));
        }
            
        decimal CalculateFare(int distance,int hour)
        {
            decimal pricePerKm = 5;
            if (LongDistance(distance))
                pricePerKm = 6;
            else if (MediumDistance(distance))
                pricePerKm = 8;          
            return distance * pricePerKm;
        }

        private bool LongDistance(int distance)
        {
            return distance>60;
        }

        private static bool MediumDistance(int distance)
        {
            return distance > 20;
        }
    }
}
