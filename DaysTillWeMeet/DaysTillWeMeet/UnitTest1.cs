using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaysTillWeMeet
{
    [TestClass]
    public class DaysTillWeMeetTest
    {
        [TestMethod]
        public void TestLargestCommonDivider()
        {
            Assert.AreEqual(2, CalculateDaysWeMeet(4, 6));
        }
        int CalculateDaysWeMeet(int days1, int days2)
        {
            int largestCommonDivider = 0;
            while (days1 != days2)
            {
                if (days1 < days2)
                {
                    largestCommonDivider = days2 - days1;
                    days2 -= days1;
                }
                else
                {
                    largestCommonDivider = days1 - days2;
                    days1 -= days2;
                }
            }
            return largestCommonDivider;
        }         
    }
}
