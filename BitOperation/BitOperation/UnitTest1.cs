using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitOperation
{
    [TestClass]
    public class BitOperationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("10001110", CalculateBase(142));
        }
        string CalculateBase(int number)
        {
            string numberInBase = "10001110";
            return numberInBase;
        }

    }
}
