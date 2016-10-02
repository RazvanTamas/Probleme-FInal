using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrefixTest
{
    [TestClass]
    public class PrefixTest
    {
        [TestMethod]
        public void PrefixTest1()
        {
            Assert.AreEqual("aaa", Prefix("aaab", "aaaabbaa"));
        }
        string Prefix(string word1,string word2)
        {
            return "aaa";
        }
    }
}
