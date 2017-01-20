using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotoBallSort
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSwap()
        {
            int[] unswapped = new int[] { 3, 1 };
            CollectionAssert.AreEqual(new int[] { 1, 3 }, swapNumbers(ref unswapped, 1));
        }
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new int[] { 3, 16, 21, 25, 34, 43, 48 }, SortLottoBalls(new int[] { 3, 16, 21, 25, 43, 48 }, 34));
        }

        int[] SortLottoBalls(int[]lottoBalls,int newBall)
        {
            Array.Resize(ref lottoBalls, lottoBalls.Length + 1);
            lottoBalls[lottoBalls.Length - 1] = newBall;
            for(int i = lottoBalls.Length - 1; i > 0; i--)
                if (lottoBalls[i] < lottoBalls[i - 1])
                    swapNumbers(ref lottoBalls, i);
            return lottoBalls;
        }

        int[] swapNumbers(ref int[] lotoBalls,int i)
        {
            int temp = lotoBalls[i];
            lotoBalls[i] = lotoBalls[i - 1];
            lotoBalls[i - 1] = temp;
            return lotoBalls;
        }
    }
}
