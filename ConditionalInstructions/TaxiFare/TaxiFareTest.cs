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
        [TestMethod]
        public void NighttimeFareFor2Km()
        {
            Assert.AreEqual(14, CalculateFare(2, 22));
        }
            
        decimal CalculateFare(int distance,int hour)
        {
            decimal[] daytimePrices = { 5, 8, 6 };
            decimal[] nighttimePrices = { 7 };
            decimal[] prices = IsDaytime(hour) ? daytimePrices : nighttimePrices;
            decimal pricePerKm = CalcPricePerKm(distance,prices);
            return distance * pricePerKm;
        }

        private bool IsDaytime(int hour)
        {
            return 8 <= hour && hour < 21;
        }

        private decimal CalcPricePerKm(int distance, decimal[] prices)
        {           
            if (LongDistance(distance))
                return prices[2];
            else if (MediumDistance(distance))
                return prices[1];
            return prices[0];
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
