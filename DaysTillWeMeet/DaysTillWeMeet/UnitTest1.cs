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
            Assert.AreEqual(12, CalculateDaysWeMeet(4, 6));
        }
        decimal CalculateDaysWeMeet(int daysFirst, int daysSecond)
        {
         
            for (decimal i = 1; i < (daysFirst * daysSecond); i++)
            {
                if ((i / daysFirst)==Math.Truncate(i/daysFirst) && (i / daysSecond)==Math.Truncate(i/daysSecond ))
                    return i;
            }
            return daysFirst * daysSecond;
        //   int smallestCommonDivider=daysFirst*daysSecond/LargestCommonDivider(daysFirst,daysSecond);
        //    return smallestCommonDivider;
        }

       // int LargestCommonDivider(int daysFirst,int daysSecond)
       // {
        //    int largestCommonDivider = 0;
       //     while (daysFirst != daysSecond)
       //     {
       //         if (daysFirst < daysSecond)
       //         {
       //             largestCommonDivider = daysSecond - daysFirst;
       //             daysSecond -= daysFirst;
       //         }
       //         else
       //         {
       //             largestCommonDivider = daysFirst - daysSecond;
       //             daysFirst -= daysSecond;
       //         }
       //     }
        //    return largestCommonDivider;
      //  }
    }
}
