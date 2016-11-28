using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringReversalWithRecursion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("a", ReverseString("a"));
        }

        string ReverseString(string stringForReversion)
        {
            if (stringForReversion.Length <= 1) return stringForReversion;           
            return stringForReversion;
        }
    }
}
