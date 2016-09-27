using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//1-10 zile 2%/zi
//11-30 zile 5%/zi
//31-40 zile 10%/zi
namespace RentDebt
{
    [TestClass]
    public class RentDebtTest
    {
        [TestMethod]
        public void RentForMoreThan30Days()
        {
            Assert.AreEqual(3300, CalculateTotalRent(100, 30));
        }
        decimal CalculateTotalRent(decimal rent, int day)
        {
            decimal rentPerDay = RentForMoreThan30DaysLate(rent);
            decimal totalRent = day * rentPerDay;
            return totalRent;
        }

        private static decimal RentForMoreThan30DaysLate(decimal rent)
        {
            decimal interest = 10;
            decimal debtPerDay = rent * interest / 100;
            decimal rentPerDay = rent + debtPerDay;
            return rentPerDay;
        }
    }
}
