using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringReversalWithRecursion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringWithNoCharsToReverse()
        {
            Assert.AreEqual("", ReverseString(""));
        }
        [TestMethod]
        public void StringWithLengthBiggerThanZeroToReverse()
        {
            Assert.AreEqual("fedcba", ReverseString("abcdef"));
        }

        string ReverseString(string stringForReversion)
        {
            if (stringForReversion.Length < 1)
                return stringForReversion;
            else
                return ReverseString(stringForReversion.Substring(1)) + stringForReversion[0];
        }
    }
}
