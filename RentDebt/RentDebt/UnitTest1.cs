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
        public void RentForMoreThan40Days()
        {
            Assert.AreEqual(500, CalculateTotalRent(100, 40));
        }
        [TestMethod]
        public void RentForMoreThan10Days()
        {
            Assert.AreEqual(350, CalculateTotalRent(200, 15));
        }
        [TestMethod]
        public void RentForLessThan10Days()
        {
            Assert.AreEqual(110, CalculateTotalRent(100, 5));
        }
        decimal CalculateTotalRent(decimal rent, decimal day)
        {
            decimal[] interest = { 2, 5, 10 };
            decimal interestPerDay = rent * (GetInterest(day, interest)/100);
            decimal totalRent = rent + day * interestPerDay;
            return totalRent;
        }

       
        decimal GetInterest(decimal day, decimal[] interest)
        {
            if (ManyDaysLate(day))
                return interest[2];
            else if (MoreThanAFewDaysLate(day))
                return interest[1];
            return interest[0];
        }       
        private bool MoreThanAFewDaysLate(decimal day)
        {
            return day > 10 && day < 31;
        }
        private bool ManyDaysLate(decimal day)
        {
            return day > 30;
        }
    }
}
