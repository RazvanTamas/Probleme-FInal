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
            Assert.AreEqual(40, CalculateDaysWeMeet(5, 8));
        }
        int CalculateDaysWeMeet(int days1, int days2)
        {          
           int smallestCommonDivider=days1*days2/LargestCommonDivider(days1,days2);
            return smallestCommonDivider;
        }

        int LargestCommonDivider(int days1,int days2)
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
