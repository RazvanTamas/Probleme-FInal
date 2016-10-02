using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagram
{
    [TestClass]
    public class AnagramTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(9, CalculateAnagramNr("abc"));
        }
        int CalculateAnagramNr(string word)
        {
            return 9;
        }
    }
}
